using Microsoft.AspNetCore.SignalR;
using Web.DataAccessLayer.Concrete;
using Web.ServiceLayer.Abstract;
using WebAPI.SignalRDTO;

namespace WebAPI.Hubs
{
    public class SignalRHub:Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IFoodService _foodService;
        private readonly IOrderService _orderService;
        private readonly IReservationService _reservationService;
        private readonly ITestimonialService _testimonialService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IRestaurantTableService _restaurantTableService;
        public SignalRHub(ICategoryService categoryService, IFoodService foodService, IOrderService orderService, IReservationService reservationService, ITestimonialService testimonialService, IMoneyCaseService moneyCaseService, IRestaurantTableService restaurantTableService)
        {
            _categoryService = categoryService;
            _foodService = foodService;
            _orderService = orderService;
            _reservationService = reservationService;
            _testimonialService = testimonialService;
            _moneyCaseService = moneyCaseService;
            _restaurantTableService = restaurantTableService;
        }

        public async Task GetCategoryCounts()
        {
           var total =_categoryService.TGetCategoryCount();
            var active = _categoryService.TGetActiveCategoryCount();
            var passive = _categoryService.TGetInActiveCategoryCount();

            var categoryCounts = new DataCountDto
            {
                TotalCount = total,
                ActiveCount = active,
                PassiveCount = passive
            };
            await Clients.All.SendAsync("ReceiveCategoryCounts", categoryCounts);
        }
        public async Task GetFoodCounts()
        {
            var total = _foodService.TGetFoodCount();
            var active = _foodService.TGetActiveFoodCount();
            var passive = _foodService.TGetInActiveFoodCount();

            var foodCounts = new DataCountDto
            {
                TotalCount = total,
                ActiveCount = active,
                PassiveCount = passive
            };

            await Clients.All.SendAsync("ReceiveFoodCounts", foodCounts);
        }
        public async Task GetOrderCounts()
        {
            var total = _orderService.TGetOrderCount();
            var active = _orderService.TGetActiveOrderCount();
            var passive = _orderService.TGetInActiveOrderCount();
            var orderCounts = new DataCountDto
            {
                TotalCount = total,
                ActiveCount = active,
                PassiveCount = passive
            };
            await Clients.All.SendAsync("ReceiveOrderCounts", orderCounts);
        }
        public async Task GetReservationCounts()
        {
            var total=_reservationService.TGetReservationCount();
            var active = _reservationService.TGetActiveReservationCount();
            var passive = _reservationService.TGetInActiveReservationCount();
            var reservationCounts = new DataCountDto
            {
                TotalCount = total,
                ActiveCount = active,
                PassiveCount = passive
            };
             await Clients.All.SendAsync("ReceiveReservationCounts", reservationCounts);
        }
        public async Task GetDailyRevenue()
        {
            var dailyRevenue = _orderService.TGetDailyIncome();
            await Clients.All.SendAsync("ReceiveDailyRevenue", dailyRevenue);
        }
        public async Task GetTestimonialCount()
        {
            var testimonialCount = _testimonialService.TGetTestimonialCount();
            await Clients.All.SendAsync("ReceiveTestimonialCount", testimonialCount);
        }
        public async Task GetTotalCaseAmount()
        {
            var totalCaseAmount = _moneyCaseService.TGetTotalCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalCaseAmount", totalCaseAmount);
        }
        public async Task GetAvaliableTableCount()
        {
            var avaliableTableCount = _restaurantTableService.GetAvaliableTableCount();
            await Clients.All.SendAsync("ReceiveAvaliableTableCount", avaliableTableCount);
        }

    }
}
