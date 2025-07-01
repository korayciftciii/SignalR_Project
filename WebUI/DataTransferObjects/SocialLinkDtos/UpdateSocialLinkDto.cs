namespace WebUI.DataTransferObjects.SocialLinkDtos
{
    public class UpdateSocialLinkDto
    {
        public int SocialLinkId { get; set; }

        public string PlatformName { get; set; } = null!;
        public string Url { get; set; } = null!;
        public string? IconClass { get; set; }
    }
}
