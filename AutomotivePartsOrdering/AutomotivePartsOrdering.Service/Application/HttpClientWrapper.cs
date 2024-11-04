using Microsoft.Identity.Abstractions;
using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace AutomotivePartsOrdering.Service.Application {

    /// <summary>
    /// The HttpClientWrapper.
    /// </summary>
    public class HttpClientWrapper(IHttpClientFactory httpFactory, IAuthorizationHeaderProvider authorizationHeaderProvider) : IHttpClientWrapper {
        private const string DefaultClientName = "DefaultClient";

        public async Task<HttpResponseMessage> PostAsync(HttpContent content, string requestUri, string scope) {
            var client = await GetDownstreamAuthToken(scope);
            return await client.PostAsync(requestUri, content);
        }

        public async Task<HttpResponseMessage> GetAsync(string url, string scope) {
            var client = await GetDownstreamAuthToken(scope);

            return await client.GetAsync(url);
        }

        public async Task<HttpResponseMessage> PutAsync(Uri uri, StringContent request, string clientName, string scope) {
            var client = await GetDownstreamAuthToken(scope);
            return await client.PutAsync(uri, request);
        }

        private async Task<HttpClient> GetDownstreamAuthToken(string scope) {
            var scopes = new[] { scope };
            var accessToken = await authorizationHeaderProvider.CreateAuthorizationHeaderForUserAsync(scopes);
            var client = GetHttpClient();
            client.DefaultRequestHeaders.Add("Authorization", accessToken);
            return client;
        }

        private HttpClient GetHttpClient() {
            return httpFactory.CreateClient(DefaultClientName);
        }

        //public async Task<string> GetAccessTokenAsync() {
        //    // Retrieve OAuth settings from configuration
        //    var clientId = _configuration["OAuthSettings:ClientId"];
        //    var clientSecret = _configuration["OAuthSettings:ClientSecret"];
        //    var tokenUrl = _configuration["OAuthSettings:TokenUrl"];
        //    var scope = _configuration["OAuthSettings:Scope"];

        //    // Prepare the request body
        //    var requestBody = new StringContent(
        //        $"grant_type=client_credentials&client_id={clientId}&client_secret={clientSecret}&scope={scope}",
        //        Encoding.UTF8, "application/x-www-form-urlencoded");

        //    // Send the request to the token endpoint
        //    using var request = new HttpRequestMessage(HttpMethod.Post, tokenUrl) {
        //        Content = requestBody
        //    };

        //    var httpClient = GetHttpClient();
        //    var response = await httpClient.SendAsync(request);

        //    // Handle the response
        //    if (response.IsSuccessStatusCode) {
        //        var jsonResponse = await response.Content.ReadAsStringAsync();
        //        var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(jsonResponse);
        //        return tokenResponse.AccessToken;
        //    }
        //    else {
        //        throw new Exception($"Failed to retrieve access token. Status code: {response.StatusCode}, Message: {response.ReasonPhrase}");
        //    }
        //}
    }

    //public class TokenResponse
    //{
    //    public string AccessToken { get; set; }
    //    public string TokenType { get; set; }
    //    public int ExpiresIn { get; set; }
    //}
}

