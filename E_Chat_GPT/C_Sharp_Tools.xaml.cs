using System;
using System.Collections.Generic;
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
using System.CodeDom.Compiler;
using System.Diagnostics;
using Microsoft.CSharp;
using System.Web.UI.WebControls;
using System.IO;
using System.Security.Cryptography;
using System.Reflection;

namespace E_Chat_GPT
{
    /// <summary>
    /// Interaction logic for C_Sharp_Tools.xaml
    /// </summary>
    public partial class C_Sharp_Tools : Window
    {
        private bool Window_Is_Closing;
        private short Maximised_Or_Normalised;
        private short Main_Menu_Expanded_Or_Contracted;
        

        private System.Timers.Timer Functionality_Timer = new System.Timers.Timer();


        private sealed class Tools_Variables_Mitigator_Class:Tools_Variables
        {
            public static Task<bool> Set_If_C_Sharp_Window_Is_Opened(bool Window_Opened)
            {
                C_Sharp_Tools_Window_Opened = Window_Opened;
                return Task.FromResult(true);
            }

            public static Task<bool> Get_If_C_Sharp_Window_Is_Activated()
            {
                return Task.FromResult(Activate_C_Sharp_Tools_Window);
            }

            public static Task<bool> Set_If_C_Sharp_Window_Is_Activated(bool Window_Activated)
            {
                Activate_C_Sharp_Tools_Window = Window_Activated;
                return Task.FromResult(true);
            }

            public static async Task<bool> Compile_C_Sharp_Code(string Code)
            {
                return await C_Sharp_Code_Compilation(Code);
            }
        }



        public C_Sharp_Tools()
        {
            InitializeComponent();
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Application.Current != null)
            {
                if (Application.Current.Dispatcher != null)
                {
                    if (Application.Current.Dispatcher.HasShutdownStarted == false)
                    {
                        if (Application.Current.MainWindow != null)
                        {
                            if(this != null)
                            {
                                if(Window_Is_Closing == false)
                                {
                                    Window_Is_Closing = true;
                                    await Tools_Variables_Mitigator_Class.Set_If_C_Sharp_Window_Is_Opened(false);
                                }
                            }
                        }
                    }
                }
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await Tools_Variables_Mitigator_Class.Set_If_C_Sharp_Window_Is_Opened(true);

            Functionality_Timer.Elapsed += Functionality_Timer_Elapsed;
            Functionality_Timer.Interval = 10;
            Functionality_Timer.Start();
        }

        private void Functionality_Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Application.Current != null)
            {
                if (Application.Current.Dispatcher != null)
                {
                    if (Application.Current.Dispatcher.HasShutdownStarted == false)
                    {
                        Application.Current.Dispatcher.Invoke(async () =>
                        {
                            if (Application.Current.MainWindow != null)
                            {
                                if (this != null)
                                {
                                    if (Window_Is_Closing == false)
                                    {
                                        switch (Main_Menu_Expanded_Or_Contracted)
                                        {
                                            case 1:
                                                if (Main_Menu.Height < 120)
                                                {
                                                    Main_Menu.Height += 10;
                                                }
                                                break;

                                            case 2:
                                                Main_Menu_Expanded_Or_Contracted = 0;
                                                Main_Menu.Height = 0;
                                                break;
                                        }

                                        if (await Tools_Variables_Mitigator_Class.Get_If_C_Sharp_Window_Is_Activated() == true)
                                        {
                                            switch (this.WindowState)
                                            {
                                                case WindowState.Minimized:
                                                    this.WindowState = WindowState.Normal;
                                                    break;

                                                default:
                                                    this.Activate();
                                                    await Tools_Variables_Mitigator_Class.Set_If_C_Sharp_Window_Is_Activated(false);
                                                    break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (Functionality_Timer != null)
                                        {
                                            Functionality_Timer.Stop();
                                            Functionality_Timer.Dispose();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (Functionality_Timer != null)
                                {
                                    Functionality_Timer.Stop();
                                    Functionality_Timer.Dispose();
                                }
                            }
                        });
                    }
                    else
                    {
                        if (Functionality_Timer != null)
                        {
                            Functionality_Timer.Stop();
                            Functionality_Timer.Dispose();
                        }
                    }
                }
                else
                {
                    if (Functionality_Timer != null)
                    {
                        Functionality_Timer.Stop();
                        Functionality_Timer.Dispose();
                    }
                }
            }
            else
            {
                if (Functionality_Timer != null)
                {
                    Functionality_Timer.Stop();
                    Functionality_Timer.Dispose();
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
                                if(Window_Is_Closing == false)
                                {
                                    this.WindowState = WindowState.Minimized;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Normalise_Or_Maximise_Window(object sender, RoutedEventArgs e)
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
                                    Maximised_Or_Normalised++;

                                    switch (Maximised_Or_Normalised)
                                    {
                                        case 1:
                                            this.WindowState = WindowState.Maximized;
                                            Maximise_Or_Normalise_Button.Content = "\xEF2F";
                                            break;

                                        case 2:
                                            Maximised_Or_Normalised = 0;
                                            this.WindowState = WindowState.Normal;
                                            Maximise_Or_Normalise_Button.Content = "\xEF2E";
                                            break;
                                    }
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
                                    if(Functionality_Timer != null)
                                    {
                                        Functionality_Timer.Stop();
                                        Functionality_Timer.Dispose();
                                    }

                                    this.Close();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Open_Or_Close_Main_Menu(object sender, RoutedEventArgs e)
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
                                    Main_Menu_Expanded_Or_Contracted++;
                                }
                            }
                        }
                    }
                }
            }
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

        private async void Compile_Code(object sender, RoutedEventArgs e)
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
                                    await Tools_Variables_Mitigator_Class.Compile_C_Sharp_Code(Code_TextBox.Text);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Save_Code(object sender, RoutedEventArgs e)
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
                                    Save_File_MessageBox file_Name_Selection_Window = new Save_File_MessageBox(Code_TextBox.Text, "C_Sharp");
                                    file_Name_Selection_Window.ShowDialog();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
