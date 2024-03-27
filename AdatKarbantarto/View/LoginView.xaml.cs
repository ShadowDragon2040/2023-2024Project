using AdatKarbantarto.Helpers;
using AdatKarbantarto.Model;
using MaterialDesignExtensions.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            if (e.LeftButton==MouseButtonState.Pressed)
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

        private void JwtDecode(SecureString token)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
           string tokenString= ConvertSecureStringToString(token);
           JwtSecurityToken decoded= handler.ReadJwtToken(tokenString);
            MessageBox.Show(decoded.ToString());
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BackendApiHelper apiHelper = new BackendApiHelper();
                string passString = new NetworkCredential("", txtPassword.Password).Password;
                AuthenticatedUser user = await apiHelper.PostAsync(txtUsername.Text, passString);

                if (user != null)
                {
                    SecureString token = ConvertToSecureString(user.token);
                    JwtDecode(token);
                    MessageBox.Show($"Logged in as: {user.User.UserName}");
                    MainWindow window = new MainWindow(token);
                    window.Show();
                }
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

