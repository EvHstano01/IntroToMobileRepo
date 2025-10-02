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
}