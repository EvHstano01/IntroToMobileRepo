using CommunityToolkit.Mvvm.ComponentModel;
using MobileAppProject.Models;
using MobileAppProject.Services;
using MobileAppProject.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MobileAppProject.Views;

public partial class RecipeListPage : ContentPage
{
    RecipeListViewModel ViewModel => BindingContext as RecipeListViewModel;
    public RecipeListPage(RecipeListViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _ = ViewModel.LoadRecipesAsync();
    }

    void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var recipe = e.CurrentSelection.FirstOrDefault() as RecipeItem;
        if (recipe != null)
        {
            ViewModel.SelectRecipeCommand.Execute(recipe);
            ((CollectionView)sender).SelectedItem = null;
        }
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
