using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TTTN.TaskManagement.WebApp;
using TTTN.TaskManagement.WebApp.Service;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddTransient<IActionApiServices, ActionApiServices>();
builder.Services.AddTransient<IUserApiServices, UserApiServices>();
builder.Services.AddTransient<IModuleApiServices, ModuleApiServices>();
builder.Services.AddTransient<IRoleApiServices, RoleApiServices>();
builder.Services.AddBlazoredToast();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7079") });

await builder.Build().RunAsync();
