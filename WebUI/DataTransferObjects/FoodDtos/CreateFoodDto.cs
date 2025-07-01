namespace WebUI.DataTransferObjects.FoodDtos
{
    public class CreateFoodDto
    {
        public string FoodName { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public bool FoodStatus { get; set; } = true;
        public int CategoryId { get; set; }
    }
}
