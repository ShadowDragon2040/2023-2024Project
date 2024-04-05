using AdatKarbantarto.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows;

namespace AdatKarbantarto.ViewModel
{
    public class HomeVM : ViewModelBase
    {
      
        
        private static string ConvertSecureStringToString(SecureString secureString)
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                ptr = Marshal.SecureStringToBSTR(secureString);
                return Marshal.PtrToStringBSTR(ptr);
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Marshal.ZeroFreeBSTR(ptr);
            }
        }

        private JwtSecurityToken JwtDecode(SecureString token)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            string tokenString = ConvertSecureStringToString(token);
            return handler.ReadJwtToken(tokenString);
        }

        private JwtSecurityToken _tokenDecoded;
        private string _jwtToken;
        private SecureString _secureString;
        private string _labelContent;
        private string _name;

        public HomeVM()
        {
        }
        public HomeVM(SecureString secureString) : this()
        {
            SecureString = secureString;
            SetLabelContent();
        }

        public void SetLabelContent()
        {
            
            TokenDecoded = JwtDecode(SecureString);

            if (TokenDecoded.Payload.TryGetValue("name", out object nameValue))
            {
                Name = nameValue.ToString();
            }
        }

        public SecureString SecureString
        {
            get => _secureString;
            set { _secureString = value; OnPropertyChanged(); }
        }

        public string LabelContent
        {
            get => _labelContent;
            set { _labelContent = value; OnPropertyChanged(); }
        }

        public string JwtToken
        {
            get => _jwtToken;
            set => _jwtToken = value;
        }

        public JwtSecurityToken TokenDecoded
        {
            get => _tokenDecoded;
            set => _tokenDecoded = value;
        }
        public string Name { get => _name; set { _name = value; OnPropertyChanged(); } }
    }
}
