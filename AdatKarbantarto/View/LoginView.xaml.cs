using AdatKarbantarto.Helpers;
using AdatKarbantarto.Model;
using MaterialDesignExtensions.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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

        private void JwtDecode(string token)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
           
           var decoded= handler.ReadToken(token);
            MessageBox.Show(decoded.ToString());
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BackendApiHelper apiHelper = new BackendApiHelper();
                AuthenticatedUser user = await apiHelper.PostAsync(txtUsername.Text, txtPassword.Password);

                if (user != null)
                {
                    JwtDecode(user.Token);
                    MessageBox.Show($"Logged in as: {user.User.UserName}");
                    MainWindow window = new MainWindow();
                    window.Show();
                }
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }





    }
}
