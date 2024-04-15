using AdatKarbantarto.Helpers;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Claims;
using System.Windows;
using System.Windows.Input;

namespace AdatKarbantarto.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private static string ConvertSecureStringToString(SecureString secureString)
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                ptr = Marshal.SecureStringToBSTR(secureString);
                return Marshal.PtrToStringBSTR(ptr);
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Marshal.ZeroFreeBSTR(ptr);
            }
        }

        private bool JwtDecode(SecureString token)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            string tokenString = ConvertSecureStringToString(token);
            JwtSecurityToken decoded = handler.ReadJwtToken(tokenString);
            Claim roleClaim = decoded.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            if (roleClaim != null)
            {
                if (roleClaim.Value == "ADMIN")
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
            return false;


        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btnLogin.IsEnabled = false;
                BackendApiHelper apiHelper = new BackendApiHelper();
                string passString = new NetworkCredential("", txtPassword.Password).Password;
                string userToken = await apiHelper.PostAsync(txtUsername.Text, passString);

                if (userToken != null)
                {
                    SecureString token = ConvertToSecureString(userToken);
                    

                    bool admin = JwtDecode(token);
                    if (admin)
                    {
                        MainWindow window = new MainWindow();
                        window.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("The user is not admin!");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                btnLogin.IsEnabled = true;
            }
        }



        private SecureString ConvertToSecureString(string token)
        {
            SecureString secureString = new SecureString();
            foreach (char c in token)
            {
                secureString.AppendChar(c);
            }
            secureString.MakeReadOnly();
            return secureString;
        }
    }
}

