using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Auth0.OidcClient;

namespace MathollDesktopApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CheckLoginStatusAsync();
        }

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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await AuthService.Instance.LogOut();
            CheckLoginStatusAsync();
        }
    }
}
