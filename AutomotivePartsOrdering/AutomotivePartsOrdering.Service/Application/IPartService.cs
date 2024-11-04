using AutomotivePartsOrdering.Service.Domain;

namespace AutomotivePartsOrdering.Service.Application;

public interface IPartService {
    Task<HttpResponseMessage> GetPartAsync(string brandCode, string partCode, int page, int pageSize);
}