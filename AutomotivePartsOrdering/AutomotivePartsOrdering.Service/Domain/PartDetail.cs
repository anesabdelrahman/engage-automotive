namespace AutomotivePartsOrdering.Service.Domain;

public class PartDetail {
    public Guid Id { get; set; }
    public string BrandCode { get; set; }
    public string PartCode { get; set; }
    public int Quantity { get; set; }
}