using IMS.Plugins.InMemory;
using IMS.UseCases.Inventories;
using IMS.UseCases.PluginInterfaces;
using IMS.CoreBusiness;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using IMS.WebApp.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddSingleton<IInventoryRepository, InventoryRepository>();

builder.Services.AddTransient<IViewInventoriesByNameUseCase, ViewInventoriesByNameUseCase>();

builder.Services.AddTransient<IAddInventoryUseCase, AddInventoryUseCase>();

builder.Services.AddTransient<IEditInventoryUseCase, EditInventoryUseCase>();

builder.Services.AddTransient<IViewInventoryByIdUseCase, ViewInventoryByIdUseCase>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
