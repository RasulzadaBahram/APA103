using FrontToBackSqlConnection.Data;
using FrontToBackSqlConnection.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<AppDbContext>(opt =>
//{
//    opt.UseSqlServer("Server=.\\SQLEXPRESS;Database=FrontToBackDb;Trusted_Connection=True;TrustServerCertificate=True");
//});
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("default")));
builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
    opt.Password.RequireNonAlphanumeric = true;
    opt.Password.RequiredLength = 8;
    opt.User.RequireUniqueEmail = true;
    opt.Lockout.MaxFailedAccessAttempts = 3;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);

}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
        name: "admin",
        pattern: "{area:exists}/{controller=dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();