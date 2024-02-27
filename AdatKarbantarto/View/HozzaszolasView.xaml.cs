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
    /// Interaction logic for HozzaszolasView.xaml
    /// </summary>
    public partial class HozzaszolasView : UserControl
    {
        public HozzaszolasView()
        {
            InitializeComponent();
            GetComments();
        }
        public async void GetComments()
        {
            try
            {
                BackendApiHelper apiHelper = new BackendApiHelper();
                List<Hozzaszolas> comments = await apiHelper.GetHozzaszolasokAsync();
                dtg_Adatok.ItemsSource = comments;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
    }
}
