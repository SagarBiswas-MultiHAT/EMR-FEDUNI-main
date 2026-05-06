using EMRSimulation.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Authentication services
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/EmrLogin";
        options.LogoutPath = "/Account/Logout";

        //options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        options.ExpireTimeSpan = TimeSpan.FromDays(1);
        //options.ExpireTimeSpan = TimeSpan.FromDays(30);

        options.SlidingExpiration = true;
    });


builder.Services.AddDataProtection()
    .SetApplicationName("EMR")
    .PersistKeysToFileSystem(new DirectoryInfo("keys"));

// Add Infrastructure services
builder.Services.AddInfrastructure(builder.Configuration); // This line integrates the Infrastructure layer

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
//name: "default",
//pattern: "{controller=Account}/{action=Login}/{id?}");


//name: "default",
//    pattern: "{controller=Account}/{action=EmrLogin}/{id?}");
name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
