namespace Web.EntityLayer.Entities
{
    public class Slider
    {
        public int SliderId { get; set; }
        public string SliderTitle { get; set; } = null!;
        public string? SliderDescription { get; set; }
        public string ButtonLabel { get; set; } = "Order Now";
        public string ButtonUrl { get; set; } = "/menu";
        public string ImageUrl { get; set; } = "https://example.com/default-image.jpg";
        public bool FeatureStatus { get; set; } = false;
    }
}
