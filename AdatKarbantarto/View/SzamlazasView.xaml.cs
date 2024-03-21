using AdatKarbantarto.Helpers;
using AdatKarbantarto.Model;
using AdatKarbantarto.Utilities;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using AdatKarbantarto.ViewModel;


namespace AdatKarbantarto.View
{
    /// <summary>
    /// Interaction logic for SzamlaView.xaml
    /// </summary>
    public partial class SzamlazasView : UserControl
    {
        public SzamlazasView()
        {
            InitializeComponent();
            DataContext = new SzamlazasVM();
        }

      

    }
}
