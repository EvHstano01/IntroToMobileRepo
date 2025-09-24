using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileAppProject.Models;
using MobileAppProject.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MobileAppProject.ViewModels
{
    public partial class RecipeListViewModel : ObservableObject
    {
        private readonly IRecipeService _service;

        [ObservableProperty]
        private ObservableCollection<RecipeItem> recipes = new();

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
        public async Task SelectRecipeAsync(RecipeItem recipe)
        {
            if (recipe == null) return;
            // pass id
            await Shell.Current.GoToAsync($"recipedetail?recipeId={Uri.EscapeDataString(recipe.Id)}");
        }
    }
}
