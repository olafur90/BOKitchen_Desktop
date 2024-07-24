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
        private Auth0Client _client;
        public MainWindow()
        {
            InitializeComponent();
            CheckLoginStatus();

            if (!AuthService.Instance.IsLoggedIn)
            {
                this.Hide();
                Login login = new();
                login.Show();
            }
        }

        private void CheckLoginStatus()
        {
            if (AuthService.Instance.IsLoggedIn)
            {
                var user = AuthService.Instance.LoginResult.User;
                var name = user.FindFirst(c => c.Type == "name")?.Value;
                var email = user.FindFirst(c => c.Type=="email")?.Value;
                MessageBox.Show($"Welcome {name} ({email})");
            }
            else
            {
                MessageBox.Show("User is not logged in");
            }
        }
    }
}
