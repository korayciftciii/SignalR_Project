namespace WebUI.DataTransferObjects.SocialLinkDtos
{
    public class ResultSocialLinkDto
    {
        public int SocialLinkId { get; set; }

        public string PlatformName { get; set; } = null!;
        public string Url { get; set; } = null!;
        public string? IconClass { get; set; }
    }
}
