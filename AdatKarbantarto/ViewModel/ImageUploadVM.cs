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
        public RelayCommand buttonpressed { get; private set; }
        public RelayCommand uploadpressed { get; private set; }

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
            buttonpressed = new RelayCommand(async execute => await PressButton());
            uploadpressed = new RelayCommand(async execute => await UploadButton());
        }

        private async Task UploadButton()
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                EditorText = "Uploading...";
                await Task.Delay(100); // A small delay to update the UI
                await UploadFile(openFileDialog.FileName);
            }
        }

        private async Task UploadFile(string filePath)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential("balintpejko@gmail.com", "printfusion87877");
                    await client.UploadFileTaskAsync(new Uri("ftp://ftp.nethely.hu/test/" + Path.GetFileName(filePath)), "STOR", filePath);
                    EditorText = "Upload successful.";
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                EditorText = "Upload failed: " + ex.Message;
            }
        }

        private async Task PressButton()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential("balintpejko@gmail.com", "printfusion87877");
                    await client.UploadFileTaskAsync(new Uri("ftp://ftp.nethely.hu"), "STOR", "C:\\file.txt");
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
