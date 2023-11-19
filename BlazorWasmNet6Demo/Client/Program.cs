global using BlazorWasmNet6Demo.Shared;
global using System.Net.Http.Json;
global using BlazorWasmNet6Demo.Client.Services.ProductService;
using BlazorWasmNet6Demo.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
// Add ProductService
builder.Services.AddScoped<IProductService, ProductService>();


await builder.Build().RunAsync();
