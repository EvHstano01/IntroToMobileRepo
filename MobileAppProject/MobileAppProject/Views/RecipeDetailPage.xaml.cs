using MobileAppProject.ViewModels;

namespace MobileAppProject.Views;

public partial class RecipeDetailPage : ContentPage
{
    public RecipeDetailViewModel? ViewModel => BindingContext as RecipeDetailViewModel;
    public RecipeDetailPage(RecipeDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private void OnBackClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void OnToggleThemeClicked(object sender, EventArgs e)
    {
        var app = Application.Current;
        if (app != null)
        {
            var currentTheme = app.UserAppTheme;
            app.UserAppTheme = currentTheme == AppTheme.Light ? AppTheme.Dark : AppTheme.Light;
        }
    }
}