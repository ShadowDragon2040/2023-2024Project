using AdatKarbantarto.Utilities;
using MaterialDesignExtensions.Controls;
using MaterialDesignThemes.Wpf;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.ComponentModel;

namespace AdatKarbantarto.ViewModel
{
    public class ImageUploadVM : ViewModelBase, INotifyPropertyChanged
    {
        private string _fileName;
        public string Filename { get;  set; }
        public RelayCommand openfile { get; private set; }
        public RelayCommand uploadfile { get; private set; }

        private string _editorText;
        public string EditorText
        {
            get { return _editorText; }
            set
            {
                if (_editorText != value)
                {
                    _editorText = value;
                    OnPropertyChanged(nameof(EditorText));
                }
            }
        }

        public ImageUploadVM()
        {
            openfile = new RelayCommand(async execute => await OpenFile());
            uploadfile = new RelayCommand(async execute => await UploadFile());
        }

        private async Task OpenFile()
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                EditorText = "Uploading...";
                await Task.Delay(100); // A small delay to update the UI
                Filename = openFileDialog.FileName;
                EditorText=Filename;
            }
        }

        private async Task UploadFile()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential("balintpejko@gmail.com", "printfusion87877");
                    await client.UploadFileTaskAsync(new Uri("ftp://ftp.nethely.hu/test/" + Path.GetFileName(Filename)), "STOR", Filename);
                    EditorText = "Upload successful.";
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                EditorText = "Upload failed: " + ex.Message;
            }
        }

       
    }
}
