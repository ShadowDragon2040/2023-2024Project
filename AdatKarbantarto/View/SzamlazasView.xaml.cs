using AdatKarbantarto.Helpers;
using AdatKarbantarto.Model;
using AdatKarbantarto.Utilities;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;


namespace AdatKarbantarto.View
{
    /// <summary>
    /// Interaction logic for SzamlaView.xaml
    /// </summary>
    public partial class SzamlazasView : UserControl
    {
        private ObservableCollection<Szamla> szamlazasitems;
        private ObservableCollection<Szamla> szamlaAddedItems;
        private List<Szamla> szamla;
        private Szamla ujSzamla;


        public SzamlazasView()
        {
            InitializeComponent();
            GetSzamlazas();
            DataContext = this;
            btn_save.IsEnabled = false;
        }

        public ObservableCollection<Szamla> AddedItems
        {
            get { return szamlaAddedItems ?? (szamlaAddedItems = new ObservableCollection<Szamla>()); }
            set { szamlaAddedItems = value; }
        }

        public ObservableCollection<Szamla> Items
        {
            get { return szamlazasitems ?? (szamlazasitems = new ObservableCollection<Szamla>()); }
            set { szamlazasitems = value; }
        }

        private async void GetSzamlazas()
        {
            try
            {
                BackendApiHelper apiHelper = new BackendApiHelper();
                szamla = await apiHelper.GetSzamlaAsync();
                Items.Clear();
                foreach (var szamla  in szamla)
                {
                    Items.Add(szamla);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            Szamla kivalasztott = dtg_Adatokszamla.SelectedItem as Szamla;
            if (kivalasztott == null)
            {
                MessageBox.Show("Please select a  to delete.", "Delete ", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            int kivalasztottId = kivalasztott.szamlazasId;
            var confirmationDialog = new ConfirmationDialog("Are you sure you want to delete?");
            confirmationDialog.ShowDialog();

            bool result = await Task.Run(() => confirmationDialog.Result);

            if (result)
            {
                BackendApiHelper deleteHelper = new BackendApiHelper();
                var response = await deleteHelper.DeleteSzamlaAsync(kivalasztottId);
                MessageBox.Show(response.ToString());
                GetSzamlazas();
            }
        }
        private void AddRow_Click(object sender, RoutedEventArgs e)
        {
            ujSzamla = new Szamla();
            Items.Add(ujSzamla);
            btn_add.IsEnabled = false;
            btn_save.IsEnabled = true;
        }

        private async void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (ujSzamla == null)
            {
                MessageBox.Show("Please add a  first.", "Save ", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            BackendApiHelper postHelper = new BackendApiHelper();
            var response = await postHelper.PostSzamlaAsync(ujSzamla);
            MessageBox.Show(response.ToString());
            GetSzamlazas();
            btn_add.IsEnabled = true;
        }

        private void txb_search_KeyUp(object sender, KeyEventArgs e)
        {
            if (szamla != null)
            {
                
            }
        }

    
        private async void btn_put_Click(object sender, RoutedEventArgs e)
        {
            var item = szamlaAddedItems[0];
            if (item != null)
            {
                BackendApiHelper modhelper = new BackendApiHelper();
                var response = await modhelper.ModifySzamlaAsync(item.szamlazasId, item);
                MessageBox.Show(response.ToString());
            }
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            Szamla putSzamla = (Szamla)dtg_Adatokszamla.SelectedItem;
            szamlaAddedItems.Clear();

            szamlaAddedItems.Add(putSzamla);

        }

    }
}
