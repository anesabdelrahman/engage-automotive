namespace AutomotivePartsOrdering.Service.Domain;

public class UnitOfMeasure {
    public Guid Id { get; set; }
    public Unit Unit { get; set; }
    public decimal Value { get; set; } = 1;
}