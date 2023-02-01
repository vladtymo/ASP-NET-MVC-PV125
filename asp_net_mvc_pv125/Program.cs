using BusinessLogic.Services;
using DataAccess;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connStr = builder.Configuration.GetConnectionString("LocalDb");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ShopDbContext>(opt => opt.UseSqlServer(connStr));

// Add Fluent Validators
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

// Add Custom Services
// Singleton: IoC container will create and share a single instance of a service throughout the application's lifetime.
//builder.Services.AddSingleton<IProductsService, ProductsService>();

// Scoped: IoC container will create an instance of the specified service type once per request and will be shared in a single request.
builder.Services.AddScoped<IProductsService, ProductsService>();

// Transient: The IoC container will create a new instance of the specified service type every time you ask for it.
//builder.Services.AddTransient<IProductsService, ProductsService>();


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
