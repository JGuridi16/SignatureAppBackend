namespace SignatureApp.Web.Models
{
    public class UploadSharePointFileDto
    {
        public string? AssetDriveId { get; set; }
        public string? ListId { get; set; }
        public string? SavedFileName { get; set; }
        public IFormFile? File { get; set; }
    }
}