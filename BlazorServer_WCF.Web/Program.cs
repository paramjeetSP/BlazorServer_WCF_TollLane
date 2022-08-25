using BlazorServer_WCF.Web;
using BlazorServer_WCF.Web.Data;
using BlazorServer_WCF.Web.Pages;
using Radzen;
using ServiceReference1;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<ImageReviewService>();
builder.Services.AddSingleton<GPWS_CoreWebServiceClient>();
builder.Services.AddSingleton<ImageReview>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<UtilsService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddHotKeys();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
