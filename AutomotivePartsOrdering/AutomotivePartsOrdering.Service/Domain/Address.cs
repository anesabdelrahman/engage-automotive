using System.ComponentModel.DataAnnotations;

namespace AutomotivePartsOrdering.Service.Domain;

public class Address
{
    public Guid Id { get; set; }

    [Required, MaxLength(140)]
    public string StreetName { get; set; } = null!;
    public string HouseNumber { get; set; } = null!;
    public string BuildingName { get; set; } = null!;
    public string FloorNumber { get; set; } = null!;
    public string DoorNumber { get; set; } = null!;
    public string BlockName { get; set; } = null!;

    [Required]
    public string PostalCode { get; set; }
    public string Suburb { get; set; } = null!;
    public string City { get; set; } = null!;
    public string County { get; set; } = null!;
    public string Province { get; set; } = null!;

    [RegularExpression("^([A-Z]{2}|C2)$")]
    public string CountryCode { get; set; }
}