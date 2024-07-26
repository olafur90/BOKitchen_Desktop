using MathollDesktopApplication.Entities;
using MathollDesktopApplication.Modules.Recipes.Queries.GetSingleRecipe;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wpf.Ui.Controls;

namespace MathollDesktopApplication.Modules.Recipes.RecipeWindow
{
    /// <summary>
    /// Interaction logic for RecipeWindow.xaml
    /// </summary>
    public partial class RecipeWindow : Window
    {
        private readonly int id;
        Recipe recipe;
        public RecipeWindow(int id)
        {
            InitializeComponent();
            this.id = id;
            Loaded += RecipeWindow_Loaded;
        }

        private async void RecipeWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await FetchRecipe();
        }

        public async Task<Recipe> FetchRecipe()
        {
            var instance = new GetRecipeById(id);
            recipe = await instance.GetRecipe();
            System.Windows.MessageBox.Show(recipe.ToString());
            return recipe;
        }
    }
}
