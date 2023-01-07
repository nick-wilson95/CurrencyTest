using System.ComponentModel.DataAnnotations;

public class ConvertCurrencyRequest
{
    [Required]
    public string? FromCurrency { get; set; }

    [Required]
    public string? ToCurrency { get; set; }

    [Required]
    [Range(0, (double)decimal.MaxValue)]
    public decimal? Amount { get; set; }
}