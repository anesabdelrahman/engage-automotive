using AutomotivePartsOrdering.Service.Dto;

namespace AutomotivePartsOrdering.Service.Application;

public interface IPartService {
    Task<PartDto> GetPartAsync(string brandCode, string partCode, int page, int pageSize);
}