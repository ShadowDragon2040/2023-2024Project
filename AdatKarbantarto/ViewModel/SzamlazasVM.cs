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
    public class SzamlazasVM : ViewModelBase
    {
        private static readonly Regex _regex = new Regex("[^0-9 ]+");
        private string _searchProductID = "";
        private bool _isSaveEnabled;
        private bool _isAddEnabled;
        private Szamla _selectedItem;
        private Felhasznalo _selectedUser;
        private Termek _selectedTermek;
        private List<Szamla> _ListData;
        private List<Felhasznalo> _userList;
        private List<Termek> _productList;
        private ObservableCollection<Felhasznalo> _users;
        private ObservableCollection<Termek> _products;
        private ObservableCollection<Szamla> _items;
        private ObservableCollection<Szamla> _updateItem;
        private ICollectionView _filteredView;
        public SzamlazasVM()
        {
            _isSaveEnabled = false;
            _isAddEnabled = true;
            Products = new ObservableCollection<Termek>();
            Users = new ObservableCollection<Felhasznalo>();
            SzamlaItems = new ObservableCollection<Szamla>();
            UpdateItem = new ObservableCollection<Szamla>();
            RefreshCommand = new RelayCommand(execute => RefreshItems());
            AddCommand = new RelayCommand(execute => AddItem());
            DeleteCommand = new RelayCommand(execute => DeleteItem(execute as Szamla), canExecute => SelectedItem != null);
            ModifyCommand = new RelayCommand(execute => ModifyItem(execute as Szamla), canExecute => SelectedItem != null);
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

        public ObservableCollection<Felhasznalo> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                _filteredView = CollectionViewSource.GetDefaultView(_users);
                ApplyFilter();
            }
        }
        public ObservableCollection<Termek> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                _filteredView = CollectionViewSource.GetDefaultView(_products);
                ApplyFilter();
            }
        }

        public Felhasznalo SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                if (_selectedUser != value)
                {
                    _selectedUser = value;
                    OnPropertyChanged(nameof(SelectedUser));
                    if (SelectedItem != null)
                    {
                        SelectedItem.felhasznaloId = SelectedUser.Id; 
                    }
                }
            }
        }
        public Termek SelectedTermek
        {
            get { return _selectedTermek; }
            set
            {
                if (_selectedTermek != value)
                {
                    _selectedTermek = value;
                    OnPropertyChanged(nameof(SelectedTermek));
                    if (SelectedItem != null)
                    {
                        SelectedItem.termekId = SelectedTermek.TermekId;
                    }
                }
            }
        }
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

        public ObservableCollection<Szamla> UpdateItem
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

        public ObservableCollection<Szamla> SzamlaItems
        {
            get { return _items; }
            set
            {
                _items = value;
                _filteredView = CollectionViewSource.GetDefaultView(_items);
                ApplyFilter();
            }
        }
        public Szamla SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
                if (_selectedItem != null)
                {
                    _selectedItem.termekId = SelectedTermek?.TermekId??0;
                    _selectedItem.felhasznaloId = SelectedUser?.Id; 
                }
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
                _ListData = await apiHelper.GetSzamlaAsync();
                _userList = await apiHelper.GetFelhasznalokAsync();
                _productList = await apiHelper.GetTermekekAsync();
                SzamlaItems.Clear();
                foreach (Felhasznalo user in _userList)
                {
                    Users.Add(user);
                }
                foreach (Termek prod in _productList)
                {
                    Products.Add(prod);
                }

                foreach (var szamla in _ListData)
                {
                    SzamlaItems.Add(szamla);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private async void SaveItem()
        {

            Szamla newProduct = new Szamla()
            {
                szamlazasId = SelectedItem.szamlazasId,
                felhasznaloId = SelectedUser.Id,
                termekId = SelectedTermek.TermekId,
                szinHex = SelectedItem.szinHex,
                vasarlasIdopontja = SelectedItem.vasarlasIdopontja,
                sikeresSzallitas = SelectedItem.sikeresSzallitas,
            };
            BackendApiHelper postHelper = new BackendApiHelper();
            var response = await postHelper.PostSzamlaAsync(newProduct);
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
                UpdateItem[0].termekId = SelectedTermek.TermekId;
                UpdateItem[0].felhasznaloId=SelectedUser.Id;
                var response = await modhelper.ModifySzamlaAsync(UpdateItem[0].szamlazasId, UpdateItem[0]);
                if (response)
                {
                    MessageBox.Show("Product edited successfully!", "Success!", MessageBoxButton.OK);
                }
                else MessageBox.Show("Something went wrong!", "Warning!", MessageBoxButton.OKCancel);
            }
        }
        private async void DeleteItem(Szamla itemToDelete)
        {
            var confirmationDialog = new ConfirmationDialog("Are you sure you want to delete?");

            confirmationDialog.ShowDialog();

            bool result = await Task.Run(() => confirmationDialog.Result);

            if (result)
            {
                BackendApiHelper deleteHelper = new BackendApiHelper();
                var response = await deleteHelper.DeleteSzamlaAsync(itemToDelete.szamlazasId);
                if (response)
                {
                    MessageBox.Show("Product deleted successfully!", "Success!", MessageBoxButton.OK);
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
            SzamlaItems.Clear();
            LoadInitialData();
        }

        private void AddItem()
        {
            UpdateItem.Clear();
            UpdateItem.Add(new Szamla());
            IsAddEnabled = false;
            IsSaveEnabled = true;
            AddCommand.RaiseCanExecuteChanged(); // Notify the UI to re-evaluate AddCommand's CanExecute
        }

        private void ModifyItem(Szamla szamlaToModify)
        {
            UpdateItem.Clear();

            UpdateItem.Add(szamlaToModify);
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
                        if (obj is Szamla Szamla)
                        {
                            // Filter by ProductID 
                            if (int.TryParse(SearchProductID, out int result))
                            {
                                if (result <= int.MaxValue) return Szamla.szamlazasId == Convert.ToInt32(SearchProductID);
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
