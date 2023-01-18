using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace E_Chat_GPT
{
    /// <summary>
    /// Interaction logic for File_Name_Selection_Window.xaml
    /// </summary>
    public partial class File_Name_Selection_Window : Window
    {
        private bool Window_Is_Closing;
        private string File_Extension;
        private string Code;


        public File_Name_Selection_Window(string Selected_Code, string Chosen_Language)
        {
            Code = Selected_Code;

            switch(Chosen_Language)
            {
                case "C_Sharp":
                    File_Extension = ".cs";
                    break;

                case "Python":
                    File_Extension = ".py";
                    break;

                case "Batch":
                    File_Extension = ".bat";
                    break;

                case "PowerShell":
                    File_Extension = ".ps1";
                    break;
            }

            InitializeComponent();
        }

        private void Move_The_Window(object sender, MouseButtonEventArgs e)
        {
            if (Application.Current != null)
            {
                if (Application.Current.Dispatcher != null)
                {
                    if (Application.Current.Dispatcher.HasShutdownStarted == false)
                    {
                        if (Application.Current.MainWindow != null)
                        {
                            if (this != null)
                            {
                                if (Window_Is_Closing == false)
                                {
                                    this.DragMove();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Minimise_Window(object sender, RoutedEventArgs e)
        {
            if (Application.Current != null)
            {
                if (Application.Current.Dispatcher != null)
                {
                    if (Application.Current.Dispatcher.HasShutdownStarted == false)
                    {
                        if (Application.Current.MainWindow != null)
                        {
                            if (this != null)
                            {
                                if (Window_Is_Closing == false)
                                {
                                    this.WindowState = WindowState.Minimized;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Close_Window(object sender, RoutedEventArgs e)
        {
            if (Application.Current != null)
            {
                if (Application.Current.Dispatcher != null)
                {
                    if (Application.Current.Dispatcher.HasShutdownStarted == false)
                    {
                        if (Application.Current.MainWindow != null)
                        {
                            if (this != null)
                            {
                                if (Window_Is_Closing == false)
                                {
                                    this.Close();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Window_Is_Closing = true;
        }

        private async void Select_The_File_Name(object sender, RoutedEventArgs e)
        {
            if (Application.Current != null)
            {
                if (Application.Current.Dispatcher != null)
                {
                    if (Application.Current.Dispatcher.HasShutdownStarted == false)
                    {
                        if (Application.Current.MainWindow != null)
                        {
                            if (this != null)
                            {
                                if (Window_Is_Closing == false)
                                {
                                    if (File_Name_TextBox.Text != null || File_Name_TextBox.Text == String.Empty)
                                    {
                                        using (System.Windows.Forms.FolderBrowserDialog file_path_extractor = new System.Windows.Forms.FolderBrowserDialog())
                                        {
                                            if (file_path_extractor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                            {
                                                using (StreamWriter code_file_writer = File.CreateText(file_path_extractor.SelectedPath + "\\" + File_Name_TextBox.Text + File_Extension))
                                                {
                                                    await code_file_writer.WriteAsync(Code);
                                                    await code_file_writer.FlushAsync();
                                                    file_path_extractor.Dispose();
                                                    code_file_writer.Dispose();
                                                }
                                            }
                                        }
                                    }

                                    this.Close();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
