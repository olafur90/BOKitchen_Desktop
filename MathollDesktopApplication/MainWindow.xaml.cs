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
        /// Handles the CanExecute event for the CommandBinding.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The CanExecuteRoutedEventArgs that contains the event data.</param>
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        /// <summary>
        /// Handles the Executed event for the CommandBinding when the user wants to maximize/restore the window.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The ExecutedRoutedEventArgs that contains the event data.</param>
        private void CommandBinding_Executed_2(object sender, ExecutedRoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized) SystemCommands.RestoreWindow(this);
            else SystemCommands.MaximizeWindow(this);
        }

        /// <summary>
        /// Handles the Executed event for the CommandBinding when the user wants to minimize the window to the taskbar.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The ExecutedRoutedEventArgs that contains the event data.</param>
        private void CommandBinding_Executed_3(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
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

        /// <summary>
        /// Handles the Click event for the Air Fryer menu button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The RoutedEventArgs that contains the event data.</param>
        private void BtnMenuButtonAirFryer_Click(object sender, RoutedEventArgs e)
        {
            MainContentControl.Content = new AirFryerView();
        }

        /// <summary>
        /// Handles the Click event for the Settings menu button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The RoutedEventArgs that contains the event data.</param>
        private void BtnMenuButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            MainContentControl.Content = new SettingsView();
        }

        /// <summary>
        /// Handles the MouseLeftButtonDown event for the Banner Grid to toggle between Maximized and Normal states.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridHeader_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Check if the click count is 2, indicating a double-click
            if (e.ClickCount == 2)
            {
                // Toggle between Maximized and Normal states
                if (this.WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                }
            }
        }

        /// <summary>
        /// Handles the Click event for the Logout menu button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The RoutedEventArgs that contains the event data.</param>
        private async void BtnMenuButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBoxResult result = System.Windows.MessageBox.Show("Are you sure you want to logout?", "Logout", System.Windows.MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == System.Windows.MessageBoxResult.Yes) await AuthService.Instance.LogOut();
            CheckLoginStatusAsync();
        }
    }
}
