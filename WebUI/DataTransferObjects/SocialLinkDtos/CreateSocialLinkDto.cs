namespace WebUI.DataTransferObjects.SocialLinkDtos
{
    public class CreateSocialLinkDto
    {
   
        public string PlatformName { get; set; } = null!;
        public string Url { get; set; } = null!;
        public string? IconClass { get; set; }
    }
}
