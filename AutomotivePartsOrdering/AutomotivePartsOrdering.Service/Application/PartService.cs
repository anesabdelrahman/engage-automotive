using AutomotivePartsOrdering.Service.Application.ExternalAuthorisation;
using Microsoft.Extensions.Options;
using System.Net;

namespace AutomotivePartsOrdering.Service.Application {
    public class PartService(IHttpClientWrapper httpClientWrapper, IOptions<ProviderSettings> options, IAuthorisationService authorisationService, ILogger<PartService> logger) : IPartService
    {
        public async Task<HttpResponseMessage> GetPartAsync(string brandCode, string partCode, int page, int pageSize)
        {
            try {
                var token = await authorisationService.GetAccessTokenAsync(options, options.Value.ProviderPartReadScope);
                var url = CreateGetUrl(brandCode, partCode, page, pageSize);

                if (token != null)
                {
                    return await httpClientWrapper.GetAsync(url, token);
                }
                
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            catch (Exception exception) {

                logger.LogError($"{nameof(GetPartAsync)}: {exception.Message}");

                return new HttpResponseMessage(HttpStatusCode.BadRequest) {
                    Content = new StringContent($"An unexpected error occurred.Please try again later or. Exception: {exception.Message}")
                };
            }
        }

        private string CreateGetUrl(string brandCode, string partCode, int page, int pageSize) {
            var url = $"{options.Value.ProviderPartsUrl}?brandCode={brandCode}&partCode={partCode}&page={page}&pageSize={pageSize}";
            return url;
        }
    }
}