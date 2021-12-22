using Microsoft.AspNetCore.Builder;
using Serilog;

namespace MyAdmin.Infrastructure.Bootstrap;

public static class StartupSerilog
{
    public static void ConfigureServices(WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateBootstrapLogger();

        Log.Information("Starting up");

        builder
            .Host
            .UseSerilog((context, config) =>
            {
                config.WriteTo.Console();
                config.ReadFrom.Configuration(context.Configuration);
            });
    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {
        app.UseSerilogRequestLogging();
    }
}
