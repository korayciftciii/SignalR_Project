namespace Web.EntityLayer.Entities
{
    public class Food
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public bool FoodStatus { get; set; } = true;

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
