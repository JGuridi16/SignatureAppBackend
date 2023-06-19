using Newtonsoft.Json;

namespace SignatureApp.Web.Models.GraphAPI
{
    public class SiteListRoot
    {
        [JsonProperty("value")]
        public List<SiteListItem> Value { get; set; } = new List<SiteListItem>();
    }
    public class SiteListItem
    {
        [JsonProperty("createdDateTime")]
        public DateTimeOffset CreatedDateTime { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("eTag")]
        public string? ETag { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("lastModifiedDateTime")]
        public DateTimeOffset LastModifiedDateTime { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("webUrl")]
        public Uri? WebUrl { get; set; }

        [JsonProperty("displayName")]
        public string? DisplayName { get; set; }

        [JsonProperty("createdBy")]
        public CreatedBy? CreatedBy { get; set; }
    }

    public class CreatedBy
    {
        [JsonProperty("user")]
        public User? User { get; set; }
    }

    public class User
    {
        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("displayName")]
        public string? DisplayName { get; set; }
    }
}
