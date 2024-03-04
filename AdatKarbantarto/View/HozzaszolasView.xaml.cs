using AdatKarbantarto.Helpers;
using AdatKarbantarto.Model;
using AdatKarbantarto.Utilities;
using MaterialDesignThemes.Wpf;
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
    /// Interaction logic for HozzaszolasView.xaml
    /// </summary>
    public partial class HozzaszolasView : UserControl
    {
        public HozzaszolasView()
        {
            InitializeComponent();
            GetComments();
            DataContext = this;
        }

        private ObservableCollection<Hozzaszolas> items;

        public ObservableCollection<Hozzaszolas> Items
        {
            get { return items ?? (items = new ObservableCollection<Hozzaszolas>()); }
            set { items = value; }
        }

        List<Hozzaszolas> comments;
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
            Hozzaszolas kivalasztott = dtg_Adatok.SelectedItem as Hozzaszolas;
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
        public Hozzaszolas ujhozzaszolas;
        private void AddRow_Click(object sender, RoutedEventArgs e)
        {
            ujhozzaszolas = new Hozzaszolas();
            Items.Add(ujhozzaszolas);
            btn_add.IsEnabled = false;

        }

        private async void btn_save_Click(object sender, RoutedEventArgs e)
        {
            BackendApiHelper postHelper = new BackendApiHelper();
            var response = await postHelper.PostHozzaszolasAsync(ujhozzaszolas);
            MessageBox.Show(response.ToString());
            GetComments();
            btn_add.IsEnabled = true;
        }
        private void txb_search_KeyUp(object sender, KeyEventArgs e)
        {
            var filtered = comments.Where(comment => comment.leiras.ToLower().Contains(txb_search.Text.ToLower()));
            dtg_Adatok.ItemsSource = filtered;
        }
    }
}
