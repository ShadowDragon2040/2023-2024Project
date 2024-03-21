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
    public class TermekekVM : ViewModelBase
    {
        private static readonly Regex _regex = new Regex("[^0-9 ]+");
        private string _searchProductID="";
        private bool _isSaveEnabled;
        private bool _isAddEnabled;
        private Termek _selectedItem;
        private Kategoria _selectedCategory;
        private List<Termek> _ListData;
        private List<Kategoria> _CategoryList;
        private ObservableCollection<Termek> _items;
        private ObservableCollection<Termek> _updateItem;
        private ICollectionView _filteredView;
        public TermekekVM()
        {
            _isSaveEnabled = false;
            _isAddEnabled = true;
            Items = new ObservableCollection<Termek>();
            UpdateItem = new ObservableCollection<Termek>();
            RefreshCommand = new RelayCommand(execute => RefreshItems());
            AddCommand = new RelayCommand(execute => AddItem());
            DeleteCommand = new RelayCommand(execute => DeleteItem(execute as Termek), canExecute => SelectedItem != null);
            ModifyCommand = new RelayCommand(execute => ModifyItem(execute as Termek), canExecute => SelectedItem != null);
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

        public ObservableCollection<Kategoria> Categories { get; }=new ObservableCollection<Kategoria>();

        public Kategoria SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                if (_selectedCategory != value)
                {
                    _selectedCategory = value;
                    OnPropertyChanged(nameof(SelectedCategory));
                  
                }
            }
        }
        public string SearchProductID
        {
            get { return _searchProductID; }
            set
            {
                   
                if (_searchProductID != value&& isTextAllowed(value))
                {
                    _searchProductID = value;
                    OnPropertyChanged(nameof(_searchProductID));
                    ApplyFilter();
                }
            }
        }

        public ObservableCollection<Termek> UpdateItem
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
    
        public ObservableCollection<Termek> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                _filteredView = CollectionViewSource.GetDefaultView(_items);
                ApplyFilter();
            }
        }
        public Termek SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
                if (SelectedCategory != null)
                {
                    SelectedCategory.KategoriaId = SelectedItem.KategoriaId;
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
                _ListData = await apiHelper.GetTermekekAsync();
                _CategoryList= await apiHelper.GetKategoriaAsync();
                Items.Clear();
                foreach (var category in _CategoryList)
                {
                    Categories.Add(category);
                }
                
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

            Termek newProduct = new Termek()
            {
                TermekNev = SelectedItem.TermekNev,
                Ar = SelectedItem.Ar,
                Leiras = SelectedItem.Leiras,
                Menyiseg = SelectedItem.Menyiseg,
                KategoriaId = SelectedCategory.KategoriaId,
                KepUtvonal = SelectedItem.KepUtvonal,
            };
            BackendApiHelper postHelper = new BackendApiHelper();
            var response = await postHelper.PostTermekAsync(newProduct);
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
                UpdateItem[0].KategoriaId = SelectedCategory.KategoriaId;
                var response = await modhelper.ModifyTermekAsync(UpdateItem[0].TermekId, UpdateItem[0]);
                if (response)
                {
                    MessageBox.Show("Product edited successfully!", "Success!", MessageBoxButton.OK);
                }
                else MessageBox.Show("Something went wrong!", "Warning!", MessageBoxButton.OKCancel);
            }
        }
        private async void DeleteItem(Termek itemToDelete)
        {
            var confirmationDialog = new ConfirmationDialog("Are you sure you want to delete?");
            
            confirmationDialog.ShowDialog();

            bool result = await Task.Run(() => confirmationDialog.Result);

            if (result)
            {
                BackendApiHelper deleteHelper = new BackendApiHelper();
                var response = await deleteHelper.DeleteTermekAsync(itemToDelete.TermekId);
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
            Items.Clear();
            LoadInitialData();
        }

        private void AddItem()
        {
            UpdateItem.Clear();
            UpdateItem.Add(new Termek());
            IsAddEnabled = false;
            IsSaveEnabled = true;
            AddCommand.RaiseCanExecuteChanged(); // Notify the UI to re-evaluate AddCommand's CanExecute
        }

        private void ModifyItem(Termek itemToModify)
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
                        if (obj is Termek termek)
                        {
                            // Filter by ProductID 
                            if (int.TryParse(SearchProductID,out int result))
                            {
                                if (result<=int.MaxValue) return termek.TermekId == Convert.ToInt32(SearchProductID);
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
