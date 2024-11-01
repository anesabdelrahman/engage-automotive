namespace AutomotivePartsOrdering.Service.Domain;

public class VehicleReference {
    public VehicleReferenceType Type { get; set; }
    public string Value { get; set; }
}

public enum VehicleReferenceType {
    KEYNUMBER,
    VIN,
    ENGINENUMBER
}