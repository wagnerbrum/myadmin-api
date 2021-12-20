using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace MyAdmin.Infrastructure.Bootstrap
{
    public static class StartupSwagger
    {
        private const string UrlBaseSwagger = "/swagger/v1/swagger.json";
        private const string VersaoSwagger = "v1";

        public static void ConfigureServices(IServiceCollection services, string title, string version, string description)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(VersaoSwagger, new OpenApiInfo { Title = title, Version = version, Description = description });
            });
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint(UrlBaseSwagger, VersaoSwagger));
        }
    }
}
