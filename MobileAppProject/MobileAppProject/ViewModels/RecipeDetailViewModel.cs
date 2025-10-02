using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileAppProject.Models;
using MobileAppProject.Services;
using System.Threading.Tasks;

namespace MobileAppProject.ViewModels
{
    [QueryProperty(nameof(RecipeId), "recipeId")]
    public partial class RecipeDetailViewModel : ObservableObject
    {
        private readonly IRecipeService _service;

        [ObservableProperty]
        private RecipeItem recipe;

        [ObservableProperty]
        private int recipeId;

        public RecipeDetailViewModel(IRecipeService service)
        {
            _service = service;
        }

        partial void OnRecipeIdChanged(int value)
        {
            LoadRecipe(value);
        }

        private async void LoadRecipe(int id)
        {
            if (id <= 0) return;
            Recipe = await _service.GetRecipeByIdAsync(id);
        }
    }
}
