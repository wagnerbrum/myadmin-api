using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            Description = "MyAdmin is a project to training programming",
            Title = "MyAdmin Api",
            Version = "v1",
            Contact = new OpenApiContact()
            {
                Name = "wagnerbrum",
                Url = new Uri("https://github.com/wagnerbrum")
            }
        }));
    }

    public static void ConfigureApplication(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
