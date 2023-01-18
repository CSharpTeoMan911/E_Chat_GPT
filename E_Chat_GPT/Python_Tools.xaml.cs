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

namespace E_Chat_GPT
{
    /// <summary>
    /// Interaction logic for Python_Tools.xaml
    /// </summary>
    public partial class Python_Tools : Window
    {
        private bool Window_Is_Closing;
        private short Maximised_Or_Normalised;
        private short Expand_Or_Contract_The_Main_Menu;
        private System.Timers.Timer Functionality_Timer = new System.Timers.Timer();

        private sealed class Tools_Variables_Mitigator_Class : Tools_Variables
        {
            public static Task<bool> Set_If_Python_Window_Is_Opened(bool Window_Opened)
            {
                Python_Tools_Window_Opened = Window_Opened;
                return Task.FromResult(true);
            }

            public static Task<bool> Get_If_Python_Window_Is_Activated()
            {
                return Task.FromResult(Activate_Python_Tools_Window);
            }

            public static Task<bool> Set_If_Python_Window_Is_Activated(bool Window_Activated)
            {
                Activate_Python_Tools_Window = Window_Activated;
                return Task.FromResult(true);
            }

            public static async Task<bool> Interpret_Python_Code(string Code)
            {
                return await Python_Interpreter(Code);
            }
        }

        public Python_Tools()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Functionality_Timer.Elapsed += Functionality_Timer_Elapsed;
            Functionality_Timer.Interval = 10;
            Functionality_Timer.Start();

            await Tools_Variables_Mitigator_Class.Set_If_Python_Window_Is_Opened(true);
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
                                        switch (Expand_Or_Contract_The_Main_Menu)
                                        {
                                            case 1:
                                                if (Main_Menu.Height < 220)
                                                {
                                                    Main_Menu.Height += 10;
                                                }
                                                break;

                                            case 2:
                                                Expand_Or_Contract_The_Main_Menu = 0;
                                                Main_Menu.Height = 0;
                                                break;
                                        }


                                        if (await Tools_Variables_Mitigator_Class.Get_If_Python_Window_Is_Activated() == true)
                                        {
                                            switch(this.WindowState)
                                            {
                                                case WindowState.Minimized:
                                                    this.WindowState = WindowState.Normal;
                                                    break;

                                                default:
                                                    this.Activate();
                                                    await Tools_Variables_Mitigator_Class.Set_If_Python_Window_Is_Activated(false);
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
                if(Functionality_Timer != null)
                {
                    Functionality_Timer.Stop();
                    Functionality_Timer.Dispose();
                }
            }
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            await Tools_Variables_Mitigator_Class.Set_If_Python_Window_Is_Opened(false);
            Window_Is_Closing = true;

            if (Functionality_Timer != null)
            {
                Functionality_Timer.Stop();
                Functionality_Timer.Dispose();
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

                                    switch(Maximised_Or_Normalised)
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
                                    this.Close();
                                }
                            }
                        }
                    }
                }
            }
        }

        private async void Interpret_Code(object sender, RoutedEventArgs e)
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
                                    await Tools_Variables_Mitigator_Class.Interpret_Python_Code(Code_TextBox.Text);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Install_Dependecies(object sender, RoutedEventArgs e)
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
                                    Pip_Manager pip_Manager = new Pip_Manager(true);
                                    pip_Manager.ShowDialog();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Uninstall_Dependecies(object sender, RoutedEventArgs e)
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
                                    Pip_Manager pip_Manager = new Pip_Manager(false);
                                    pip_Manager.ShowDialog();
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
                                    Save_File_MessageBox file_Name_Selection_Window = new Save_File_MessageBox(Code_TextBox.Text, "Python");
                                    file_Name_Selection_Window.ShowDialog();
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
                                    Expand_Or_Contract_The_Main_Menu++;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Move_Window(object sender, MouseButtonEventArgs e)
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
    }
}
