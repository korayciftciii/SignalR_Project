using System.Reflection;
using Web.DataAccessLayer.Abstract;
using Web.DataAccessLayer.Concrete;
using Web.DataAccessLayer.EntityFramework;
using Web.ServiceLayer.Abstract;
using Web.ServiceLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationContext>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IAboutDAL, EFAboutDAL>();

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDAL, EFCategoryDAL>();

builder.Services.AddScoped<IDiscountService, DiscountManager>();
builder.Services.AddScoped<IDiscountDAL, EFDiscountDAL>();

builder.Services.AddScoped<IFoodService, FoodManager>();
builder.Services.AddScoped<IFoodDAL, EFFoodDAL>();

builder.Services.AddScoped<IFooterContentService, FooterContentManager>();
builder.Services.AddScoped<IFooterContentDAL, EFFooterContentDAL>();

builder.Services.AddScoped<IOpeningHourService, OpeningHourManager>();
builder.Services.AddScoped<IOpeningHourDAL, EFOpeningHourDAL>();

builder.Services.AddScoped<IReservationService, ReservationManager>();
builder.Services.AddScoped<IReservationDAL, EFReservationDAL>();

builder.Services.AddScoped<ISliderService, SliderManager>();
builder.Services.AddScoped<ISliderDAL, EFSliderDAL>();

builder.Services.AddScoped<ISocialLinkService, SocialLinkManager>();
builder.Services.AddScoped<ISocialLinkDAL, EFSocialLinkDAL>();

builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
builder.Services.AddScoped<ITestimonialDAL, EFTestimonialDAL>();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
