using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Bulma;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Tafels.Services;

namespace Tafels;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.Services
            .AddBlazorise(options => { options.Immediate = true; })
            .AddBulmaProviders()
            .AddFontAwesomeIcons();

        builder.RootComponents.Add<App>("#app");

        builder.Services.AddScoped(
            sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        builder.Services.AddSingleton<SumService>();
        builder.Services.AddScoped<UserService>();
        builder.Services.AddBlazoredLocalStorage();

        await builder.Build().RunAsync();
    }
}
