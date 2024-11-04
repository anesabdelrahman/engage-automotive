namespace AutomotivePartsOrdering.Service.Application.ExternalAuthorisation {
    public class ProviderSettings {
        public string PartProviderClientId { get; set; } = "";
        public string PartProviderClientSecret { get; set; } = "";
        public string PartProviderTokenUrl { get; set; } = "";
        public string PartProviderAuthorisationFlow { get; set; } = "";
        public string ProviderPartReadScope { get; set; } = "";
        public string ProviderOrderCreateScope { get; set; } = "";
        public string ProviderOrderReadScope { get; set; } = "";
        public string ProviderBrandReadScope { get; set; } = "";
        public string ProviderPartsUrl { get; set; } = "";
        public string ProviderOrderUrl { get; set; } = "";
        public string ProviderBrandUrl { get; set; } = "";
    }
}
