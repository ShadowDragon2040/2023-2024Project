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
    /// Interaction logic for HozzaszolasView.xaml
    /// </summary>
    public partial class HozzaszolasView : UserControl
    {
        private ObservableCollection<Hozzaszolas> items;
        private ObservableCollection<Hozzaszolas> addedItems;
        private List<Hozzaszolas> comments;

        public HozzaszolasView()
        {
            InitializeComponent();
            items = new ObservableCollection<Hozzaszolas>(); 
            addedItems = new ObservableCollection<Hozzaszolas>(); 
            GetHozzaszolas();
            DataContext = this;
            btn_save.IsEnabled = false;
        }

        public ObservableCollection<Hozzaszolas> AddedItems
        {
            get { return addedItems ?? (addedItems = new ObservableCollection<Hozzaszolas>()); }
            set { addedItems = value; }
        }

        public ObservableCollection<Hozzaszolas> Items
        {
            get { return items ?? (items = new ObservableCollection<Hozzaszolas>()); }
            set { items = value; }
        }

        private async void GetHozzaszolas()
        {
            try
            {
                BackendApiHelper apiHelper = new BackendApiHelper();
                comments = await apiHelper.GetHozzaszolasokAsync();
                Items.Clear();
                foreach (var item  in comments)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            Hozzaszolas kivalasztott = dtg_Adatok.SelectedItem as Hozzaszolas;
            if (kivalasztott == null)
            {
                MessageBox.Show("Please select a to delete.", "Delete ", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            int kivalasztottId = kivalasztott.hozzaszolasId;
            var confirmationDialog = new ConfirmationDialog("Are you sure you want to delete?");
            confirmationDialog.ShowDialog();

            bool result = await Task.Run(() => confirmationDialog.Result);

            if (result)
            {
                BackendApiHelper deleteHelper = new BackendApiHelper();
                var response = await deleteHelper.DeleteHozzaszolasAsync(kivalasztottId);
                MessageBox.Show(response.ToString());

                Items.Remove(kivalasztott);
            }
        }

        public Hozzaszolas ujhozzaszolas;

        private void AddRow_Click(object sender, RoutedEventArgs e)
        {
            ujhozzaszolas = new Hozzaszolas();
            Items.Add(ujhozzaszolas);

            btn_save.IsEnabled = true;
        }


        private async void btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BackendApiHelper postHelper = new BackendApiHelper();
                var response = await postHelper.PostHozzaszolasAsync(ujhozzaszolas);
                MessageBox.Show(response.ToString());
                GetHozzaszolas();
                btn_add.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txb_search_KeyUp(object sender, KeyEventArgs e)
        {
            if (comments != null)
            {
                var filtered = comments.Where(d => d.Leiras.ToLower().Contains(txb_search.Text.ToLower())).ToList();
                dtg_Adatok.ItemsSource = filtered;
            }
        }


        private async void btn_put_Click(object sender, RoutedEventArgs e)
        {
            if (addedItems != null && addedItems.Count > 0)
            {
                var item = addedItems[0];
                BackendApiHelper modhelper = new BackendApiHelper();
                var response = await modhelper.ModifyHozzaszolasAsync(item.hozzaszolasId, item);
                MessageBox.Show(response.ToString());
            }
        }


        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            Hozzaszolas putHozzaszolas = (Hozzaszolas)dtg_Adatok.SelectedItem;
            if (putHozzaszolas != null)
            {
                addedItems.Clear();
                addedItems.Add(putHozzaszolas);
            }
        }


    }
}
