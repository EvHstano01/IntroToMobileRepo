using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileAppProject.Services;
using MobileAppProject.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using MobileAppProject.Views;
using System;

namespace MobileAppProject.ViewModels
{
    public partial class RecipeListViewModel : ObservableObject
    {
        private readonly IRecipeService _service;

        private List<RecipeItem> _allRecipes = new();

        [ObservableProperty]
        private ObservableCollection<RecipeItem> recipes = new();

        [ObservableProperty]
        private ObservableCollection<RecipeItem> favourites = new();

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private string searchQuery = string.Empty;

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

                _allRecipes = items?.ToList() ?? new List<RecipeItem>();
                Recipes = new ObservableCollection<RecipeItem>(_allRecipes);
            }
            finally
            {
                IsBusy = false;
            }
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

            var index = Recipes.IndexOf(recipe);
            if (index >= 0)
            {
                Recipes[index] = recipe;
            }

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

        // Search command
        [RelayCommand]
        public void Search()
        {
            var q = (SearchQuery ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(q))
            {
                Recipes = new ObservableCollection<RecipeItem>(_allRecipes);
                return;
            }

            q = q.ToLowerInvariant();

            var filtered = _allRecipes.Where(r =>
                (!string.IsNullOrEmpty(r.Title) && r.Title.ToLowerInvariant().Contains(q))
                || (!string.IsNullOrEmpty(r.ShortDescription) && r.ShortDescription.ToLowerInvariant().Contains(q))
                || (r.Ingredients != null && r.Ingredients.Any(i => i?.ToLowerInvariant().Contains(q) == true))
            ).ToList();

            Recipes = new ObservableCollection<RecipeItem>(filtered);
        }

        // Live search!
        partial void OnSearchQueryChanged(string oldValue, string newValue)
        {
            Search();
        }
    }
}
