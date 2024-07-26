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

        /// <summary>
        /// Initializes a new instance of the <see cref="GetRecipeById"/> class with the specified recipe ID.
        /// </summary>
        /// <param name="id">The unique identifier of the recipe to be fetched.</param>
        public GetRecipeById(int id)
        {
            this.id = id;
        }

        /// <summary>
        /// Asynchronously fetches the recipe based on the initialized id.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation, with a Recipe object as the result if the fetch is successful; otherwise, null.</returns>
        /// <remarks>
        /// This method sends an HTTP GET request to the specified endpoint to retrieve the recipe data.
        /// If the request is successful, the response is deserialized into a Recipe object.
        /// Handles HttpRequestException for network-related errors and general Exception for other unforeseen errors.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when there is an issue with the HTTP request (e.g., network error).</exception>
        /// <exception cref="Exception">Thrown when an unexpected error occurs during the operation.</exception>
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
