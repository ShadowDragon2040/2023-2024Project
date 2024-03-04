using AdatKarbantarto.Helpers;
using AdatKarbantarto.Model;
using AdatKarbantarto.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            DataContext = this;

        }

        private ObservableCollection<Felhasznalo> items;

        public ObservableCollection<Felhasznalo> Items
        {
            get { return items ?? (items = new ObservableCollection<Felhasznalo>()); }
            set { items = value; }
        }

        private async void GetFelhasznalok()
        {
            try
            {
                BackendApiHelper apiHelper = new BackendApiHelper();
                List<Felhasznalo> users = await apiHelper.GetFelhasznalokAsync();
                Items.Clear();
                foreach (var item in users)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

       

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Felhasznalo kivalasztott = dtg_Adatok.SelectedItem as Felhasznalo;
            int kivalasztottId = kivalasztott.FelhasznaloId;
            var confirmationDialog = new ConfirmationDialog("Are you sure you want to delete?");
            confirmationDialog.ShowDialog();

            bool result = await Task.Run(() => confirmationDialog.Result);

            if (result)
            {
                BackendApiHelper deleteHelper= new BackendApiHelper();
                var response=await deleteHelper.DeleteFelhasznaloAsync(kivalasztottId);
                MessageBox.Show(response.ToString());
                GetFelhasznalok();
            }
            else
            {
            }
        }
        public Felhasznalo ujfelhasznalo;
        private void AddRow_Click(object sender, RoutedEventArgs e)
        {
            ujfelhasznalo = new Felhasznalo();
            Items.Add(ujfelhasznalo);
            btn_add.IsEnabled = false;

        }

        private async void btn_save_Click(object sender, RoutedEventArgs e)
        {
            BackendApiHelper postHelper = new BackendApiHelper();
            var response = await postHelper.PostFelhasznaloAsync(ujfelhasznalo);
            MessageBox.Show(response.ToString());
            GetFelhasznalok();
            btn_add.IsEnabled = true;
        }
    }
}
