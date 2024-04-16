using AdatKarbantarto.Utilities;
using MaterialDesignExtensions.Controls;
using MaterialDesignThemes.Wpf;
using System;
using System.IO;
using System.Net;
using System.Configuration;
using Microsoft.Win32;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Collections.ObjectModel;
using AdatKarbantarto.Helpers;
using AdatKarbantarto.Model;
using System.Windows;
using System.Security;
using System.Linq;

namespace AdatKarbantarto.ViewModel
{
    public class ImageUploadVM : ViewModelBase
    {
        private string _labelText;
        private string _editorText;

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


        public string LabelText
        {
            get { return _labelText; }
            set
            {
                if (_labelText != value)
                {
                    _labelText = value;
                    OnPropertyChanged(nameof(LabelText));
                }
            }
        }
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

        public SecureString JwtToken { get; }

        public ImageUploadVM()
        {
            openfile = new RelayCommand(async execute => await OpenFile());
            uploadfile = new RelayCommand(async execute => await UploadFile());
            UploadedFiles = new ObservableCollection<FtpFile>();
            LoadUploadedFiles();
        }

        public ImageUploadVM(SecureString jwtToken)
        {
            JwtToken = jwtToken;
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
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == true)
            {
                LabelText = "Uploading File...";
                EditorText = "Uploading...";
                await Task.Delay(100); // A small delay to update the UI
                Filename = openFileDialog.FileName;
                EditorText = Path.GetFileName(Filename);
                LabelText = "File detected: " + Path.GetFileName(Filename);
            }
        }

        private async Task UploadFile()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["ftpUser"], ConfigurationManager.AppSettings["ftpPass"]);
                        await client.UploadFileTaskAsync(new Uri(ConfigurationManager.AppSettings["ftpServer"] + Path.GetFileName(Filename)), "STOR", Filename);
                        EditorText = "Upload successful.";
                        LabelText = "Upload successful.";

                        BackendApiHelper apihelper = new BackendApiHelper();
                        FtpFile newFtpFile = new FtpFile()
                        {
                            file = Path.GetFileName(Filename),
                            timestamp = DateTime.Now
                        };
                        await apihelper.PostFtpFileAsync(newFtpFile);

                        UploadedFiles.Clear();
                        LoadUploadedFiles();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error uploading file: {ex.Message}");
                        EditorText = "Upload failed.";
                        LabelText = "Upload failed!";
                    }
                }

            }
            catch (Exception ex)
            {
                LabelText = "Upload failed!" +ex.Message;
            }
        }

       
    }
}
