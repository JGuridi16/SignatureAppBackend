using Newtonsoft.Json;

namespace SignatureApp.Web.Models.GraphAPI
{
    public class SiteProfile
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("webUrl")]
        public Uri? WebUrl { get; set; }

        [JsonProperty("createdDateTime")]
        public DateTimeOffset CreatedDateTime { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("lastModifiedDateTime")]
        public DateTimeOffset LastModifiedDateTime { get; set; }

        [JsonProperty("displayName")]
        public string? DisplayName { get; set; }
    }
}
