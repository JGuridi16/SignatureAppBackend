namespace SignatureApp.Web.Models
{
    public class AppSettings
    {
        public string[] AllowedOrigins { get; set; } = Array.Empty<string>();
        public string ApiKey { get; set; } = string.Empty;
        public string SharePointUrl { get; set; } = string.Empty;
        public string SiteProfileEndpoint { get; set; } = string.Empty;
        public string SiteListsEndpoint { get; set; } = string.Empty;
        public string SiteAssetsEndpoint { get; set; } = string.Empty;
        public string SiteInsertItemEndpoint { get; set; } = string.Empty;
        public string SiteInsertDriveItemEndpoint { get; set; } = string.Empty;
    }
}