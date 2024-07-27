using MathollDesktopApplication.Modules.Recipes.Queries.GetAllRecipesRequest;
using System.Threading.Tasks;

namespace MathollDesktopApplication.Modules.Recipes.Queries.GetAllRecipes
{
    public static class RecipeCache
    {
        private static RecipeDTO[] cachedRecipes;

        public static async Task<RecipeDTO[]> GetRecipes()
        {
            if (cachedRecipes == null)
            {
                cachedRecipes = await GetAllRecipeDTOs.GetRecipes();
            }
            return cachedRecipes;
        }

        public static void ClearCache()
        {
            cachedRecipes = null;
        }
    }
}
