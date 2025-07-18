using System.Reflection;
using System.Text.Json.Serialization;
using Web.DataAccessLayer.Abstract;
using Web.DataAccessLayer.Concrete;
using Web.DataAccessLayer.EntityFramework;
using Web.ServiceLayer.Abstract;
using Web.ServiceLayer.Concrete;
using Web.ServiceLayer.ValidationRules.BookingValidations;
using Web.ServiceLayer.ValidationRules.ContactValidations;
using Web.ServiceLayer.ValidationRules.TestimonialValidations;
using WebAPI.Extensions;
using WebAPI.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => {
        builder.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed((host) => true).AllowCredentials();
     });
});

builder.Services.AddSignalR();

builder.Services.AddDbContext<ApplicationContext>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddContainerDependencies();
// Add services to the container.

builder.Services.AddValidatorsFromAssemblyContaining<CreateBookingValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateTestimonialValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateContactValidation>();


builder.Services.AddControllersWithViews().AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

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

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<SignalRHub>("/signalrhub");

app.Run();
