using AdatKarbantarto.Helpers;
using AdatKarbantarto.Model;
using AdatKarbantarto.Utilities;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Security;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Data;


namespace AdatKarbantarto.ViewModel
{
    public class SzamlazasVM : ViewModelBase
    {
        private BackendApiHelper _backendApiHelper;
        private static readonly Regex _regex = new Regex("[^0-9 ]+");
        private string _searchProductID = "";
        private bool _isSaveEnabled;
        private bool _isAddEnabled;
        private Szamla _selectedItem;
        private List<Szamla> _ListData;
        private ObservableCollection<Szamla> _items;
        private ObservableCollection<Szamla> _updateItem;
        private ICollectionView _filteredView;
        public SzamlazasVM()
        {
            _isSaveEnabled = false;
            _isAddEnabled = true;
            _backendApiHelper=new BackendApiHelper();
            SzamlaItems = new ObservableCollection<Szamla>();
            UpdateItem = new ObservableCollection<Szamla>();
            RefreshCommand = new RelayCommand(execute => RefreshItems());
            AddCommand = new RelayCommand(execute => AddItem());
            DeleteCommand = new RelayCommand(execute => DeleteItem(execute as Szamla));
            ModifyCommand = new RelayCommand(execute => ModifyItem(execute as Szamla));
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

                var resp = await _backendApiHelper.GetSzamlazasAsync();


                if (resp.Data != null)
                {
                    _ListData = resp.Data;

                }
                else
                {
                    MessageBox.Show(resp.ErrorMessage);
                }
                SzamlaItems.Clear();
              

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

            Szamla newOrder = new Szamla()
            {
                SzamlazasId = SelectedItem.SzamlazasId,
                UserId = SelectedItem.UserId,
                TermekId = SelectedItem.TermekId,
                SzinHex = SelectedItem.SzinHex,
                VasarlasIdopontja = DateTime.Now,
                SikeresSzalitas = false,
            };
          
            var response = await _backendApiHelper.PostSzamlaAsync(newOrder);
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
              
              
                var response = await _backendApiHelper.ModifySzamlaAsync(UpdateItem[0].SzamlazasId, UpdateItem[0]);
                if (response)
                {
                    MessageBox.Show("Item edited successfully!", "Success!", MessageBoxButton.OK);
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
                
                var response = await _backendApiHelper.DeleteSzamlaAsync(itemToDelete.SzamlazasId);
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
                                if (result <= int.MaxValue) return Szamla.SzamlazasId == Convert.ToInt32(SearchProductID);
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
