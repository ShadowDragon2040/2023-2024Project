using System.Windows;
using System.Windows.Controls;

namespace AdatKarbantarto.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginView loginWin = new LoginView();
            loginWin.Show();

            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();

        }
    }
}
