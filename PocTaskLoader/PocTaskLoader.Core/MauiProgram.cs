using PocTaskLoader.Core.ViewModels;
using PocTaskLoader.Views.Pages;

namespace PocTaskLoader.Core;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UsePrism(prismAppBuilder => prismAppBuilder
                .RegisterTypes(containerRegistry =>
                {
                    containerRegistry.RegisterServices();
                    containerRegistry.RegisterNavigation();
                    containerRegistry.RegisterHelpers();
                })
                .OnAppStart(navigationService => navigationService.NavigateAsync(nameof(LoginPage))))
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        return builder.Build();
    }



    private static void RegisterHelpers(this IContainerRegistry containerRegistry)
    {
    }

    private static void RegisterServices(this IContainerRegistry containerRegistry)
    {
    }

    private static void RegisterNavigation(this IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<LoginPage, LoginViewModel>();
        containerRegistry.RegisterForNavigation<NavigationPage>();
    }
}
