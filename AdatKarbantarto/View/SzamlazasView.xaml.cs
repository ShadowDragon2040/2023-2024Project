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
            GetComments();
            DataContext = this;
            btn_savecomment.IsEnabled = false;
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

        private async void GetComments()
        {
            try
            {
                BackendApiHelper apiHelper = new BackendApiHelper();
                szamla = await apiHelper.GetSzamlaAsync();
                Items.Clear();
                foreach (var comment in szamla)
                {
                    Items.Add(comment);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void DeleteComment_Click(object sender, RoutedEventArgs e)
        {
            Szamla kivalasztott = dtg_Adatokszamla.SelectedItem as Szamla;
            if (kivalasztott == null)
            {
                MessageBox.Show("Please select a comment to delete.", "Delete Comment", MessageBoxButton.OK, MessageBoxImage.Information);
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
                GetComments();
            }
        }

        private async void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (ujSzamla == null)
            {
                MessageBox.Show("Please add a comment first.", "Save Comment", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            BackendApiHelper postHelper = new BackendApiHelper();
            var response = await postHelper.PostSzamlaAsync(ujSzamla);
            MessageBox.Show(response.ToString());
            GetComments();
            btn_addcomment.IsEnabled = true;
        }

        private void txb_search_KeyUp(object sender, KeyEventArgs e)
        {
            if (szamla != null)
            {
                
            }
        }

        private void AddRow_Click(object sender, RoutedEventArgs e)
        {
            ujSzamla = new Szamla();
            Items.Add(ujSzamla);
            btn_addcomment.IsEnabled = false;
            btn_savecomment.IsEnabled = true;
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

        private void ModifyComment_Click(object sender, RoutedEventArgs e)
        {
            Szamla putSzamla = (Szamla)dtg_Adatokszamla.SelectedItem;
            szamlaAddedItems.Clear();

            szamlaAddedItems.Add(putSzamla);

        }

    }
}
