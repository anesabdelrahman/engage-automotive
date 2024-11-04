namespace AutomotivePartsOrdering.Service.Domain.Enums;

public enum PartsOrderLineStatus
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