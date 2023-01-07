using CurrencyApi;
using CurrencyApi.Services;
using FluentAssertions;
using FsCheck;
using FsCheck.Xunit;
using Xunit;

namespace CurrencyApiTests;

public class CurrencyServiceTests
{
    private readonly CurrencyService currencySerivce = new();

    [Fact]
    public void GetCurrencies_ReturnsExpected()
    {
        var result = currencySerivce.GetCurrencies();

        result.Should().Equal(new[] { Currency.CAD, Currency.CHF, Currency.EUR, Currency.GBP, Currency.USD });
    }

    [Property]
    public Property Convert_SelfConversionIsIdentity(decimal amount, Currency currency)
    {
        var converted = currencySerivce.Convert(amount, currency, currency);

        return (converted == amount).ToProperty();
    }

    [Property]
    public Property Convert_ReconversionPreservesValue(decimal amount, Currency from, Currency to)
    {
        var roundedAmount = decimal.Round(amount, 2);

        var converted = currencySerivce.Convert(roundedAmount, from, to);
        var unconverted = currencySerivce.Convert(converted, to, from);

        return (decimal.Round(amount, 2) == decimal.Round(unconverted, 5)).ToProperty();
    }
}