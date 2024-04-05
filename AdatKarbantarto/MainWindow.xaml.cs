using AdatKarbantarto.ViewModel;
using Newtonsoft.Json.Linq;
using System.Security;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdatKarbantarto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly NavigationVM _vm;

        public MainWindow(SecureString token)
        {
            InitializeComponent();
            _vm = new NavigationVM(token); 
            DataContext = _vm;
        }
    }
}