using CommunityToolkit.Mvvm.ComponentModel;
using MobileAppProject.Models;
using MobileAppProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAppProject.ViewModels
{
    [QueryProperty(nameof(RecipeId), "recipeId")]
    [QueryProperty(nameof(RecipeId), "recipeId")]
    public partial class RecipeDetailViewModel : ObservableObject
    {
        private readonly IRecipeService _service;

        [ObservableProperty]
        private RecipeItem recipe;

        [ObservableProperty]
        private bool isBusy;

        public RecipeDetailViewModel(IRecipeService service)
        {
            _service = service;
        }

        string? recipeId;
        public string? RecipeId
        {
            get => recipeId;
            set
            {
                SetProperty(ref recipeId, value);
                // trigger loading when set
                _ = LoadRecipeAsync(value);
            }
        }

        public async Task LoadRecipeAsync(string id)
        {
            if (string.IsNullOrEmpty(id)) return;
            try
            {
                IsBusy = true;
                Recipe = await _service.GetRecipeByIdAsync(id);
            }
            finally { IsBusy = false; }
        }
    }
}
