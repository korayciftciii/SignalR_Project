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

        public async Task GetAllDashboardData()
        {
            var dashboardData = new DashboardDataDto
            {
                CategoryCounts = new DataCountDto
                {
                    TotalCount = _categoryService.TGetCategoryCount(),
                    ActiveCount = _categoryService.TGetActiveCategoryCount(),
                    PassiveCount = _categoryService.TGetInActiveCategoryCount()
                },
                FoodCounts = new DataCountDto
                {
                    TotalCount = _foodService.TGetFoodCount(),
                    ActiveCount = _foodService.TGetActiveFoodCount(),
                    PassiveCount = _foodService.TGetInActiveFoodCount()
                },
                OrderCounts = new DataCountDto
                {
                    TotalCount = _orderService.TGetOrderCount(),
                    ActiveCount = _orderService.TGetActiveOrderCount(),
                    PassiveCount = _orderService.TGetInActiveOrderCount()
                },
                ReservationCounts = new DataCountDto
                {
                    TotalCount = _reservationService.TGetReservationCount(),
                    ActiveCount = _reservationService.TGetActiveReservationCount(),
                    PassiveCount = _reservationService.TGetInActiveReservationCount()
                },
                DailyRevenue = _orderService.TGetDailyIncome(),
                TestimonialCount = _testimonialService.TGetTestimonialCount(),
                TotalCaseAmount = _moneyCaseService.TGetTotalCaseAmount(),
                AvaliableTableCount = _restaurantTableService.GetAvaliableTableCount()
            };

            await Clients.All.SendAsync("ReceiveAllDashboardData", dashboardData);
        }

    }
}
