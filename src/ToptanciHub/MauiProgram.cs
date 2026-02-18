using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using ToptanciHub.Services;
using ToptanciHub.ViewModels;
using ToptanciHub.Views;

namespace ToptanciHub;

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

        // Register Services (Singleton)
        builder.Services.AddSingleton<DatabaseService>();
        builder.Services.AddSingleton<AuthService>();

        // Register ViewModels (Transient)
        builder.Services.AddTransient<MainViewModel>();

        // Register Views (Transient)
        builder.Services.AddTransient<MainPage>();

        return builder.Build();
    }
}
