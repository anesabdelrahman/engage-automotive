namespace AutomotivePartsOrdering.Service.DTOs {
    public class OrderDto {
        public Guid CustomerId { get; set; }
        public Guid CompanyId { get; set; }
        public OrderContactDto OrderContact { get; set; }
        public AddressDto? AlternateDeliveryAddress { get; set; }
        public string OrderType { get; set; }
        public string OrderReference { get; set; }
        public List<PartOrderDto> Parts { get; set; }
    }

    public class OrderContactDto {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
    }

    public class AddressDto {
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
    }

    public class PartOrderDto {
        public PartDto Part { get; set; }
        public int Quantity { get; set; }
        public VehicleReferenceDto MandatoryVehicleReferences { get; set; }
    }

    public class PartDto {
        public Guid PartId { get; set; }
        public string BrandCode { get; set; }
        public string PartCode { get; set; }
    }

    public class VehicleReferenceDto {
        public string Type { get; set; }
        public string Value { get; set; }
    }
}