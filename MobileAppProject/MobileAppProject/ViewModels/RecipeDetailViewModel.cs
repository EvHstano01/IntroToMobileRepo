using CommunityToolkit.Mvvm.ComponentModel;
using MobileAppProject.Models;
using MobileAppProject.Services;

namespace MobileAppProject.ViewModels
{
    [QueryProperty(nameof(RecipeId), "recipeId")]
    public partial class RecipeDetailViewModel : ObservableObject
    {
        private readonly IRecipeService _service;

        [ObservableProperty]
        private int recipeId;

        [ObservableProperty]
        private RecipeItem recipe;

        [ObservableProperty]
        private bool isBusy;

        public RecipeDetailViewModel(IRecipeService service)
        {
            _service = service;
        }

        // This method is called automatically when RecipeId changes due to the [QueryProperty] attribute
        partial void OnRecipeIdChanged(int value)
        {
            _ = LoadRecipeAsync(value);
        }

        public async Task LoadRecipeAsync(int id)
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;
                Recipe = await _service.GetRecipeByIdAsync(id);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
