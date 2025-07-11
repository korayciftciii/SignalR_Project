namespace WebUI.DataTransferObjects.RestaurantTableDto
{
    public class CreateRestaurantTableDto
    {
        public string TableNumber { get; set; } 
        public int Capacity { get; set; }

        public bool IsAvailable { get; set; } = true;
    }
}
