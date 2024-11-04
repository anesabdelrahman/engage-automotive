using AutomotivePartsOrdering.Service.Application.ExternalAuthorisation;
using Microsoft.Extensions.Options;
using System.Net;
using System.Text;

namespace AutomotivePartsOrdering.Service.Application {
    public class PartService(IHttpClientWrapper httpClientWrapper, IConfiguration configuration, IOptions<ProviderSettings> options, ILogger<PartService> logger) : IPartService
    {
        const string PartsProvider = "ProviderPartsUrl";
        public async Task<HttpResponseMessage> GetPartAsync(string brandCode, string partCode, int page, int pageSize)
        {
            try {
                var (url, scope) = CreateGetUrl(brandCode, partCode, page, pageSize);
                return await httpClientWrapper.GetAsync(url, scope);
            }
            catch (Exception exception) {

                logger.LogError($"{nameof(GetPartAsync)}: {exception.Message}");

                return new HttpResponseMessage(HttpStatusCode.BadRequest) {
                    Content = new StringContent($"An unexpected error occurred.Please try again later or. Exception: {exception.Message}", Encoding.UTF8, "application / json")
                };
            }
        }

        private (string url, string scope) CreateGetUrl(string brandCode, string partCode, int page, int pageSize) {
            var url = $"{options.Value.ProviderPartsUrl}?brandCode={brandCode}&partCode={partCode}&page={page}&pageSize={pageSize}";
            var scope = options.Value.ProviderPartReadScope;
            return (url, scope);
        }
    }
}