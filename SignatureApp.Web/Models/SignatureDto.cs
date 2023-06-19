using Newtonsoft.Json;

namespace SignatureApp.Web.Models
{
    public class SignatureDto
    {
        public string? Title { get => Name; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? CreditCard { get; set; }
        public int Reservation { get; set; }
        public string? Signature { get; set; }
    }

    public class SignatureRoot
    {
        [JsonProperty("fields")]
        public SignatureDto Fields { get; set; } = new SignatureDto();
    }
}