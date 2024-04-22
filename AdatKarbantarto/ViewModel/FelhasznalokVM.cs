using AdatKarbantarto.Helpers;
using AdatKarbantarto.Model;
using AdatKarbantarto.Utilities;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Mail;
using System.Security;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Data;


namespace AdatKarbantarto.ViewModel
{
    public class FelhasznalokVM : ViewModelBase
    {
        private BackendApiHelper _backendApiHelper;
        private static readonly Regex _regex = new Regex("[^0-9 ]+");

        private string _searchProductID = "";
        private bool _isSaveEnabled;
        private bool _isPutEnabled;
        private bool _isAddEnabled;
        private Felhasznalo _selectedItem;
        private List<Felhasznalo> _ListData;
        private ObservableCollection<Felhasznalo> _items;
        private ObservableCollection<Felhasznalo> _updateItem;
        private ICollectionView _filteredView;
        public FelhasznalokVM()
        {
            _isPutEnabled = false;
            _isSaveEnabled = false;
            _isAddEnabled = true;
            _backendApiHelper = new BackendApiHelper();
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
        public bool IsPutEnabled
        {
            get { return _isPutEnabled; }
            set
            {
                if (_isPutEnabled != value)
                {
                    _isPutEnabled = value;
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
              
                var resp = await _backendApiHelper.GetFelhasznalokAsync();
                
               
                if (resp.Data != null)
                {
                    _ListData = resp.Data;

                }
                else
                {
                    MessageBox.Show(resp.ErrorMessage);
                }

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
                userName = UpdateItem[0].UserName,
                password = UpdateItem[0].PasswordHash,
                email = UpdateItem[0].Email
            };
            if (newUser!=null)
            {

                if (isEmailAllowed(newUser.email))
                {
                    var response = await _backendApiHelper.PostFelhasznaloAsync(newUser);
                    var content = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(content);
                }
                else
                {
                    MessageBox.Show("Invalid email address!");
                }
            }
            else
            {
                MessageBox.Show("Invalid User!");
            }


            IsAddEnabled = true;
            IsSaveEnabled = false;
            IsPutEnabled = false;

            SaveCommand.RaiseCanExecuteChanged(); // Notify the UI to re-evaluate SaveCommand's CanExecute
        }
        private async void PutItem()
        {
            var confirmationDialog = new ConfirmationDialog("Are you sure you want to modify?");
            confirmationDialog.ShowDialog();

            bool result = await Task.Run(() => confirmationDialog.Result);

            if (result)
            {
                var response = await _backendApiHelper.ModifyFelhasznaloAsync(UpdateItem[0].Id, UpdateItem[0]);
                if (response.IsSuccessStatusCode)
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

                var response = await _backendApiHelper.DeleteFelhasznaloAsync(itemToDelete.Id);
                
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Item deleted successfully!", "Success!", MessageBoxButton.OK);
                }
                else MessageBox.Show("Something went wrong! Please refresh the page and try again!", "Warning!", MessageBoxButton.OKCancel);

            }
        }
        #endregion
        private static bool isTextAllowed(string value)
        {
            return !_regex.IsMatch(value);
        }

        private static bool isEmailAllowed(string value)
        {
            try
            {
                if (value!=null)
                {
                    MailAddress m = new MailAddress(value);
                    return true;
                }
                else
                {
                    
                    return false;
                }
            }
            catch (FormatException)
            {
                return false;
            }
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
            IsPutEnabled = false;
            AddCommand.RaiseCanExecuteChanged();
        }

        private void ModifyItem(Felhasznalo itemToModify)
        {
            UpdateItem.Clear();
            UpdateItem.Add(itemToModify);
            IsSaveEnabled = false;
            IsAddEnabled = true;
            IsPutEnabled = true;

        }


        private bool CanSave()
        {
            return UpdateItem.Count > 0;
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
