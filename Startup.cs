using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.Threading.Tasks;
using workshopFinal.Middleware;
using workshopFinal.Services;

public class Startup
{

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRouting();
        services.AddMvc();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseIISPlatformHandler();

        app.UseStaticFiles();

        var routeBuilder = new RouteBuilder(app);

        routeBuilder.MapGet("", context => context.Response.WriteAsync("Hello from Routing!"));

        app.UseRouter(routeBuilder.Build());
    }
}