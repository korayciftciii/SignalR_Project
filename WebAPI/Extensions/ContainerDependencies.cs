using Web.DataAccessLayer.Abstract;
using Web.DataAccessLayer.EntityFramework;
using Web.ServiceLayer.Abstract;
using Web.ServiceLayer.Concrete;

namespace WebAPI.Extensions
{
    public static class ContainerDependencies
    {
        public static void AddContainerDependencies(this IServiceCollection services)
        {

            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutDAL, EFAboutDAL>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDAL, EFCategoryDAL>();

           services.AddScoped<IDiscountService, DiscountManager>();
            services.AddScoped<IDiscountDAL, EFDiscountDAL>();

            services.AddScoped<IFoodService, FoodManager>();
            services.AddScoped<IFoodDAL, EFFoodDAL>();

            services.AddScoped<IFooterContentService, FooterContentManager>();
            services.AddScoped<IFooterContentDAL, EFFooterContentDAL>();

            services.AddScoped<IOpeningHourService, OpeningHourManager>();
            services.AddScoped<IOpeningHourDAL, EFOpeningHourDAL>();

            services.AddScoped<IReservationService, ReservationManager>();
            services.AddScoped<IReservationDAL, EFReservationDAL>();

            services.AddScoped<ISliderService, SliderManager>();
            services.AddScoped<ISliderDAL, EFSliderDAL>();

            services.AddScoped<ISocialLinkService, SocialLinkManager>();
            services.AddScoped<ISocialLinkDAL, EFSocialLinkDAL>();

            services.AddScoped<ITestimonialService, TestimonialManager>();
            services.AddScoped<ITestimonialDAL, EFTestimonialDAL>();

            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IOrderDAL, EFOrderDAL>();

            services.AddScoped<IOrderDetailService, OrderDetailManager>();
            services.AddScoped<IOrderDetailDAL, EFOrderDetailDAL>();

            services.AddScoped<IMoneyCaseDAL, EFMoneyCaseDAL>();
            services.AddScoped<IMoneyCaseService, MoneyCaseManager>();

            services.AddScoped<IRestaurantTableDAL, EFRestaurantTableDAL>();
            services.AddScoped<IRestaurantTableService, RestaurantTableManager>();

            services.AddScoped<IBasketDAL, EFBasketDAL>();
            services.AddScoped<IBasketService, BasketManager>();

            services.AddScoped<INotificationDAL, EFNotificationDAL>();
            services.AddScoped<INotificationService, NotificationManager>();

            services.AddScoped<IContactDAL, EFContactDAL>();
            services.AddScoped<IContactService, ContactManager>();

        }
    }
}