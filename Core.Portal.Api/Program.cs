using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Core.Portal.Infrastructure;
using Core.Portal.Infrastructure.SqlServerDatabase.Contexts;
using Core.Portal.Application;
using System.Text.Json.Serialization;
using NLog.Web;
using Core.Portal.Application.Services.Middlewares;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;

var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
try
{
    var builder = WebApplication.CreateBuilder(args);

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(LogLevel.Trace);
    builder.Logging.AddDebug();
    builder.Logging.AddConsole();//for hosting lifetime messages, see https://github.com/NLog/NLog.Web/wiki/Hosting-Lifetime-Startup-Messages
    builder.Host.UseNLog();

    // Add services to the container.
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    //builder.Services.AddAuthentication().AddIdentityServerJwt();

    builder.Services.AddControllersWithViews(options =>
    {
        var cacheProfiles = builder.Configuration
                .GetSection("CacheProfiles")
                .GetChildren();
        foreach (var cacheProfile in cacheProfiles)
        {
            options.CacheProfiles
            .Add(cacheProfile.Key,
            cacheProfile.Get<CacheProfile>());
        }
    }).AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });

    builder.Services.AddRazorPages();

    builder.Services.AddHttpContextAccessor();
    builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

    builder.Services.AddApiVersioning(o =>
    {
        o.AssumeDefaultVersionWhenUnspecified = true;
        o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
        o.ReportApiVersions = true;
        o.ApiVersionReader = ApiVersionReader.Combine(
            new QueryStringApiVersionReader("api-version"),
            new HeaderApiVersionReader("X-Version"),
            new MediaTypeApiVersionReader("ver"));
    });

    builder.Services.AddResponseCaching();

    builder.AddInfrastructure();
    builder.AddApplication();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    app.UseSecurityHeaders(policyCollection =>
        policyCollection.AddDefaultSecurityHeaders()
            .AddPermissionsPolicy(policyBuilder =>
            {
                policyBuilder.AddAccelerometer().None();
                policyBuilder.AddAmbientLightSensor().None();
                policyBuilder.AddAutoplay().Self();
                policyBuilder.AddCamera().None();
                policyBuilder.AddEncryptedMedia().Self();
                policyBuilder.AddFullscreen().All();
                policyBuilder.AddGeolocation().None();
                policyBuilder.AddGyroscope().None();
                policyBuilder.AddMagnetometer().None();
                policyBuilder.AddMicrophone().None();
                policyBuilder.AddMidi().None();
                policyBuilder.AddPayment().None();
                policyBuilder.AddPictureInPicture().None();
                policyBuilder.AddSpeaker().None();
                policyBuilder.AddSyncXHR().None();
                policyBuilder.AddUsb().None();
                policyBuilder.AddVR().None();
            }
            ));

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseMigrationsEndPoint();
    }
    else
    {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseMiddleware<ErrorHandlerMiddleware>();


    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");
    app.UseResponseCaching();
    app.MapRazorPages();

    app.MapFallbackToFile("index.html");

    app.Run();
}
catch (Exception exception)
{
    //NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}