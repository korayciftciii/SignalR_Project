namespace WebUI.DataTransferObjects.BasketDtos
{
    public class CreateBasketDto
    {
        public int FoodId { get; set; }
        public int Count { get; set; } = 1;
        public int RestaurantTableId { get; set; }
    }
}
