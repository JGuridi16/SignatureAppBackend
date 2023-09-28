namespace SignatureApp.Web.Models
{
    public class InsertSharePointListItemDto
    {
        public string? AssetDriveId { get; set; }
        public string? SiteId { get; set; }
        public string? ListId { get; set; }
        public SignatureDto SignatureInfo { get; set; } = new SignatureDto();
    }
}