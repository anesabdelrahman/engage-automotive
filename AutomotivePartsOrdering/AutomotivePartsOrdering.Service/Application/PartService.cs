using AutomotivePartsOrdering.Service.Middleware;
using Microsoft.Extensions.Options;
using AutomotivePartsOrdering.Service.Dto;

namespace AutomotivePartsOrdering.Service.Application {
    public class PartService(IHttpClientWrapper httpClientWrapper, IOptions<ProviderSettings> options, IAuthorisationService authorisationService, ILogger<PartService> logger) : IPartService {
        public async Task<PartDto> GetPartAsync(string brandCode, string partCode, int page, int pageSize) {
            try {
                if (options.Value.UseStubbedData) {
                    return await StubbedDataLoaderService.LoadStubbedPartDataAsync(brandCode, partCode);
                }

                var token = await authorisationService.GetAccessTokenAsync(options, options.Value.ProviderPartReadScope);
                var url = CreateGetUrl(brandCode, partCode, page, pageSize);

                if (token == null)
                    throw new Exception($"{nameof(GetPartAsync)} - Invalid Token");
                
                var response = await httpClientWrapper.GetAsync(url, token);

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"{nameof(GetPartAsync)} - Provider Error");

                var parts = await response.Content.ReadFromJsonAsync<PartDto>();
                return parts ?? new PartDto();

            }
            catch (Exception exception) {
                logger.LogError($"{nameof(GetPartAsync)}: {exception.Message}");
                return new PartDto();
            }
        }

        private string CreateGetUrl(string brandCode, string partCode, int page, int pageSize) {
            var url = $"{options.Value.ProviderPartsUrl}?brandCode={brandCode}&partCode={partCode}&page={page}&pageSize={pageSize}";
            return url;
        }
    }
}