using AutomotivePartsOrdering.Service.Domain.Enums;

namespace AutomotivePartsOrdering.Service.Domain;

public class OrderLine {
    public Guid Id { get; set; }
    public Guid PartsOrderId { get; set; }
    public Part Part { get; set; }
    public string UnitOfSale { get; set; }
    public int Quantity { get; set; }
    public decimal value { get; set; }
    public UnitOfMeasure UnitOfMeasure { get; set; }
    public PartsOrderLineStatus PartsOrderLineStatus { get; set; }
    
    public Price ListPrice { get; set; }
    public Price OrderPrice { get; set; }
}