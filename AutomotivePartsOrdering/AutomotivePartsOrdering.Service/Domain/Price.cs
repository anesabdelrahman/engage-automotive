using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomotivePartsOrdering.Service.Domain;

public class Price
{
    public Guid Id { get; set; }
    [Column(TypeName = "decimal(6,2)")]
    public decimal NetValue { get; set; }
    [Column(TypeName = "decimal(6,2)")]
    public decimal GrossValue { get; set; }
    [Column(TypeName = "decimal(6,2)")]
    public decimal TaxValue { get; set; }
    [Column(TypeName = "decimal(3,2)")]
    public decimal TaxRate { get; set; }

    [RegularExpression("[A-Z]{3}")]
    public string currencyCode { get; set; }
}