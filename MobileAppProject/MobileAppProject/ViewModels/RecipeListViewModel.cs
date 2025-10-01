using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileAppProject.Services;
using MobileAppProject.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MobileAppProject.Views;

namespace MobileAppProject.ViewModels
{
    public partial class RecipeListViewModel : ObservableObject
    {
        private readonly IRecipeService _service;

        [ObservableProperty]
        private ObservableCollection<RecipeItem> recipes = new();

        [ObservableProperty]
        private ObservableCollection<RecipeItem> favourites = new();

        [ObservableProperty]
        private bool isBusy;

        public RecipeListViewModel(IRecipeService service)
        {
            _service = service;
        }

        [RelayCommand]
        public async Task LoadRecipesAsync()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                var items = await _service.GetAllRecipesAsync();
                Recipes = new ObservableCollection<RecipeItem>(items);
            }
            finally { IsBusy = false; }
        }

        [RelayCommand]
        public async Task SelectRecipe(RecipeItem? recipe)
        {
            if (recipe?.Id == null) return;
            await Shell.Current.GoToAsync($"{nameof(RecipeDetailPage)}?recipeId={recipe.Id.Value}");
        }

        [RelayCommand]
        public void ToggleFavourite(RecipeItem recipe)
        {
            if (recipe == null) return;

            recipe.IsFavourite = !recipe.IsFavourite;

            if (recipe.IsFavourite)
            {
                if (!Favourites.Contains(recipe))
                    Favourites.Add(recipe);
            }
            else
            {
                if (Favourites.Contains(recipe))
                    Favourites.Remove(recipe);
            }
        }
    }
}
