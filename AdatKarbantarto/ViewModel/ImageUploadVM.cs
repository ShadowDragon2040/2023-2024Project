using AdatKarbantarto.Utilities;
using MaterialDesignExtensions.Controls;
using MaterialDesignThemes.Wpf;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Collections.ObjectModel;
using AdatKarbantarto.Helpers;
using AdatKarbantarto.Model;

namespace AdatKarbantarto.ViewModel
{
    public class ImageUploadVM : ViewModelBase
    {
        private string _fileName;
        private List<FtpFile> _uploadedFilesList;
        private ObservableCollection<FtpFile> _uploadedFiles;
        public string Filename { get; set; }
        public ObservableCollection<FtpFile> UploadedFiles { get { return _uploadedFiles; } 
            set
            { 
                _uploadedFiles = value;
                OnPropertyChanged(nameof(UploadedFiles));
            }
        }

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
            UploadedFiles = new ObservableCollection<FtpFile>();
            LoadUploadedFiles();
        }

        private async void LoadUploadedFiles()
        {
            BackendApiHelper apiHelper = new BackendApiHelper();
            _uploadedFilesList = await apiHelper.GetFtpFilesAsync();
            foreach (var file in _uploadedFilesList)
            {
                UploadedFiles.Add(file);
            }
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
                    BackendApiHelper apihelper=new BackendApiHelper();
                    FtpFile newFtpFile = new();
                    newFtpFile.file = Filename;
                    newFtpFile.timestamp=DateTime.Now;
                    await apihelper.PostFtpFileAsync(newFtpFile);
                    UploadedFiles.Clear();
                    LoadUploadedFiles();


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
