using AdatKarbantarto.ViewModel;
using System.Windows.Controls;


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
            DataContext = new TermekekVM();
         
        }
       

    }
}
