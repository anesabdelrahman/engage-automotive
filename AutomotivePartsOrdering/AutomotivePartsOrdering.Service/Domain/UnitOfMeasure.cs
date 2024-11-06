using System.ComponentModel.DataAnnotations.Schema;

namespace AutomotivePartsOrdering.Service.Domain;

public class UnitOfMeasure {
    public Guid Id { get; set; }
    public Unit Unit { get; set; }

    [Column(TypeName = "decimal(6,2)")]
    public decimal Value { get; set; } = 1;
}