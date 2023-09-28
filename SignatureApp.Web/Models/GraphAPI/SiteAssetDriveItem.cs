using Newtonsoft.Json;

namespace SignatureApp.Web.Models.GraphAPI
{
    public class SiteAssetDrivesRoot
    {
        [JsonProperty("value")]
        public List<SiteAssetDriveItem> Value { get; set; } = new List<SiteAssetDriveItem>();
    }
    public class SiteAssetDriveItem
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("webUrl")]
        public Uri? WebUrl { get; set; }

        [JsonProperty("system")]
        public SystemInfo? System { get; set; }
    }

    public class SystemInfo
    {
    }
}
