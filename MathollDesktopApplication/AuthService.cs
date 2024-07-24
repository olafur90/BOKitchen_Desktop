using Auth0.OidcClient;
using IdentityModel.OidcClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth0.OidcClient;
using System.Windows;

namespace MathollDesktopApplication
{
    internal class AuthService
    {
        private Auth0Client _client;
        private static AuthService _instance;
        public static AuthService Instance => _instance ??= new AuthService();

        public LoginResult LoginResult { get; private set; }

        public void SetLoginResult(LoginResult loginResult)
        {
            LoginResult = loginResult;
        }

        public AuthService() 
        {
            InitializeClient();
        }

        public bool IsLoggedIn => LoginResult != null && !LoginResult.IsError;

        public async void LogIn() 
        {
            LoginResult = null;
            var loginResult = await _client.LoginAsync();

            if (loginResult.IsError == false)
            {
                AuthService.Instance.SetLoginResult(loginResult);

                // Open MainWindow.xaml
                MainWindow mainWindow = new();
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("Error: " + loginResult.Error);
            }
        }

        public void InitializeClient()
        {
            Auth0ClientOptions clientOptions = new Auth0ClientOptions
            {
                Domain = Properties.Resources.DomainName,
                ClientId = Properties.Resources.ClientId,
                RedirectUri = Properties.Resources.RedirectUri,
            };
            _client = new Auth0Client(clientOptions);
            clientOptions.PostLogoutRedirectUri = clientOptions.PostLogoutRedirectUri;
        }
    }
}
