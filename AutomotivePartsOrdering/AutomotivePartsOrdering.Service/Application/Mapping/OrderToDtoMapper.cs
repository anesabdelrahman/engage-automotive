using AutomotivePartsOrdering.Service.Domain;
using AutomotivePartsOrdering.Service.DTOs;

public class OrderMapper
{
    public static OrderDto MapOrderToDto(Order order) {
        return new OrderDto {
            CustomerId = order.CustomerId,
            CompanyId = order.CompanyId,
            OrderContact = new OrderContactDto {
                Name = order?.OrderContact?.Name,
                Phone = order.OrderContact?.Phone,
                Email = order.OrderContact?.Email,
                CompanyName = order.OrderContact?.CompanyName
            },
            AlternateDeliveryAddress = new AddressDto {
                StreetName = order.AlternateDeliveryAddress?.StreetName,
                PostalCode = order.AlternateDeliveryAddress?.PostalCode,
                City = order.AlternateDeliveryAddress?.City,
                CountryCode = order.AlternateDeliveryAddress?.CountryCode
            },
            OrderType = order.OrderType.ToString(),
            OrderReference = order.OrderReference,
            Parts = order.Parts.Select(partOrder => new PartOrderDto {
                Part = new PartDto {
                    PartId = partOrder.Part.Id,
                    BrandCode = partOrder.Part.BrandCode,
                    PartCode = partOrder.Part.PartCode
                },
                Quantity = partOrder.Quantity,
                MandatoryVehicleReferences = new VehicleReferenceDto
                {
                    Type = order.MandatoryVehicleReference.Type.ToString(),
                    Value = order.MandatoryVehicleReference.Value
                },
            }).ToList()
        };
    }
}
