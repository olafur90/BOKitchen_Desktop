using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MathollDesktopApplication.Modules.Recipes.Queries.GetAllRecipesRequest;
using MathollDesktopApplication.Modules.Recipes.RecipeWindow;
using Wpf.Ui.Controls;

namespace MathollDesktopApplication
{
    /// <inheritdoc />
    public partial class MainWindow : FluentWindow
    {
        private const int Columns = 4;
        RecipeDTO[] recipes;

        /// <inheritdoc />
        public MainWindow()
        {
            InitializeComponent();
            this.SizeChanged += MainWindow_SizeChanged;
            CheckLoginStatusAsync();
            GetAllRecipesForFrontPage();
        }

        /// <summary>
        /// Event handler that is triggered whenever the main window is resized.
        /// Adjusts the widths of the buttons to maintain consistent layout.
        /// </summary>
        /// <param name="sender">The source of the event, typically the main window.</param>
        /// <param name="e">Provides data for the SizeChanged event, including the new size of the window.</param>
        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
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

        /// <summary>
        /// Gets all existing recipes from the database with minimum details.
        /// </summary>
        /// TODO: Only get the basic details for the recipes. Only get all the details when the recipe has been clicked and loaded into RecipeWindow
        /// TODO: So, basically should be calling something like GetRecipesShort or something like that, and later call GetRecipeWithDetail when clicked.
        public async void GetAllRecipesForFrontPage()
        {
            recipes = await GetAllRecipeDTOs.GetRecipes();

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
                Debug.WriteLine($"Button clicked with index: {index}");

                // Retrieve the recipe ID or other relevant data using the index
                // Assuming you have access to the recipes array here
                // var recipeId = recipes[index].Id;

                // Open the RecipeWindow with the recipe ID
                RecipeWindow recipeWindow = new RecipeWindow(recipes[index].Id);
                recipeWindow.Show();
            }
            //RecipeWindow recipeWindow = new(id);
            //recipeWindow.Show();
        }

        /// <summary>
        /// Checks the current login status of the user. 
        /// If the user is not logged in, hides the current window and initiates the login process.
        /// Once the user is logged in, retrieves the user's name and email, then shows the window.
        /// </summary>
        /// <returns>
        /// This is an asynchronous method that returns a Task representing the ongoing login operation.
        /// </returns>
        /// <remarks>
        /// This method uses the AuthService singleton to manage authentication.
        /// The user's name and email are retrieved from the login result claims.
        /// </remarks>
        private async void CheckLoginStatusAsync()
        {
            if (!AuthService.Instance.IsLoggedIn)
            {
                this.Hide();
                await AuthService.Instance.LogIn();
            }

            if (AuthService.Instance.IsLoggedIn)
            {
                var user = AuthService.Instance.LoginResult.User;
                var name = user.FindFirst(c => c.Type == "name")?.Value;
                var email = user.FindFirst(c => c.Type == "email")?.Value;
                this.Show();
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

        /* TODO: Logout will be implemented later with user actions
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await AuthService.Instance.LogOut();
            CheckLoginStatusAsync();
        }
        */

        /// <summary>
        /// Handles the MouseDown event for the Grid.
        /// Initiates a window drag operation if the left mouse button is pressed.
        /// </summary>
        /// <param name="sender">The source of the event, typically the Grid control.</param>
        /// <param name="e">The MouseButtonEventArgs that contains the event data.</param>
        /// <remarks>
        /// This method allows the user to drag the window by clicking and holding the left mouse button within the Grid area.
        /// </remarks>
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) this.DragMove();
        }

        /// <summary>
        /// Handles the Click event for a button.
        /// Closes the current window when the button is clicked.
        /// </summary>
        /// <param name="sender">The source of the event, typically the button that was clicked.</param>
        /// <param name="e">The RoutedEventArgs that contains the event data.</param>
        /// <remarks>
        /// This method closes the window in response to a button click. Ensure this is attached to a button intended to close the window.
        /// </remarks>
        private void BtnCloseApplication_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Save some configurations?
            this.Close();
        }
    }
}
