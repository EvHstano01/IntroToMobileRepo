using MobileAppProject.Models;

namespace MobileAppProject.Services
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeItem>> GetAllRecipesAsync();
        Task<RecipeItem?> GetRecipeByIdAsync(int id);
        // future add: Task Add/Update/Delete...

        //public async Task AddRecipeAsync(RecipeItem recipe)
        //{
        // Not implemented yet
        //}

        //public async Task UpdateRecipeAsync(RecipeItem recipe)
        //{
        // Not implemented yet
        //}

        //public async Task DeleteRecipeAsync(string id)
        //{
        // Not implemented yet
        //}
    }

}
