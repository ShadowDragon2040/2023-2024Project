using AdatKarbantarto.Helpers;
using AdatKarbantarto.Model;
using AdatKarbantarto.Utilities;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Data;


namespace AdatKarbantarto.ViewModel
{
    public class FelhasznalokVM : ViewModelBase
    {
        private static readonly Regex _regex = new Regex("[^0-9 ]+");
        private string _searchProductID = "";
        private bool _isSaveEnabled;
        private bool _isAddEnabled;
        private Felhasznalo _selectedItem;
        private List<Felhasznalo> _ListData;
        private ObservableCollection<Felhasznalo> _items;
        private ObservableCollection<Felhasznalo> _updateItem;
        private ICollectionView _filteredView;
        public FelhasznalokVM()
        {
            IsSaveEnabled = false;
            IsAddEnabled = true;
            Items = new ObservableCollection<Felhasznalo>();
            UpdateItem = new ObservableCollection<Felhasznalo>();
            RefreshCommand = new RelayCommand(execute => RefreshItems());
            AddCommand = new RelayCommand(execute => AddItem());
            DeleteCommand = new RelayCommand(execute => DeleteItem(execute as Felhasznalo));
            ModifyCommand = new RelayCommand(execute => ModifyItem(execute as Felhasznalo));
            SaveCommand = new RelayCommand(execute => SaveItem(), canExecute => CanSave());
            PutCommand = new RelayCommand(execute => PutItem());


            LoadInitialData();
        }
        #region Commands
        public RelayCommand RefreshCommand { get; private set; }
        public RelayCommand AddCommand { get; private set; }
        public RelayCommand DeleteCommand { get; private set; }
        public RelayCommand ModifyCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand PutCommand { get; private set; }
        #endregion
        #region Getters/Setters

       
        public string SearchProductID
        {
            get { return _searchProductID; }
            set
            {

                if (_searchProductID != value && isTextAllowed(value))
                {
                    _searchProductID = value;
                    OnPropertyChanged(nameof(_searchProductID));
                    ApplyFilter();
                }
            }
        }

        public ObservableCollection<Felhasznalo> UpdateItem
        {
            get { return _updateItem; }
            set
            {
                if (_updateItem != value)
                {
                    _updateItem = value;
                    OnPropertyChanged(nameof(_updateItem));
                }
            }
        }

        public ObservableCollection<Felhasznalo> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                _filteredView = CollectionViewSource.GetDefaultView(_items);
                ApplyFilter();
            }
        }
        public Felhasznalo SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));

            }
        }
        public bool IsSaveEnabled
        {
            get { return _isSaveEnabled; }
            set
            {
                if (_isSaveEnabled != value)
                {
                    _isSaveEnabled = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsAddEnabled
        {
            get { return _isAddEnabled; }
            set
            {
                if (_isAddEnabled != value)
                {
                    _isAddEnabled = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region CRUD
        private async void LoadInitialData()
        {
            // Load data into Items collection 
            try
            {
                
                BackendApiHelper apiHelper = new BackendApiHelper();
                _ListData = await apiHelper.GetFelhasznalokAsync();

                Items.Clear();

                foreach (var szamla in _ListData)
                {
                    Items.Add(szamla);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private async void SaveItem()
        {

            RegisterUser newUser = new RegisterUser()
            {
                UserName = UpdateItem[0].UserName,
                Password = UpdateItem[0].PasswordHash,
                Email = UpdateItem[0].Email
            };
            BackendApiHelper postHelper = new BackendApiHelper();
            var response = await postHelper.PostFelhasznaloAsync(newUser);
            MessageBox.Show(response.ToString());

            IsAddEnabled = true;
            IsSaveEnabled = false;
            SaveCommand.RaiseCanExecuteChanged(); // Notify the UI to re-evaluate SaveCommand's CanExecute
        }
        private async void PutItem()
        {
            var confirmationDialog = new ConfirmationDialog("Are you sure you want to modify?");
            confirmationDialog.ShowDialog();

            bool result = await Task.Run(() => confirmationDialog.Result);

            if (result)
            {
                BackendApiHelper modhelper = new BackendApiHelper();

                var response = await modhelper.ModifyFelhasznaloAsync(UpdateItem[0].Id, UpdateItem[0]);
                if (response)
                {
                    MessageBox.Show("Item edited successfully!", "Success!", MessageBoxButton.OK);
                }
                else MessageBox.Show("Something went wrong!", "Warning!", MessageBoxButton.OKCancel);
            }
        }
        private async void DeleteItem(Felhasznalo itemToDelete)
        {
            var confirmationDialog = new ConfirmationDialog("Are you sure you want to delete?");

            confirmationDialog.ShowDialog();

            bool result = await Task.Run(() => confirmationDialog.Result);

            if (result)
            {
                BackendApiHelper deleteHelper = new BackendApiHelper();
                var response = await deleteHelper.DeleteFelhasznaloAsync(itemToDelete.Id);
                if (response)
                {
                    MessageBox.Show("Item deleted successfully!", "Success!", MessageBoxButton.OK);
                }
                else MessageBox.Show("Something went wrong!", "Warning!", MessageBoxButton.OKCancel);

            }
        }
        #endregion
        private static bool isTextAllowed(string value)
        {
            return !_regex.IsMatch(value);
        }
        private void RefreshItems()
        {
            Items.Clear();
            LoadInitialData();
        }

        private void AddItem()
        {
            UpdateItem.Clear();
            UpdateItem.Add(new Felhasznalo());
            IsAddEnabled = false;
            IsSaveEnabled = true;
            AddCommand.RaiseCanExecuteChanged(); // Notify the UI to re-evaluate AddCommand's CanExecute
        }

        private void ModifyItem(Felhasznalo itemToModify)
        {
            UpdateItem.Clear();
            UpdateItem.Add(itemToModify);
            IsAddEnabled = true;
        }


        private bool CanSave()
        {
            return true;
        }
        private void ApplyFilter()
        {
            if (_filteredView != null)
            {
                if (SearchProductID == "") _filteredView.Filter = null;
                else
                {
                    _filteredView.Filter = obj =>
                    {
                        if (obj is Felhasznalo felhasznalo)
                        {
                            // Filter by ProductID 
                            if (int.TryParse(SearchProductID, out int result))
                            {
                                if (result <= int.MaxValue) return felhasznalo.Id.Contains(SearchProductID);
                            }
                            else
                            {
                                MessageBox.Show("Failed to convert the string to an integer.", "Warning!", MessageBoxButton.OK);
                                SearchProductID = "";
                            }
                        }
                        return false;
                    };
                }
            }
        }
    }
}
