using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SuperHeroDB.Client.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SuperHeroDB.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<ISuperHeroService, SuperHeroService>();

            await builder.Build().RunAsync();
        }
    }
}
