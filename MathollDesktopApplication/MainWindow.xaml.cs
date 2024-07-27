using MathollDesktopApplication.UserControls;
using System.Windows;
using System.Windows.Input;
using Wpf.Ui.Controls;

namespace MathollDesktopApplication
{
    /// <inheritdoc />
    public partial class MainWindow : FluentWindow
    {
        /// <inheritdoc />
        public MainWindow()
        {
            InitializeComponent();
            CheckLoginStatusAsync();
            Loaded += MainWindow_Loaded;
        }

        /// <inheritdoc />
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Sets the content of the MainContentControl to the RecipeView control as the initial content.
            MainContentControl.Content = new RecipeView();
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

        /* TODO: Need to connect this to some button in the UI.
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

        /// <summary>
        /// Handles the Click event for the Sous Vide menu button.
        /// </summary>
        /// <param name="sender"> The source of the event. </param>
        /// <param name="e"> The RoutedEventArgs that contains the event data. </param>
        private void BtnMenuButtonSousVide_Click(object sender, RoutedEventArgs e)
        {
            MainContentControl.Content = new SousVide();
        }

        /// <summary>
        /// Handles the Click event for the Recipes menu button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The RoutedEventArgs that contains the event data.</param>
        private void BtnMenuButtonRecipes_Click(object sender, RoutedEventArgs e)
        {
            MainContentControl.Content = new RecipeView();
        }

        private void BtnMenuButtonAirFryer_Click(object sender, RoutedEventArgs e)
        {
            MainContentControl.Content = new AirFryerView();
        }
    }
}
