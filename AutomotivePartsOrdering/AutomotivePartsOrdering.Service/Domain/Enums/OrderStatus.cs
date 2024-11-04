namespace AutomotivePartsOrdering.Service.Domain.Enums;

public enum OrderStatus
{
    OPEN,
    RESERVED,
    ISSUED,
    BACKORDER,
    PACKED,
    INTRANSIT,
    DELIVERED,
    CANCELLED,
    INVOICED
}