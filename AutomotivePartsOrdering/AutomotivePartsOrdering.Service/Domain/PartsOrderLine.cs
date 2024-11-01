namespace AutomotivePartsOrdering.Service.Domain;

public class PartsOrderLine {
    public string OrderLineId { get; set; }
    public string PartId { get; set; }
    public string UnitOfSale { get; set; }
    public int Quantity { get; set; }
    public decimal value { get; set; }
    public UnitOfMeasure UnitOfMeasure { get; set; }
    public PartsOrderLineStatus PartsOrderLineStatus { get; set; }
    public List<VehicleReference> MandatoryVehicleReferences { get; set; }
    public Price ListPrice { get; set; }
    public Price OrderPrice { get; set; }
}