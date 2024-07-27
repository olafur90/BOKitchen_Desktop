using Auth0.OidcClient;
using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Browser;
using System;
using System.Threading.Tasks;

namespace MathollDesktopApplication
{
    /// <summary>
    /// Sets up the Auth0 OidcClient and provides functionality to log in and log out
    /// </summary>
    internal class AuthService
    {
        // Auth0 Client
        private Auth0Client _client;

        // Singleton instance
        private static AuthService _instance;

        // Private constructor
        public static AuthService Instance => _instance ??= new AuthService();

        // Properties for the login result
        public LoginResult LoginResult { get; private set; }

        /// <summary>
        /// Sets the login result
        /// </summary>
        /// <param name="loginResult">The login result</param>
        public void SetLoginResult(LoginResult loginResult)
        {
            LoginResult = loginResult;
        }

        /// <summary>
        /// Initializes the Auth0 OidcClient
        /// </summary>
        public AuthService() 
        {
            InitializeClient();
        }

        /// <summary>
        /// Checks if the user is logged in
        /// </summary>
        /// <returns>True if the user is logged in, false otherwise</returns>
        public bool IsLoggedIn => LoginResult != null && !LoginResult.IsError;

        /// <summary>
        /// Logs in the user
        /// </summary>
        /// <returns>The login result</returns>
        public async Task<bool> LogIn() 
        {
            try
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
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Logs out the user
        /// </summary>
        /// <returns>True if the logout was successful, false otherwise</returns>
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

        /// <summary>
        /// Initializes the Auth0 OidcClient with the specified options
        /// </summary>
        public void InitializeClient()
        {
            Auth0ClientOptions clientOptions = new()
            {
                Domain = Properties.Resources.DomainName,
                ClientId = Properties.Resources.ClientId,
                RedirectUri = Properties.Resources.RedirectUri,
                PostLogoutRedirectUri = "http://localhost:5000"
            };
            _client = new Auth0Client(clientOptions);
        }
    }
}
