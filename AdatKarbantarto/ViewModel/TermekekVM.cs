using AdatKarbantarto.Model;
using AdatKarbantarto.Utilities;
using System.Collections.ObjectModel;

namespace AdatKarbantarto.ViewModel
{
    internal class TermekekVM : ViewModelBase
    {
        public ObservableCollection<Termek> Items { get; set; }
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
            Items = new ObservableCollection<Termek>();
            AddCommand = new RelayCommand(execute => AddItem());
            DeleteCommand = new RelayCommand(execute => DeleteItem(), canExecute => SelectedItem != null);
            ModifyCommand = new RelayCommand(execute => ModifyItem(), canExecute => CanModify());
            SaveCommand = new RelayCommand(execute => SaveItem(), canExecute => CanSave());
        }

        private void AddItem()
        {
            Items.Add(new Termek());
        }

        private void DeleteItem()
        {
            Items.Remove(SelectedItem);
        }

        private void ModifyItem()
        {
            // Implement logic to modify the selected item here
        }

        private bool CanModify()
        {
            return SelectedItem != null;
        }

        private void SaveItem()
        {
            // Implement logic to save items here
        }

        private bool CanSave()
        {
            // Implement logic to determine if saving is allowed
            return true;
        }
    }
}
