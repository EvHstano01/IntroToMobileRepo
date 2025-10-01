using MobileAppProject.ViewModels;
using MobileAppProject.Models;
using System.Collections.ObjectModel;

namespace MobileAppProject.Views;

public partial class FavouritesPage : ContentPage
{
    FavouritesPageViewModel ViewModel => BindingContext as FavouritesPageViewModel;

    public FavouritesPage(ObservableCollection<RecipeItem> favourites)
    {
        InitializeComponent();
        BindingContext = new FavouritesPageViewModel(favourites);
    }

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var recipe = e.CurrentSelection.FirstOrDefault() as RecipeItem;
        if (recipe != null)
        {
            ViewModel.SelectRecipeCommand.Execute(recipe);
            ((CollectionView)sender).SelectedItem = null;
        }
    }

    private void OnBackClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}
