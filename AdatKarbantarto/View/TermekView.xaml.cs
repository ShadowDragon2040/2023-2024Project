using AdatKarbantarto.Helpers;
using AdatKarbantarto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace AdatKarbantarto.View
{
    /// <summary>
    /// Interaction logic for TermekView.xaml
    /// </summary>
    public partial class TermekView : UserControl
    {
        public TermekView()
        {
            InitializeComponent();
            GetProducts();
        }
        public async void GetProducts()
        {
            try
            {
                BackendApiHelper apiHelper = new BackendApiHelper();
                List<Termek> products = await apiHelper.GetTermekekAsync();
                dtg_Adatok.ItemsSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
