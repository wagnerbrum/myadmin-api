using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Bootstrap = MyAdmin.Infrastructure.Bootstrap;

namespace MyAdmin.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            Bootstrap.Startup.ConfigureServices(
                services,
                "MyAdmin",
                "1.0.0", //pegar versão git
                "Descrição do projeto"
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Bootstrap.Startup.Configure(app, env);
        }
    }
}
