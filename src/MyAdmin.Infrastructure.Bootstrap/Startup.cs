using Serilog;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MyAdmin.Infrastructure.Bootstrap
{
    public static class Startup
    {
        public static void Run(string[] args)
        {
            try
            {
                var builder = WebApplication.CreateBuilder(args);

                ConfigureServices(builder);

                var app = builder.Build();

                ConfigureApplication(app, app.Environment);

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Unhandled exception");
            }
            finally
            {
                Log.Information("Shut down complete");
                Log.CloseAndFlush();
            }
        }

        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            StartupSerilog.ConfigureServices(builder);

            builder.Services.AddCors();

            builder.Services.AddControllers().AddJsonOptions(options => 
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            StartupSwagger.ConfigureServices(builder.Services);
        }

        public static void ConfigureApplication(WebApplication app, IWebHostEnvironment env)
        {
            StartupSerilog.ConfigureApplication(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(policy => policy
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            StartupSwagger.ConfigureApplication(app, env);

            // app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}