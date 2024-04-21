﻿using AdatKarbantarto.Helpers;
using AdatKarbantarto.Model;
using AdatKarbantarto.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using System.Security;

namespace AdatKarbantarto.ViewModel
{
    public class HozzaszolasokVM : ViewModelBase
    {
        private BackendApiHelper _backendApiHelper;
        private static readonly Regex _regex = new Regex("[^0-9 ]+");
        private string _searchProductID = "";
        private bool _isSaveEnabled;
        private bool _isAddEnabled;
        private bool _isPutEnabled;
        private Hozzaszolas _selectedItem;
        private List<Hozzaszolas> _ListData;
        private ObservableCollection<Hozzaszolas> _items;
        private ObservableCollection<Hozzaszolas> _updateItem;
        private ICollectionView _filteredView;
        public HozzaszolasokVM()
        {
            _isPutEnabled = false;
            _isSaveEnabled = false;
            _isAddEnabled = true;
            _backendApiHelper=new BackendApiHelper();
            HozzaszolasItems = new ObservableCollection<Hozzaszolas>();
            UpdateItem = new ObservableCollection<Hozzaszolas>();
            RefreshCommand = new RelayCommand(execute => RefreshItems());
            AddCommand = new RelayCommand(execute => AddItem());
            DeleteCommand = new RelayCommand(execute => DeleteItem(execute as Hozzaszolas));
            ModifyCommand = new RelayCommand(execute => ModifyItem(execute as Hozzaszolas));
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

        public ObservableCollection<Hozzaszolas> UpdateItem
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

        public ObservableCollection<Hozzaszolas> HozzaszolasItems
        {
            get { return _items; }
            set
            {
                _items = value;
                _filteredView = CollectionViewSource.GetDefaultView(_items);
                ApplyFilter();
            }
        }
        public Hozzaszolas SelectedItem
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

        public SecureString JwtToken { get; }
        #endregion
        #region CRUD
        private async void LoadInitialData()
        {
            // Load data into Items collection 
            try
            {
                var resp = await _backendApiHelper.GetHozzaszolasAsync();


                if (resp.Data != null)
                {
                    _ListData = resp.Data;

                }
                else
                {
                    MessageBox.Show(resp.ErrorMessage);
                }

                HozzaszolasItems.Clear();
                foreach (var Hozzaszolas in _ListData)
                {
                    HozzaszolasItems.Add(Hozzaszolas);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private async void SaveItem()
        {
            if (SelectedItem != null)
            {
                Hozzaszolas newProduct = new Hozzaszolas()
                {
                    HozzaszolasId = SelectedItem.HozzaszolasId,
                    UserId = SelectedItem.UserId.ToString(),
                    TermekId = SelectedItem.TermekId,
                    Leiras = SelectedItem.Leiras,
                    Ertekeles = SelectedItem.Ertekeles,
                };
               
                var response = await _backendApiHelper.PostHozzaszolasAsync(newProduct);
                if (response)
                {
                    MessageBox.Show("Comment added successfully!"); 
                }
                else
                {
                    MessageBox.Show("Something went wrong! Refresh the page and try again!");
                }

                IsAddEnabled = true;
                IsSaveEnabled = false;
                IsPutEnabled = false;
                SaveCommand.RaiseCanExecuteChanged(); // Notify the UI to re-evaluate SaveCommand's CanExecute
            }
            else
            {
                MessageBox.Show("No item selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void PutItem()
        {
            var confirmationDialog = new ConfirmationDialog("Are you sure you want to modify?");
            confirmationDialog.ShowDialog();

            bool result = await Task.Run(() => confirmationDialog.Result);

            if (result)
            {
               
               
                var response = await _backendApiHelper.ModifyHozzaszolasAsync(UpdateItem[0].HozzaszolasId, UpdateItem[0]);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Item edited successfully!", "Success!", MessageBoxButton.OK);
                }
                else MessageBox.Show("Something went wrong!", "Warning!", MessageBoxButton.OKCancel);
            }
        }
        private async void DeleteItem(Hozzaszolas itemToDelete)
        {
            var confirmationDialog = new ConfirmationDialog("Are you sure you want to delete?");

            confirmationDialog.ShowDialog();

            bool result = await Task.Run(() => confirmationDialog.Result);

            if (result)
            {
            
                var response = await _backendApiHelper.DeleteHozzaszolasAsync(itemToDelete.HozzaszolasId);
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
            HozzaszolasItems.Clear();
            LoadInitialData();
        }

        private void AddItem()
        {
            UpdateItem.Clear();
            UpdateItem.Add(new Hozzaszolas());
            IsAddEnabled = false;
            IsSaveEnabled = true;
            IsPutEnabled = false;
            AddCommand.RaiseCanExecuteChanged(); // Notify the UI to re-evaluate AddCommand's CanExecute
        }

        private void ModifyItem(Hozzaszolas HozzaszolasToModify)
        {
            UpdateItem.Clear();

            UpdateItem.Add(HozzaszolasToModify);
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
                        if (obj is Hozzaszolas Hozzaszolas)
                        {
                            // Filter by ProductID 
                            if (int.TryParse(SearchProductID, out int result))
                            {
                                if (result <= int.MaxValue) return Hozzaszolas.HozzaszolasId == Convert.ToInt32(SearchProductID);
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
