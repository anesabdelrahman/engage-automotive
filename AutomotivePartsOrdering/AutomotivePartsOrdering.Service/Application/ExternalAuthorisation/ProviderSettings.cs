namespace AutomotivePartsOrdering.Service.Application.ExternalAuthorisation {
    public class ProviderSettings {
        public string ProviderClientId { get; set; } = "";
        public string ProviderClientSecret { get; set; } = "";
        public string ProviderTokenUrl { get; set; } = "";
        public string ProviderAuthorisationFlow { get; set; } = "";
        public string ProviderPartReadScope { get; set; } = "";
        public string ProviderOrderCreateScope { get; set; } = "";
        public string ProviderOrderReadScope { get; set; } = "";
        public string ProviderBrandReadScope { get; set; } = "";
        public string ProviderPartsUrl { get; set; } = "";
        public string ProviderOrderUrl { get; set; } = "";
        public string ProviderBrandUrl { get; set; } = "";
    }
}
