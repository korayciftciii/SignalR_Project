using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Web.DataAccessLayer.Concrete;
using Web.DataTransferObject.NotificationDTO;
using Web.DataTransferObject.ReservationDTO;
using Web.DataTransferObject.RestaurantTableDto;
using Web.ServiceLayer.Abstract;
using WebAPI.SignalRDTO;

namespace WebAPI.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly IFoodService _foodService;
        private readonly IOrderService _orderService;
        private readonly IReservationService _reservationService;
        private readonly ITestimonialService _testimonialService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IRestaurantTableService _restaurantTableService;
        private readonly INotificationService _notificationService;

        public SignalRHub(ICategoryService categoryService, IFoodService foodService, IOrderService orderService, IReservationService reservationService, ITestimonialService testimonialService, IMoneyCaseService moneyCaseService, IRestaurantTableService restaurantTableService, IMapper mapper, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _foodService = foodService;
            _orderService = orderService;
            _reservationService = reservationService;
            _testimonialService = testimonialService;
            _moneyCaseService = moneyCaseService;
            _restaurantTableService = restaurantTableService;
            _mapper = mapper;
            _notificationService = notificationService;
        }
        public static int clientCount { get; set; } = 0;
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

        public async Task GetReservationList()
        {
            var values = _mapper.Map<List<ResultReservationDto>>(_reservationService.TGetAll());
            await Clients.All.SendAsync("ReceiveReservationList", values);
        }
        public async Task GetNotificationCounts()
        {
            var notificationCounts = new NotificationCountDto
            {
                UnreadNotificationCount = _notificationService.TGetUnreadNotificationCount(),
                NotificationCount = _notificationService.GetNotificationCount()
            };
            await Clients.All.SendAsync("ReceiveNotificationCount", notificationCounts);
        }
        public async Task GetUnreadNotifications()
        {
            var values = _mapper.Map<List<ResultNotificationDto>>(_notificationService.GetUnreadNotifications());
            if (values != null && values.Count > 0)
            {
                await Clients.All.SendAsync("ReceiveUnreadNotifications", values);
            }
            else
            {
                await Clients.All.SendAsync("ReceiveUnreadNotifications", new List<ResultNotificationDto>());
            }
        }
        public async Task GetNotificationList()
        {
            var values = _mapper.Map<List<ResultNotificationDto>>(_notificationService.TGetAll());
            if (values != null && values.Count > 0)
            {
                await Clients.All.SendAsync("ReceiveNotificationList", values);
            }
            else
            {
                await Clients.All.SendAsync("ReceiveNotificationList", new List<ResultNotificationDto>());
            }
        }
        public async Task GetAvailableTables()
        {
            var values = _mapper.Map<List<ResultRestaurantTableDto>>(_restaurantTableService.TGetAvailableTables());
            if (values != null && values.Count > 0)
            {
                await Clients.All.SendAsync("ReceiveAvailableTables", values);
            }
            else
            {
                await Clients.All.SendAsync("ReceiveAvailableTables", new List<ResultRestaurantTableDto>());
            }
        }
        public async Task GetOccupiedTables()
        {
            var values = _mapper.Map<List<ResultRestaurantTableDto>>(_restaurantTableService.TGetOccupiedTables());
            if (values != null && values.Count > 0)
            {
                await Clients.All.SendAsync("ReceiveOccupiedTables", values);
            }
            else
            {
                await Clients.All.SendAsync("ReceiveOccupiedTables", new List<ResultRestaurantTableDto>());
            }
        }
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("RecieveMessage", user, message);
        }
        public override async Task OnConnectedAsync()
        {
            clientCount=clientCount + 1;
            await Clients.All.SendAsync("RecieveClientCount", clientCount);
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clientCount = clientCount - 1;
            await Clients.All.SendAsync("RecieveClientCount", clientCount);
            await base.OnDisconnectedAsync(exception);
        }
    }
}

