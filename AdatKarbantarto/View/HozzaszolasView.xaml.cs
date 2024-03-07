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
        private ObservableCollection<Hozzaszolas> commentitems;
        private ObservableCollection<Hozzaszolas> commentaddedItems;
        private List<Hozzaszolas> comments;

        public HozzaszolasView()
        {
            InitializeComponent();
            GetComments();
            DataContext = this;
            btn_savecomment.IsEnabled = false;
        }

        public ObservableCollection<Hozzaszolas> AddedItems
        {
            get { return commentaddedItems ?? (commentaddedItems = new ObservableCollection<Hozzaszolas>()); }
            set { commentaddedItems = value; }
        }

        public ObservableCollection<Hozzaszolas> Items
        {
            get { return commentitems ?? (commentitems = new ObservableCollection<Hozzaszolas>()); }
            set { commentitems = value; }
        }

        private async void GetComments()
        {
            try
            {
                BackendApiHelper apiHelper = new BackendApiHelper();
                comments = await apiHelper.GetHozzaszolasokAsync();
                Items.Clear();
                foreach (var comment in comments)
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
            Hozzaszolas kivalasztott = dtg_Adatokcomment.SelectedItem as Hozzaszolas;
            if (kivalasztott == null)
            {
                MessageBox.Show("Please select a comment to delete.", "Delete Comment", MessageBoxButton.OK, MessageBoxImage.Information);
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
                GetComments();
            }
        }

        private async void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (ujhozzaszolas == null)
            {
                MessageBox.Show("Please add a comment first.", "Save Comment", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            BackendApiHelper postHelper = new BackendApiHelper();
            var response = await postHelper.PostHozzaszolasAsync(ujhozzaszolas);
            MessageBox.Show(response.ToString());
            GetComments();
            btn_addcomment.IsEnabled = true;
        }

        private void txb_search_KeyUp(object sender, KeyEventArgs e)
        {
            if (comments != null)
            {
                var filtered = comments.Where(comment => comment.leiras.ToLower().Contains(txb_searchcomment.Text.ToLower()));
                dtg_Adatokcomment.ItemsSource = filtered;
            }
        }

        public Hozzaszolas ujhozzaszolas;
        private void AddRow_Click(object sender, RoutedEventArgs e)
        {
            ujhozzaszolas = new Hozzaszolas();
            Items.Add(ujhozzaszolas);
            btn_addcomment.IsEnabled = false;
            btn_savecomment.IsEnabled = true;
        }
        private async void btn_put_Click(object sender, RoutedEventArgs e)
        {
            var item = commentaddedItems[0];
            if (item != null)
            {
              BackendApiHelper modhelper= new BackendApiHelper();
                var response =await modhelper.ModifyHozzaszolasAsync(item.hozzaszolasId, item);
                MessageBox.Show(response.ToString());
            }
        }

        private void ModifyComment_Click(object sender, RoutedEventArgs e)
        {
            Hozzaszolas putHozzaszolas = (Hozzaszolas)dtg_Adatokcomment.SelectedItem;
            commentaddedItems.Clear();
          
            commentaddedItems.Add(putHozzaszolas);

        }

    }
}
