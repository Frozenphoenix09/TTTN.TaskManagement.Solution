using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TTTN.TaskManagement.WebApp;
using TTTN.TaskManagement.WebApp.Service;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddTransient<IActionApiServices, ActionApiServices>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7079") });

await builder.Build().RunAsync();
