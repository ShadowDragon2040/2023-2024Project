using AdatKarbantarto.Helpers;
using AdatKarbantarto.Model;
using AdatKarbantarto.Utilities;
using System.Collections.ObjectModel;
using System.Windows;

namespace AdatKarbantarto.ViewModel
{
    public class TermekekVM : ViewModelBase
    {
        private bool isSaveEnabled;
        private bool isAddEnabled;
        private List<Termek> ListData;
        public ObservableCollection<Termek> Items { get; set; }
        public RelayCommand RefreshCommand { get; private set; }
        public RelayCommand AddCommand { get; private set; }
        public RelayCommand DeleteCommand { get; private set; }
        public RelayCommand ModifyCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        private Termek selectedItem;
        public Termek SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public TermekekVM()
        {
            isSaveEnabled = false;
            isAddEnabled = true;
            Items = new ObservableCollection<Termek>();
            RefreshCommand = new RelayCommand(execute => RefreshItems());
            AddCommand = new RelayCommand(execute => AddItem());
            DeleteCommand = new RelayCommand(execute => DeleteItem(), canExecute => SelectedItem != null);
            ModifyCommand = new RelayCommand(execute => ModifyItem(), canExecute => CanModify());
            SaveCommand = new RelayCommand(execute => SaveItem(), canExecute => CanSave());

            LoadInitialData();
        }
        public bool IsSaveEnabled
        {
            get { return isSaveEnabled; }
            set
            {
                if (isSaveEnabled != value)
                {
                    isSaveEnabled = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsAddEnabled
        {
            get { return isAddEnabled; }
            set
            {
                if (isAddEnabled != value)
                {
                    isAddEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        private async void LoadInitialData()
        {
            // Load data into Items collection 
            try
            {
                BackendApiHelper apiHelper = new BackendApiHelper();
                ListData = await apiHelper.GetTermekekAsync();
                Items.Clear();
                foreach (var szamla in ListData)
                {
                    Items.Add(szamla);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void RefreshItems()
        {
            // Implement logic to refresh Items collection (e.g., reload from database)
            Items.Clear(); // Clear existing items
            LoadInitialData(); // Reload items
        }

        private void AddItem()
        {
            Items.Add(new Termek());
            IsAddEnabled = false;
            IsSaveEnabled = true;
            AddCommand.RaiseCanExecuteChanged(); // Notify the UI to re-evaluate AddCommand's CanExecute
        }

        private void SaveItem()
        {
            // Implement logic to save items here

            IsAddEnabled = true;
            IsSaveEnabled = false;
            SaveCommand.RaiseCanExecuteChanged(); // Notify the UI to re-evaluate SaveCommand's CanExecute
        }


        private void DeleteItem()
        {
            Items.Remove(SelectedItem);
        }

        private void ModifyItem()
        {
            // Implement logic to modify the selected item here
        }

        private bool CanModify() => SelectedItem != null;

     

        private bool CanSave()
        {
            // Implement logic to determine if saving is allowed
            return true;
        }
    }
}
