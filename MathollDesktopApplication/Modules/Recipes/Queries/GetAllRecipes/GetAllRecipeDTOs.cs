using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MathollDesktopApplication.Modules.Recipes.Queries.GetAllRecipesRequest
{
    public static class GetAllRecipeDTOs
    {
        public static async Task<RecipeDTO[]> GetRecipes()
        {
            RecipeDTO[] recipes = null;
            HttpClient client = new();

            try
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:8080/uppskriftir/minimum/");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Debug.Write(jsonResponse);
                    recipes = JsonConvert.DeserializeObject<RecipeDTO[]>(jsonResponse);
                }
            }
            catch (HttpRequestException e)
            {
                // Handle request exception (e.g., network error)
                Console.WriteLine($"Request error: {e.Message}");
            }
            catch (Exception e)
            {
                // Handle other possible exceptions
                Console.WriteLine($"Unexpected error: {e.Message}");
            }
            finally
            {
                client.Dispose();
            }

            return recipes;
        }
    }
}