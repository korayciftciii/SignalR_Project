namespace WebUI.DataTransferObjects.DiscountDtos
{
    public class CreateDiscountDto
    {
        public int DiscountId { get; set; }
        public string DiscountTitle { get; set; } = null!;
        public string? Description { get; set; }
        public int PercentageOfDiscount { get; set; }
        public string? ImageUrl { get; set; }
        public bool DiscountStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
