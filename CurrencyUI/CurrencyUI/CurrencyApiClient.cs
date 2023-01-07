using System.Net.Http.Json;

namespace CurrencyUI;

public class CurrencyApiClient
{
	private const string URL = "https://localhost:7268"; //Get this from config
    private readonly HttpClient client;

    public CurrencyApiClient()
	{
		client = new HttpClient { BaseAddress = new Uri(URL) };
	}

    public async Task<string[]> GetCurrencies()
    {

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("/currency", UriKind.Relative)
        };

		var result = await client.SendAsync(request);
		return await result.Content.ReadFromJsonAsync<string[]>();
    }

    public async Task<decimal> Convert(ConvertCurrencyRequest requestBody)
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            Content = JsonContent.Create(requestBody),
            RequestUri = new Uri("/currency/convert", UriKind.Relative)
        };

        var result = await client.SendAsync(request);
        return await result.Content.ReadFromJsonAsync<decimal>();
    }
}
