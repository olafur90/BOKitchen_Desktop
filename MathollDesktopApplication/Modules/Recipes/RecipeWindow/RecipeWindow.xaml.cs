using MathollDesktopApplication.Entities;
using MathollDesktopApplication.Modules.Recipes.Queries.GetSingleRecipe;
using System.Threading.Tasks;
using System.Windows;

namespace MathollDesktopApplication.Modules.Recipes.RecipeWindow
{
    /// <summary>
    /// Interaction logic for RecipeWindow.xaml
    /// </summary>
    public partial class RecipeWindow : Window
    {
        private readonly int id;
        Recipe recipe;

        /// <summary>
        /// The constructor, instantiates the id variable and initializes the component.
        /// </summary>
        /// <param name="id"></param>
        public RecipeWindow(int id)
        {
            InitializeComponent();
            this.id = id;
            Loaded += RecipeWindow_Loaded;
        }

        /// <summary>
        /// Waits for the Window to be done loading before fetching the recipe.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void RecipeWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await FetchRecipe();
        }

        /// <summary>
        /// Fetches the recipe from the API with the given id
        /// </summary>
        /// <returns>A recipe object matching the requested id</returns>
        public async Task<Recipe> FetchRecipe()
        {
            var instance = new GetRecipeById(id);
            recipe = await instance.GetRecipe();
            
            return recipe;
        }
    }
}
