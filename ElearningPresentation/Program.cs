using Data.Concrete;
using Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    // Þifre gereksinimleri
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;

    // Kullanýcý kilitleme (lockout)
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // Eposta gereksinimleri
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<Context>()
.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    // Configure cookie options if needed
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.LoginPath = "/UserLogin/Login"; // Set your login path
    options.AccessDeniedPath = "/Home/AccessDenied"; // Set your access denied path
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Add this line to enable authentication
app.UseAuthorization();

app.MapControllerRoute(
    name: "login",
    pattern: "UserLogin/Login",
    defaults: new { controller = "UserLogin", action = "Login" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "user",
        pattern: "User/{action=Dashboard}/{id?}",
        defaults: new { controller = "User" });

    endpoints.MapControllerRoute(
        name: "instructor",
        pattern: "Instructor/{action=Index}/{id?}",
        defaults: new { controller = "Instructor" });

    endpoints.MapControllerRoute(
        name: "userLogin",
        pattern: "UserLogin/{action=Login}/{id?}",
        defaults: new { controller = "UserLogin" });

    endpoints.MapControllerRoute(
        name: "course",
        pattern: "Course/{action=Index}/{id?}",
        defaults: new { controller = "Course" });
    endpoints.MapControllerRoute(
    name: "content",
    pattern: "Content/{action=Index}/{id?}",
    defaults: new { controller = "Content" });

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
