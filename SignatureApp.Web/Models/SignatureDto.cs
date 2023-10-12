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
        [JsonProperty("Reservation")]
        public int ReservationNumber { get; set; }
        public string? Signature { get; set; }
        public string? Address { get; set; }
        public decimal Amount { get; set; }
        public string? Phone { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string? SecurityCode { get; set; }
        public string? ZipCode { get; set; }
        [JsonIgnore]
        public IFormFile? IdentificationPhoto { get; set; }
        [JsonIgnore]
        public IFormFile? CardInfoImage { get; set; }
        [JsonProperty("ImgCustomerID")]
        public string? IdentificationPhotoSerialized { get; set; }
        [JsonProperty("ImgCreditCard")]
        public string? CardInfoImageSerialized { get; set; }
    }

    public class SignatureRoot
    {
        [JsonProperty("fields")]
        public SignatureDto Fields { get; set; } = new SignatureDto();
    }
}