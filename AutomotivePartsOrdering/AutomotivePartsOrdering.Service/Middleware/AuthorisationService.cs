using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.Extensions.Options;
using AutomotivePartsOrdering.Service.Application;

namespace AutomotivePartsOrdering.Service.Middleware
{
    public interface IAuthorisationService
    {
        Task<string?> GetAccessTokenAsync(IOptions<ProviderSettings> providerSettings, string scope);
    }

    public class AuthorisationService(IHttpClientWrapper httpClientWrapper) : IAuthorisationService
    {
        private string? _accessToken;
        private DateTime _tokenExpiry;

        public async Task<string?> GetAccessTokenAsync(IOptions<ProviderSettings> providerSettings, string scope)
        {
            // Check if token is still valid
            if (!string.IsNullOrEmpty(_accessToken) && _tokenExpiry > DateTime.UtcNow)
            {
                return _accessToken;
            }

            var contentCollection = new List<KeyValuePair<string, string>>
            {
                new("client_id", providerSettings.Value.ProviderClientId),
                new("client_secret", providerSettings.Value.ProviderClientSecret),
                new("grant_type", providerSettings.Value.ProviderAuthorisationFlow),
                new("scope", scope)
            };

            // Prepare request content
            var requestContent = new FormUrlEncodedContent(contentCollection);

            // Make the request
            var response = await httpClientWrapper.PostAsync(providerSettings.Value.ProviderTokenUrl, requestContent);
            response.EnsureSuccessStatusCode();

            // Parse the token response
            var responseContent = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(responseContent);

            // Cache the token and expiry time
            _accessToken = tokenResponse?.AccessToken;
            _tokenExpiry = DateTime.UtcNow.AddSeconds(tokenResponse!.ExpiresIn - 60);

            return _accessToken;
        }

        private class TokenResponse
        {
            [JsonPropertyName("access_token")] public string? AccessToken { get; init; }

            [JsonPropertyName("expires_in")] public int ExpiresIn { get; init; }
        }
    }
}

