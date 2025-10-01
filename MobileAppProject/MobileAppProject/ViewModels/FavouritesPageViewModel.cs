using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileAppProject.Models;
using System.Collections.ObjectModel;

namespace MobileAppProject.ViewModels;

public partial class FavouritesPageViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<RecipeItem> favourites;

    public FavouritesPageViewModel(ObservableCollection<RecipeItem> favourites)
    {
        Favourites = favourites;
    }

    [RelayCommand]
    public async Task SelectRecipe(RecipeItem recipe)
    {
        if (recipe == null) return;
        await Shell.Current.GoToAsync($"RecipeDetailPage?recipeId={recipe.Id}");
    }
}
