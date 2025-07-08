namespace WebAPI.SignalRDTO
{
    public class DashboardDataDto
    {
        public DataCountDto CategoryCounts { get; set; }
        public DataCountDto FoodCounts { get; set; }
        public DataCountDto OrderCounts { get; set; }
        public DataCountDto ReservationCounts { get; set; }
        public decimal DailyRevenue { get; set; }
        public int TestimonialCount { get; set; }
        public decimal TotalCaseAmount { get; set; }
        public int AvaliableTableCount { get; set; }
    }
}
