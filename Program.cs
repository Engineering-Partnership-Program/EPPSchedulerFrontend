using EPPSchedulerFrontend;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<CookieHandler>();

builder
    .Services.AddHttpClient(
        "EPPSchedulerBackend",
        client =>
        {
            client.BaseAddress = new Uri("https://localhost:7016");
        }
    )
    .AddHttpMessageHandler<CookieHandler>();

// builder.Services.AddScoped(sp =>
// {
//     HttpClient httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7016") };
//     return httpClient;
// });

// builder.Services.AddMudServices();

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopCenter;

    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 10000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});

WebAssemblyHost app = builder.Build();

await app.RunAsync();
