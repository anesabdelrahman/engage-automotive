using System.ComponentModel.DataAnnotations;

namespace AutomotivePartsOrdering.Service.Domain;

public class Price
{
    public decimal NetValue { get; set; }
    public decimal GrossValue { get; set; }
    public decimal TaxValue { get; set; }
    public decimal TaxRate { get; set; }

    [RegularExpression("[A-Z]{3}")]
    public string currencyCode { get; set; }
}