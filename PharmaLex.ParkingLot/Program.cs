using Core.Services;
using Data;
using Data.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
AddApiServices(builder);

var app = builder.Build();
ConfigureHTTPRequestPipeline(app);

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = scope.ServiceProvider.GetService<DataContext>();
    DataSeeder.SeedCategories(context);
    DataSeeder.SeedDiscounts(context);
}

app.Run();


static void AddApiServices(WebApplicationBuilder builder)
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddControllersWithViews();
    builder.Services.AddDbContext<DataContext>(
        options => options
        .UseSqlServer(
            builder.Configuration.GetConnectionString("Database"))
        );

    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddScoped<IParkingService, ParkingService>();
}

static void ConfigureHTTPRequestPipeline(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    if (!app.Environment.IsDevelopment())
    {
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
    app.MapFallbackToFile("index.html");
    app.UseStaticFiles();
    app.UseRouting();
}