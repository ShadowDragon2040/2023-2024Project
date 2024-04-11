using AdatKarbantarto.Utilities;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Input;

namespace AdatKarbantarto.ViewModel
{
    class NavigationVM:ViewModelBase
    {
        

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand HomeCommand { get; set; }
        public ICommand FelhasznaloCommand { get; set; }
        public ICommand TermekCommand { get; set; }
        public ICommand HozzaszolasCommand { get; set; }
        public ICommand SzamlazasCommand { get; set; }  
        public ICommand ImageUploadCommand { get; set; }

        private void Home(object obj) => CurrentView = new HomeVM();
        private void Felhasznalo(object obj) => CurrentView = new FelhasznalokVM();
        private void Termek(object obj) => CurrentView = new TermekekVM();
        private void Hozzaszolas(object obj) => CurrentView = new HozzaszolasokVM();
        private void Szamlazas(object obj)=>CurrentView=new SzamlazasVM();
        private void ImageUpload(object obj)=>CurrentView = new ImageUploadVM();

        public NavigationVM()
        {
            InitializeCommands();
            CurrentView = new HomeVM();
        }

       


        private void InitializeCommands()
        {
            HomeCommand = new RelayCommand(Home);
            FelhasznaloCommand = new RelayCommand(Felhasznalo);
            TermekCommand = new RelayCommand(Termek);
            HozzaszolasCommand = new RelayCommand(Hozzaszolas);
            SzamlazasCommand = new RelayCommand(Szamlazas);
            ImageUploadCommand = new RelayCommand(ImageUpload);
        }


    }
}
