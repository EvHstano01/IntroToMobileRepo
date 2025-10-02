using MobileAppProject.ViewModels;
using MobileAppProject.Models;
using System.Collections.ObjectModel;

namespace MobileAppProject.Views;

public partial class FavouritesPage : ContentPage
{
    FavouritesViewModel ViewModel => BindingContext as FavouritesViewModel;

    public FavouritesPage(ObservableCollection<RecipeItem> favourites)
    {
        InitializeComponent();
        BindingContext = new FavouritesViewModel(favourites);
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
