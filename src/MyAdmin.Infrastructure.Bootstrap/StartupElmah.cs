using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MyAdmin.Infrastructure.Bootstrap;

public static class StartupElmah
{
    public static void ConfigureServices(IServiceCollection services)
    {
        // Change URL Path
        // services.AddElmah(options => options.Path = "you_path_here");
    }

    public static void ConfigureApplication(IApplicationBuilder app, IWebHostEnvironment env)
    {
        
    }
}
