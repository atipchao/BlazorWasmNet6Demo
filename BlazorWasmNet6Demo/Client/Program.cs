global using BlazorWasmNet6Demo.Shared;
global using System.Net.Http.Json;
global using BlazorWasmNet6Demo.Client.Services.ProductService;
using BlazorWasmNet6Demo.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorWasmNet6Demo.Client.Services.CategoryService;
using Blazored.LocalStorage;
using BlazorWasmNet6Demo.Client.Services.CartService;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
// Add ProductService
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();


await builder.Build().RunAsync();
