using System.ComponentModel.DataAnnotations;

namespace AutomotivePartsOrdering.Service.Domain;

public class DeliveryAddress
{
    public string StreetName { get; set; }
    public string HouseNumber { get; set; }
    public string BuildingName { get; set; }
    public string FloorNumber { get; set; }
    public string DoorNumber { get; set; }
    public string BlockName { get; set; }
    public string PostalCode { get; set; }
    public string Suburb { get; set; }
    public string City { get; set; }
    public string County { get; set; }
    public string Province { get; set; }

    [RegularExpression("^([A-Z]{2}|C2)$")]
    public string CountryCode { get; set; }
}