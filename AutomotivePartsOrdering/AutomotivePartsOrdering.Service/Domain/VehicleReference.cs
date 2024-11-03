using AutomotivePartsOrdering.Service.Domain.Enums;

namespace AutomotivePartsOrdering.Service.Domain;

public class VehicleReference {
    public Guid Id { get; set; }
    public VehicleReferenceType Type { get; set; }
    public string Value { get; set; }
}