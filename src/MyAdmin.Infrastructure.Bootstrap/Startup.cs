using ElmahCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MyAdmin.Infrastructure.Bootstrap
{
    public class Startup
    {
        public static void ConfigureServices(
            IServiceCollection services,
            // IConfiguration configuration,
            // ILoggerFactory loggerFactory,
            string title,
            string version,
            string description
        )
        {
            StartupSwagger.ConfigureServices(services, title, version, description);

            services.AddElmah();
            services.AddCors();
            services.AddControllers();
        }
        
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseCors(policy => policy
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseElmah();

            app.UseRouting();

            if(env.IsDevelopment()) 
            {
                StartupSwagger.Configure(app);
            }

            app.UseAuthentication();
            app.UseAuthorization();

            // app.UseHttpsRedirection();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
