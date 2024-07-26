using MathollDesktopApplication.Entities;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace MathollDesktopApplication.Modules.Recipes.Queries.GetSingleRecipe
{
    public class GetRecipeById
    {
        private readonly int id;

        // Constructor to initialize the id
        public GetRecipeById(int id)
        {
            this.id = id;
        }

        // Instance method to fetch the recipe based on the initialized id
        public async Task<Recipe> GetRecipe()
        {
            Recipe recipe = null;
            using (HttpClient client = new())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync($"http://localhost:8080/uppskriftir/recipe/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        Debug.Write(jsonResponse);
                        recipe = JsonConvert.DeserializeObject<Recipe>(jsonResponse);
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
            }
            return recipe;
        }
    }
}
