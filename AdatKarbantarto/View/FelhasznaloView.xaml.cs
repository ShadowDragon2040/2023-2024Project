using AdatKarbantarto.Helpers;
using AdatKarbantarto.Model;
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

namespace AdatKarbantarto.View
{
    /// <summary>
    /// Interaction logic for FelhasznaloView.xaml
    /// </summary>
    public partial class FelhasznaloView : UserControl
    {

      


        public FelhasznaloView()
        {
            InitializeComponent();
            GetFelhasznalok();

        }

        public async void GetFelhasznalok()
        {
            try
            {
                ApiHelper apiHelper = new ApiHelper();
                List<Felhasznalo> users = await apiHelper.GetFelhasznalokAsync("/Felhasznalok");
                dtg_Adatok.ItemsSource = users;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }
}
