namespace CurrencyApi.Services;

public interface ICurrencyService
{
    public IEnumerable<Currency> GetCurrencies();
    public decimal Convert(decimal amount, Currency from, Currency to);
}

public class CurrencyService : ICurrencyService
{
    private readonly static Dictionary<Currency, decimal> usdBaseRates = new()
    {
        [Currency.CAD] = 1.260046m,
        [Currency.CHF] = 0.933058m,
        [Currency.EUR] = 0.806942m,
        [Currency.GBP] = 0.719154m,
        [Currency.USD] = 1,
    };

    public decimal Convert(decimal amount, Currency from, Currency to) =>
        amount * (usdBaseRates[to] / usdBaseRates[from]);

    public IEnumerable<Currency> GetCurrencies() =>
        Enum.GetValues(typeof(Currency)).Cast<Currency>();
}
