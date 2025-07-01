namespace WebUI.DataTransferObjects.CategoryDtos
{
    public class UpdateCategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public bool CategoryStatus { get; set; }
    }
}
