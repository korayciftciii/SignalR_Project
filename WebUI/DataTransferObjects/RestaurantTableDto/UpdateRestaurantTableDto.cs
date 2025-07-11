namespace WebUI.DataTransferObjects.RestaurantTableDto
{
    public class UpdateRestaurantTableDto
    {
        public int RestaurantTableId { get; set; }
        public string TableNumber { get; set; } 
        public int Capacity { get; set; }

        public bool IsAvailable { get; set; }
    }
}
