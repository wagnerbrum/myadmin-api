using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace MyAdmin.Infrastructure.Bootstrap;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
public static class StartupSwagger
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(setup => setup.SwaggerDoc("v1", new OpenApiInfo()
        {
            Description = "Todo web api implementation using Minimal Api in Asp.Net Core",
            Title = "Todo Api",
            Version = "v1",
            Contact = new OpenApiContact()
            {
                Name = "anuraj",
                Url = new Uri("https://dotnetthoughts.net")
            }
        }));
    }
}
