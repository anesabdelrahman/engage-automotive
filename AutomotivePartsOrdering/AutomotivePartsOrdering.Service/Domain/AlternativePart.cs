namespace AutomotivePartsOrdering.Service.Domain;

public class AlternativePart {
    public DateTime SupersessionDate { get; set; }
    public AlternativeType AlternativeType { get; set; }
    public List<Part>? Parts { get; set; }
}