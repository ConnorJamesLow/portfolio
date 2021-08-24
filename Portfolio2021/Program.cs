using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Portfolio2021;
using Portfolio2021.Data;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.Services
    .AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
    .AddScoped<IAppState>(sp => new Store(sp.GetService<HttpClient>()!, sp.GetService<NavigationManager>()!));

await builder.Build().RunAsync();
