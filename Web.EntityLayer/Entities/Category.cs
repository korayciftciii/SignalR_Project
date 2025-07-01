namespace Web.EntityLayer.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public bool CategoryStatus { get; set; } = true;

        public List<Food> Foods { get; set; } = new();
    }
}
