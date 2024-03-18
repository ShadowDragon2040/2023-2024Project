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
        public ObservableCollection<Termek> UpdateItem { get; set; }

        #region Commands
        public RelayCommand RefreshCommand { get; private set; }
        public RelayCommand AddCommand { get; private set; }
        public RelayCommand DeleteCommand { get; private set; }
        public RelayCommand ModifyCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand PutCommand { get; private set; }    
        #endregion
        #region Getters/Setters
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
        #endregion


        public TermekekVM()
        {
            isSaveEnabled = false;
            isAddEnabled = true;
            Items = new ObservableCollection<Termek>();
            UpdateItem = new ObservableCollection<Termek>();
            RefreshCommand = new RelayCommand(execute => RefreshItems());
            AddCommand = new RelayCommand(execute => AddItem());
            DeleteCommand = new RelayCommand(execute => DeleteItem(execute as Termek), canExecute => SelectedItem != null);
            ModifyCommand = new RelayCommand(execute => ModifyItem(execute as Termek), canExecute => CanModify());
            SaveCommand = new RelayCommand(execute => SaveItem(), canExecute => CanSave());
            PutCommand = new RelayCommand(execute => PutItem());
            

            LoadInitialData();
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

        private async void SaveItem()
        {
            // Implement logic to save items here

            Termek newProduct = new Termek()
            {
                TermekNev = SelectedItem.TermekNev,
                Ar = SelectedItem.Ar,
                Leiras = SelectedItem.Leiras,
                Menyiseg = SelectedItem.Menyiseg,
                KategoriaId = SelectedItem.KategoriaId,
                KepUtvonal = SelectedItem.KepUtvonal,
            };
            BackendApiHelper postHelper = new BackendApiHelper();
            var response = await postHelper.PostTermekAsync(newProduct);
            MessageBox.Show(response.ToString());
          

            IsAddEnabled = true;
            IsSaveEnabled = false;
            SaveCommand.RaiseCanExecuteChanged(); // Notify the UI to re-evaluate SaveCommand's CanExecute
        }


        private async void DeleteItem(Termek itemToDelete)
        {
            var confirmationDialog = new ConfirmationDialog("Are you sure you want to delete?");
            confirmationDialog.ShowDialog();

            bool result = await Task.Run(() => confirmationDialog.Result);

            if (result)
            {
                BackendApiHelper deleteHelper = new BackendApiHelper();
                var response = await deleteHelper.DeleteTermekAsync(itemToDelete.termekId);
                MessageBox.Show(response.ToString());
             
            }
        }

        private  void ModifyItem(Termek itemToModify)
        {
            // Implement logic to modify the selected item here
           
            UpdateItem.Clear();
            UpdateItem.Add(itemToModify);
        }

        private async void PutItem()
        {
            var confirmationDialog = new ConfirmationDialog("Are you sure you want to modify?");
            confirmationDialog.ShowDialog();

            bool result = await Task.Run(() => confirmationDialog.Result);

            if (result)
            {
                BackendApiHelper modhelper = new BackendApiHelper();
                var response = await modhelper.ModifyTermekAsync(UpdateItem[0].termekId, UpdateItem[0]);
                MessageBox.Show(response.ToString());
            }
        }

        private bool CanModify() => SelectedItem != null;

     

        private bool CanSave()
        {
            // Implement logic to determine if saving is allowed
            return true;
        }
    }
}
