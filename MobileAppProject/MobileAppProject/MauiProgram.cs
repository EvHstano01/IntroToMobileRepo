using Microsoft.Extensions.Logging;
using MobileAppProject.Services;
using MobileAppProject.ViewModels;
using MobileAppProject.Views;

namespace MobileAppProject;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<HttpClient>(serviceProvider =>
        {
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://recipe-food-nutrition.p.rapidapi.com/"),
                Timeout = TimeSpan.FromSeconds(30)
            };

            httpClient.DefaultRequestHeaders.Add("User-Agent",
                $"MyRecipeApp/1.0 ({DeviceInfo.Platform} {DeviceInfo.VersionString})");

            return httpClient;
        });
        builder.Services.AddTransient<RecipeListPage>();
        builder.Services.AddTransient<RecipeDetailPage>();
        builder.Services.AddTransient<FavouritesPage>();
		builder.Services.AddSingleton<SpoonacularAPIService>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
