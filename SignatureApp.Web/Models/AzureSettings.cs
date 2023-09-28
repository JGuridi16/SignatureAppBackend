namespace SignatureApp.Web.Models
{
    public class AzureSettings
    {
        public string TokenEndpoint { get; set; } = string.Empty;
        public string GrantType { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
        public string TenantId { get; set; } = string.Empty;
        public string ClientSecret { get; set; } = string.Empty;
        public string Scope { get; set; } = string.Empty;
        public string TenantName { get; set; } = string.Empty;
        public string SiteName { get; set; } = string.Empty;
        public string DriveName { get; set; } = string.Empty;
        public string ListName { get; set; } = string.Empty;
    }
}