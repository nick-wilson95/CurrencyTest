using System.ComponentModel.DataAnnotations;

namespace CurrencyApi.Models;

public class ConvertCurrencyRequest
{
    [Range(0, (double)decimal.MaxValue)]
    public decimal Amount { get; set; }

    [EnumDataType(typeof(Currency))]
    public Currency FromCurrency { get; set; }

    [EnumDataType(typeof(Currency))]
    public Currency ToCurrency { get; set; }
}
