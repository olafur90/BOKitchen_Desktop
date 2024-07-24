using Auth0.OidcClient;
using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Browser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<bool> LogIn() 
        {
            LoginResult = null;
            var loginResult = await _client.LoginAsync();

            if (loginResult.IsError == false)
            {
                AuthService.Instance.SetLoginResult(loginResult);
                return true;
            }
            else
            {
                MessageBox.Show("Error: " + loginResult.Error);
            }
            return false;
        }

        public async Task<bool> LogOut()
        {
            try
            {
                LoginResult = null;
                BrowserResultType res = await _client.LogoutAsync();
                if (res == BrowserResultType.Success)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Logout failed: {ex.Message}");
                return false;
            }
        }

        public void InitializeClient()
        {
            Auth0ClientOptions clientOptions = new Auth0ClientOptions
            {
                Domain = Properties.Resources.DomainName,
                ClientId = Properties.Resources.ClientId,
                RedirectUri = Properties.Resources.RedirectUri,
                PostLogoutRedirectUri = "http://localhost:5000"
            };
            _client = new Auth0Client(clientOptions);
            clientOptions.PostLogoutRedirectUri = clientOptions.PostLogoutRedirectUri;
        }
    }
}
