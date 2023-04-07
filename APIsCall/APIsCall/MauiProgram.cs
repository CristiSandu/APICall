using APIsCall.Services;
using APIsCall.ViewModels;
using APIsCall.Views;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace APIsCall;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainPageViewModel>();

        builder.Services.AddSingleton<InfoPage>();
        builder.Services.AddSingleton<InfoPageViewModel>();

        builder.Services.AddSingleton<WeatherPage>();
        builder.Services.AddSingleton<WeatherPageViewModel>();

        builder.Services.AddSingleton<IHttpService, HttpService>();

        return builder.Build();
    }
}
