using System;
using System.IO;
using System.Windows;
using System.Diagnostics;
using System.Windows.Controls;
using AdatKarbantarto.ViewModel;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace AdatKarbantarto.View
{
    public partial class KepFeltoltesView : UserControl
    {
        
        public KepFeltoltesView()
        {
            InitializeComponent();
            DataContext = new ImageUploadVM(); // Set the ViewModel as DataContext
        }

        private async void FileDropPanel_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (file != null && file.Length > 0)
                {
                    try
                    {
                        ((ImageUploadVM)DataContext).EditorText = "Dropped file(s) detected...";
                        await Task.Delay(100); // A small delay to update the UI
                     // Assuming only one file is dropped
                     ((ImageUploadVM)DataContext).Filename= file[0];
                    }
                    catch (Exception ex)
                    {
                        ((ImageUploadVM)DataContext).EditorText = "Error processing dropped file: " + ex.Message;
                    }
                }
            }
        }

        private  void ListBoxItem_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
           
            string file = e.Source.ToString().Split("\\").Last();
           
           
            string url = "http://printfusion.nhely.hu/test/"+file;
           
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Process.Start("xdg-open", url);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Process.Start("open", url);
            }
            else
            {
                // throw 
            }
        }
      
    }
}
