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
    /// Interaction logic for PowerShell_Tools.xaml
    /// </summary>
    public partial class PowerShell_Tools : Window
    {
        private bool Window_Is_Closing;
        private short Maximised_Or_Normalised;
        private short Expand_Or_Contract_The_Main_Menu;
        private System.Timers.Timer Functionality_Timer = new System.Timers.Timer();


        private sealed class Tools_Variables_Mitigator_Class : Tools_Variables
        {
            public static Task<bool> Set_If_PowerShell_Window_Is_Opened(bool Window_Opened)
            {
                PowerShell_Tools_Window_Opened = Window_Opened;
                return Task.FromResult(true);
            }

            public static Task<bool> Get_If_PowerShell_Window_Is_Activated()
            {
                return Task.FromResult(Activate_PowerShell_Tools_Window);
            }

            public static Task<bool> Set_If_PowerShell_Window_Is_Activated(bool Window_Activated)
            {
                Activate_PowerShell_Tools_Window = Window_Activated;
                return Task.FromResult(true);
            }

            public static async Task<bool> Interpret_PowerShell_Code(string Code)
            {
                return await PowerShell_Interpreter(Code);
            }
        }


        public PowerShell_Tools()
        {
            InitializeComponent();
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
                            if (Window_Is_Closing == false)
                            {
                                this.WindowState = WindowState.Minimized;
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
                            if (Window_Is_Closing == false)
                            {
                                Maximised_Or_Normalised++;

                                switch (Maximised_Or_Normalised)
                                {
                                    case 1:
                                        Maximise_Or_Normalise_Button.Content = "\xEF2F";
                                        this.WindowState = WindowState.Maximized;
                                        break;

                                    case 2:
                                        Maximised_Or_Normalised = 0;
                                        Maximise_Or_Normalise_Button.Content = "\xEF2E";
                                        this.WindowState = WindowState.Normal;
                                        break;
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
                            if (Functionality_Timer != null)
                            {
                                Functionality_Timer.Stop();
                                Functionality_Timer.Dispose();
                            }

                            if (Window_Is_Closing == false)
                            {
                                this.Close();
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
                            if (Window_Is_Closing == false)
                            {
                                this.DragMove();
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
                            if (Window_Is_Closing == false)
                            {
                                Expand_Or_Contract_The_Main_Menu++;
                            }
                        }
                    }
                }
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await Tools_Variables_Mitigator_Class.Set_If_PowerShell_Window_Is_Opened(true);

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
                                if (Window_Is_Closing == false)
                                {
                                    switch (Expand_Or_Contract_The_Main_Menu)
                                    {
                                        case 1:

                                            if (Main_Menu.Height < 120)
                                            {
                                                Main_Menu.Height += 10;
                                            }
                                            break;

                                        case 2:
                                            Expand_Or_Contract_The_Main_Menu = 0;
                                            Main_Menu.Height = 0;
                                            break;
                                    }

                                    if(await Tools_Variables_Mitigator_Class.Get_If_PowerShell_Window_Is_Activated() == true)
                                    {
                                        switch(this.WindowState)
                                        {
                                            case WindowState.Minimized:
                                                this.WindowState = WindowState.Normal;
                                                break;

                                            default:
                                                this.Activate();
                                                await Tools_Variables_Mitigator_Class.Set_If_PowerShell_Window_Is_Activated(false);
                                                break;
                                        }
                                    }
                                }
                                else
                                {
                                    if (Functionality_Timer != null)
                                    {
                                        Functionality_Timer.Close();
                                        Functionality_Timer.Dispose();
                                    }
                                }
                            }
                            else
                            {
                                if (Functionality_Timer != null)
                                {
                                    Functionality_Timer.Close();
                                    Functionality_Timer.Dispose();
                                }
                            }
                        });
                    }
                    else
                    {
                        if (Functionality_Timer != null)
                        {
                            Functionality_Timer.Close();
                            Functionality_Timer.Dispose();
                        }
                    }
                }
                else
                {
                    if (Functionality_Timer != null)
                    {
                        Functionality_Timer.Close();
                        Functionality_Timer.Dispose();
                    }
                }
            }
            else
            {
                if(Functionality_Timer != null)
                {
                    Functionality_Timer.Close();
                    Functionality_Timer.Dispose();
                }
            }
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Window_Is_Closing = true;

            if (Functionality_Timer != null)
            {
                Functionality_Timer.Close();
                Functionality_Timer.Dispose();
            }

            await Tools_Variables_Mitigator_Class.Set_If_PowerShell_Window_Is_Opened(false);
        }

        private async void Run_Code(object sender, RoutedEventArgs e)
        {
            if (Application.Current != null)
            {
                if (Application.Current.Dispatcher != null)
                {
                    if (Application.Current.Dispatcher.HasShutdownStarted == false)
                    {
                        if (Application.Current.MainWindow != null)
                        {
                            if (Window_Is_Closing == false)
                            {
                                await Tools_Variables_Mitigator_Class.Interpret_PowerShell_Code(Code_TextBox.Text);
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
                            if (Window_Is_Closing == false)
                            {
                                Save_File_MessageBox save_File_MessageBox = new Save_File_MessageBox(Code_TextBox.Text, "PowerShell");
                                save_File_MessageBox.ShowDialog();
                            }
                        }
                    }
                }
            }
        }
    }
}
