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

        builder.Services.AddSingleton<IRecipeService, MockRecipeService>();
        builder.Services.AddTransient<RecipeListViewModel>();
        builder.Services.AddTransient<RecipeDetailViewModel>();
        builder.Services.AddTransient<RecipeDetailViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
