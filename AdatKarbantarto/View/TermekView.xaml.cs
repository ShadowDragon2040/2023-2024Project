﻿using AdatKarbantarto.Helpers;
using AdatKarbantarto.Model;
using AdatKarbantarto.Utilities;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdatKarbantarto.View
{
    /// <summary>
    /// Interaction logic for TermekView.xaml
    /// </summary>
    public partial class TermekView : UserControl
    {
        public TermekView()
        {
            InitializeComponent();
            GetTermekek();
            DataContext = this;
        }
        private ObservableCollection<Termek> items;

        public ObservableCollection<Termek> Items
        {
            get { return items ?? (items = new ObservableCollection<Termek>()); }
            set { items = value; }
        }

        public async void GetTermekek()
        {
            try
            {
                BackendApiHelper apiHelper = new BackendApiHelper();
                List<Termek> products = await apiHelper.GetTermekekAsync();
                Items.Clear();
                foreach (var item in products)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public Termek ujtermek;
        private void AddRow_Click(object sender, RoutedEventArgs e)
        {
            ujtermek = new Termek();
            Items.Add(ujtermek);
            btn_add.IsEnabled = false;

        }

        private async void btn_save_Click(object sender, RoutedEventArgs e)
        {
            BackendApiHelper postHelper = new BackendApiHelper();
            var response = await postHelper.PostTermekAsync(ujtermek);
            MessageBox.Show(response.ToString());
            GetTermekek();
            btn_add.IsEnabled = true;
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Termek kivalasztott = dtg_Adatok.SelectedItem as Termek;
            int kivalasztottId = kivalasztott.termekId;
            var confirmationDialog = new ConfirmationDialog("Are you sure you want to delete?");
            confirmationDialog.ShowDialog();

            bool result = await Task.Run(() => confirmationDialog.Result);

            if (result)
            {
                BackendApiHelper deleteHelper = new BackendApiHelper();
                var response = await deleteHelper.DeleteTermekAsync(kivalasztottId);
                MessageBox.Show(response.ToString());
                GetTermekek();
            }
            else
            {
            }
        }
    }
}
