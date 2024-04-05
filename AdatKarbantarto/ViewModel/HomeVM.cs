using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdatKarbantarto.ViewModel
{
    public class HomeVM
    {
        private SecureString _secureString;

        public HomeVM(SecureString secureString)
        {
            SecureString = secureString;
           
        }

        public SecureString SecureString { get => _secureString; set => _secureString = value; }
    }
}
