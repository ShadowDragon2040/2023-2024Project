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
            btn_save.IsEnabled = false;

        }

        private ObservableCollection<Felhasznalo> items;
        private ObservableCollection<Felhasznalo> addedItems;
        public ObservableCollection<Felhasznalo> Items
        {
            get { return items ?? (items = new ObservableCollection<Felhasznalo>()); }
            set { items = value; }
        }
        public ObservableCollection<Felhasznalo> AddedItems
        {
            get { return addedItems ?? (addedItems = new ObservableCollection<Felhasznalo>()); }
            set { addedItems = value; }
        }

        public List<Felhasznalo> users;
        private async void GetFelhasznalok()
        {
            try
            {
                BackendApiHelper apiHelper = new BackendApiHelper();
                users = await apiHelper.GetFelhasznalokAsync();
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


        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            Felhasznalo felhasznalo = (Felhasznalo)dtg_Adatok.SelectedItem;
            addedItems.Clear();

            addedItems.Add(felhasznalo);

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
                BackendApiHelper deleteHelper = new BackendApiHelper();
                var response = await deleteHelper.DeleteFelhasznaloAsync(kivalasztottId);
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
            btn_save.IsEnabled = true;

        }

        private async void btn_save_Click(object sender, RoutedEventArgs e)
        {

            if (Vizsgalat(ujfelhasznalo))
            {
                BackendApiHelper postHelper = new BackendApiHelper();
                var response = await postHelper.PostFelhasznaloAsync(ujfelhasznalo);
                MessageBox.Show(response.ToString());
                GetFelhasznalok();
                btn_add.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Nem megfelelő modell");
            }
        }

        private async void btn_Put_Click(object sender, RoutedEventArgs e)
        {

        }
        private bool Vizsgalat(Felhasznalo ujfelhasznalo)
        {

            throw new NotImplementedException();
        }

        private void txb_search_KeyUp(object sender, KeyEventArgs e)
        {
            var filtered = users.Where(user => user.LoginNev.ToLower().Contains(txb_search.Text.ToLower()));
            dtg_Adatok.ItemsSource = filtered;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
