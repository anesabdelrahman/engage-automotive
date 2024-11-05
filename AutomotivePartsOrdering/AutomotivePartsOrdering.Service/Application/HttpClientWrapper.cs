using System.Net.Http.Headers;

namespace AutomotivePartsOrdering.Service.Application {

    /// <summary>
    /// The HttpClientWrapper.
    /// </summary>
    public class HttpClientWrapper(IHttpClientFactory httpFactory) : IHttpClientWrapper {
        private const string DefaultClientName = "DefaultClient";

        public async Task<HttpResponseMessage> PostAsync(HttpContent content, string requestUri, string token) {
            var client = GetHttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await client.PostAsync(requestUri, content);
        }

        public async Task<HttpResponseMessage> PostAsync(string tokenUrl, FormUrlEncodedContent requestContent) {
            var client = GetHttpClient();
            

            return await client.PostAsync(tokenUrl, requestContent);
        }

        public async Task<HttpResponseMessage> GetAsync(string url, string token) {
            var client = GetHttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await client.GetAsync(url);
        }

        public async Task<HttpResponseMessage> PutAsync(HttpContent content, string requestUri, string token) {
            var client = GetHttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await client.PutAsync(requestUri, content);
        }

        private HttpClient GetHttpClient() {
            var client = httpFactory.CreateClient(DefaultClientName);
            client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            return client;
        }
    }
}

