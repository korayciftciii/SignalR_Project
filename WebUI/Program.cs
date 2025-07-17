using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Web.DataAccessLayer.Concrete;
using Web.EntityLayer.Entities;

var builder = WebApplication.CreateBuilder(args);
var requireAuthorizePolicy=new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

// Add services to the container.
builder.Services.AddDbContext<ApplicationContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<ApplicationContext>();
builder.Services.AddControllersWithViews(opt => { 
opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy)); // Apply authorization globally
});
builder.Services.ConfigureApplicationCookie(opts => { opts.LoginPath = "/Login/index"; });
builder.Services.AddHttpClient();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/Error/{0}");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapAreaControllerRoute(
    name: "admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
