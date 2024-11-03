namespace AutomotivePartsOrdering.Service.Domain;

public class Part {
    public Guid Id { get; set; }
    public string BrandCode { get; set; }
    public string PartCode { get; set; }
    public string Description { get; set; }
    public VehicleReference MandatoryVehicleReferences { get; set; }
    public List<AlternativePart>? AlternativeParts { get; set; }
}