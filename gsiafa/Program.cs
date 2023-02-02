using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using gsiafa.Data;
using gsiafa.Configuration;
using gsiafa.Configuration.Identity.IdentityPolicy;
using gsiafa.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("gsiafaContextConnection") ?? throw new InvalidOperationException("Connection string 'gsiafaContextConnection' not found.");

builder.Services.AddDbContext<gsiafaContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<gsiafaContext>();
builder.Services.AddTransient<IPasswordValidator<User>, CustomPasswordPolicy>();

// Add services to the container.
builder.Services
    .AddControllersWithViews()
    .AddRazorRuntimeCompilation();

builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(3652);
    opt.Lockout.MaxFailedAccessAttempts = 5;

    /*Plese do not set any of the below to true
     * these have been ovverride and so
     * any change(s) to password requirements must be done in the 
     * derive class CustomPasswordPolicy under configuration folder.*/
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireDigit = false;
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
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
