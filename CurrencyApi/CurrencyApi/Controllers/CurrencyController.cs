using CurrencyApi.Models;
using CurrencyApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CurrencyController : ControllerBase
{
    private readonly ICurrencyService currencyService;

    public CurrencyController(ICurrencyService currencyService)
    {
        this.currencyService = currencyService;
    }

    [HttpGet]
    public IEnumerable<Currency> Get() => currencyService.GetCurrencies();

    [HttpPost("convert")]
    public decimal Convert([FromBody] ConvertCurrencyRequest request)
    {
        var unrounded = currencyService.Convert(request.Amount, request.FromCurrency, request.ToCurrency);
        return decimal.Round(unrounded, 2);
    }
}