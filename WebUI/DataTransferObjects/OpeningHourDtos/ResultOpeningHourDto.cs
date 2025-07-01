namespace WebUI.DataTransferObjects.OpeningHourDtos
{
    public class ResultOpeningHourDto
    {
        public int OpeningHourId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public bool IsClosed { get; set; }
        public TimeSpan? OpenTime { get; set; }
        public TimeSpan? CloseTime { get; set; }
    }
}
