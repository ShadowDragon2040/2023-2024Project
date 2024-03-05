using AdatKarbantarto.Helpers;
using AdatKarbantarto.Model;
using AdatKarbantarto.Utilities;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            GetTermekek();
            DataContext = this;
            btn_save.IsEnabled=false;
        }
        private ObservableCollection<Termek> items;

        public ObservableCollection<Termek> Items
        {
            get { return items ?? (items = new ObservableCollection<Termek>()); }
            set { items = value; }
        }

        List<Termek> products;
        public async void GetTermekek()
        {
            try
            {
                BackendApiHelper apiHelper = new BackendApiHelper();
                products = await apiHelper.GetTermekekAsync();
                Items.Clear();
                foreach (var item in products)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public Termek ujtermek;
        private void AddRow_Click(object sender, RoutedEventArgs e)
        {
            ujtermek = new Termek();
            Items.Add(ujtermek);
            btn_add.IsEnabled = false;
            btn_save.IsEnabled = true;
        }

        private async void btn_save_Click(object sender, RoutedEventArgs e)
        {
            BackendApiHelper postHelper = new BackendApiHelper();
            var response = await postHelper.PostTermekAsync(ujtermek);
            MessageBox.Show(response.ToString());
            GetTermekek();
            btn_add.IsEnabled = true;
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Termek kivalasztott = dtg_Adatok.SelectedItem as Termek;
            int kivalasztottId = kivalasztott.termekId;
            var confirmationDialog = new ConfirmationDialog("Are you sure you want to delete?");
            confirmationDialog.ShowDialog();

            bool result = await Task.Run(() => confirmationDialog.Result);

            if (result)
            {
                BackendApiHelper deleteHelper = new BackendApiHelper();
                var response = await deleteHelper.DeleteTermekAsync(kivalasztottId);
                MessageBox.Show(response.ToString());
                GetTermekek();
            }
            else
            {
            }
        }

        private async void ModifyButton_Click(Object sender, RoutedEventArgs e)
        {
            Termek modTermek = dtg_Adatok.SelectedItem as Termek;
            var confirmationDialog = new ConfirmationDialog("Are you sure you want to modify?");
            confirmationDialog.ShowDialog();

            bool result = await Task.Run(() => confirmationDialog.Result);
            if (result) 
            {
                BackendApiHelper modHelper = new BackendApiHelper();
                var response = await modHelper.ModifyTermekAsync(modTermek.termekId);
                MessageBox.Show(response.ToString());
                GetTermekek();
            }
            else
            {

            }
        }

        private void txb_search_KeyUp(object sender, KeyEventArgs e)
        {
            var filtered = products.Where(termek => termek.termekNev.ToLower().Contains(txb_search.Text.ToLower()));
            dtg_Adatok.ItemsSource = filtered;
        }
    }
}
