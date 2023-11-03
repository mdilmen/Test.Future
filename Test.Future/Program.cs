using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using Test.Future.Configuration;
using Test.Future.Data;

var builder = WebApplication.CreateBuilder(args);
LogConfiguration(builder);


var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
// Add services to the container.
builder.Services.AddDbContext<FutureContext>(cfg =>
{
    //cfg.UseInMemoryDatabase("myDb");
    cfg.UseSqlServer(connectionString);
});
builder.Services.AddControllersWithViews();
builder.Services.AddServiceRegistration();

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
app.Use(async (context, next) =>
{
    await next();
    if (context.Response.StatusCode == 404)
    {
        context.Request.Path = "/Home/Error";
        await next();
    }
});

// CultureInfo cultureInfo = new CultureInfo("tr");
var supportedCultures = new[] { "tr-TR" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);
app.UseRequestLocalization(localizationOptions);
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



try
{
    Log.Information("Starting web host");
    app.Run();
    return 0;
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
    return 1;
}
finally
{
    Log.CloseAndFlush();
}


static void LogConfiguration(WebApplicationBuilder builder)
{
    Log.Logger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .Enrich.WithProperty("ApplicationName", "Test.Future")
        .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        .MinimumLevel.Override("System.Net.Http.HttpClient", LogEventLevel.Warning)
        .WriteTo.File(new RenderedCompactJsonFormatter(), @"c:/temp/logs/Test.Future/Test.Future_.json", rollingInterval: RollingInterval.Day)
        .CreateLogger();

    builder.Host.UseSerilog();
}

