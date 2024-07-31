using MathollDesktopApplication.Modules.Recipes.Queries.GetAllRecipes;
using MathollDesktopApplication.Modules.Recipes.RecipeWindow;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Wpf.Ui.Controls;

namespace MathollDesktopApplication
{
    /// <summary>
    /// Interaction logic for RecipeView.xaml
    /// </summary>
    public partial class RecipeView : UserControl
    {
        private const int Columns = 4;
        RecipeDTO[] recipes;
        ProgressRing progressRing;

        public RecipeView()
        {
            InitializeComponent();
            this.SizeChanged += RecipeView_SizeChanged;

            LoadRecipes();

        }

        /// <summary>
        /// Event handler that is triggered whenever the main window is resized.
        /// Adjusts the widths of the buttons to maintain consistent layout.
        /// </summary>
        /// <param name="sender">The source of the event, typically the main window.</param>
        /// <param name="e">Provides data for the SizeChanged event, including the new size of the window.</param>
        private void RecipeView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Adjust button widths when the window size changes
            AdjustButtonWidths();
        }

        /// <summary>
        /// Adjusts the width of the buttons in GridRecipeButtons to be dynamic with window resizing.
        /// </summary>
        private void AdjustButtonWidths()
        {
            // Calculate the width of each button based on the available space
            double totalWidth = GridRecipeButtons.ActualWidth;
            double margins = 5 * 2; // Margin on each side
            double totalMargins = (4 - 1) * margins; // Number of gaps between buttons

            // Width for each button
            double buttonWidth = Math.Abs(Math.Floor((totalWidth - totalMargins) / 4));

            foreach (Wpf.Ui.Controls.Button button in GridRecipeButtons.Children.OfType<Wpf.Ui.Controls.Button>())
            {
                button.Width = buttonWidth;
            }
        }

        private async void LoadRecipes()
        {
            progressRing = new ProgressRing
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Visibility = Visibility.Visible,
                IsIndeterminate = true
            };
            GridRecipeButtons.Children.Add(progressRing);

            progressRing.Visibility = Visibility.Visible;

            recipes = await RecipeCache.GetRecipes();
            PopulateRecipeGrid();
        }

        /// <summary>
        /// Gets all existing recipes from the database with minimum details.
        /// </summary>
        public void PopulateRecipeGrid()
        {
            if (recipes == null || recipes.Length <= 0)
            {
                return;
            }

            // Clear previous content
            GridRecipeButtons.Children.Clear();
            GridRecipeButtons.RowDefinitions.Clear();
            GridRecipeButtons.ColumnDefinitions.Clear();

            if (recipes == null || recipes.Length <= 0) return;

            // Define the columns
            for (int i = 0; i < Columns; i++)
            {
                GridRecipeButtons.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            // Define the rows based on the number of recipes
            int rows = (int)Math.Ceiling((double)recipes.Length / Columns);
            for (int i = 0; i < rows; i++)
            {
                GridRecipeButtons.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            }

            // Add Button elements to the grid
            for (int i = 0; i < recipes.Length; i++)
            {
                Wpf.Ui.Controls.Button temp = new()
                {
                    MinHeight = 100,
                    Margin = new Thickness(5),
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Tag = i
                };

                // Create a TextBlock with text wrapping
                Wpf.Ui.Controls.TextBlock textBlock = new()
                {
                    Text = recipes[i].Name,
                    TextWrapping = TextWrapping.Wrap,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    TextAlignment = TextAlignment.Center
                };

                temp.Content = textBlock;
                temp.Click += Temp_Click;

                int row = i / Columns;
                int column = i % Columns;

                Grid.SetRow(temp, row);
                Grid.SetColumn(temp, column);

                GridRecipeButtons.Children.Add(temp);
            }

            // Adjust button widths
            AdjustButtonWidths();
        }

        /// <summary>
        /// Handles when a recipe button is clicked from the main menu. Will then use the ID of the recipe to fetch the details and populate a RecipeWindow
        /// </summary>
        /// <param name="id"></param>
        private void Temp_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Wpf.Ui.Controls.Button button && button.Tag is int index)
            {
                // Open the RecipeWindow with the recipe ID
                RecipeWindow recipeWindow = new(recipes[index].Id);
                recipeWindow.Show();
            }
        }

        /// <summary>
        /// TODO: TBD
        /// Give option to sort the recipes by date in asc/desc order.
        /// </summary>
        private void SortByDate()
        {
            throw new NotImplementedException();
        }
    }
}
