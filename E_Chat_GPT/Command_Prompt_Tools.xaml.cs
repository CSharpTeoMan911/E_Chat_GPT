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
    /// Interaction logic for Command_Prompt_Tools.xaml
    /// </summary>
    public partial class Command_Prompt_Tools : Window
    {
        private bool Window_Is_Closing;
        private short Maximised_Or_Normalised;
        private short Menu_Expanded_Or_Contracted;
        private System.Timers.Timer Functionality_Timer = new System.Timers.Timer();

        public Command_Prompt_Tools()
        {
            InitializeComponent();
        }

        private sealed class Tools_Variables_Mitigator:Tools_Variables
        {
            public static Task<bool> Set_If_Command_Prompt_Window_Is_Opened(bool Window_Opened)
            {
                Command_Prompt_Window_Tools_Opened = Window_Opened;
                return Task.FromResult(true);
            }

            public static Task<bool> Get_If_Command_Prompt_Window_Is_Activated()
            {
                return Task.FromResult(Activate_Command_Prompt_Window_Tools_Window);
            }

            public static Task<bool> Set_If_Command_Prompt_Window_Is_Activated(bool Window_Activated)
            {
                Activate_Command_Prompt_Window_Tools_Window = Window_Activated;
                return Task.FromResult(true);
            }

            public static async Task<bool> Interpret_Command_Prompt_Code(string Code)
            {
                return await Command_Prompt_Interpreter(Code);
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

                                switch(Maximised_Or_Normalised)
                                {
                                    case 1:
                                        this.WindowState = WindowState.Maximized;
                                        Maximise_Or_Normalise_Button.Content = "\xEF2F";
                                        break;

                                    case 2:
                                        this.WindowState = WindowState.Normal;
                                        Maximise_Or_Normalise_Button.Content = "\xEF2E";
                                        Maximised_Or_Normalised = 0;
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
                            if (Window_Is_Closing == false)
                            {
                                this.Close();
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
                                Menu_Expanded_Or_Contracted++;
                            }
                        }
                    }
                }
            }
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
                                await Tools_Variables_Mitigator.Interpret_Command_Prompt_Code(Code_TextBox.Text);
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
                                Save_File_MessageBox save_File_MessageBox = new Save_File_MessageBox(Code_TextBox.Text, "Batch");
                                save_File_MessageBox.ShowDialog();
                            }
                        }
                    }
                }
            }
        }


        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Functionality_Timer.Elapsed += Functionality_Timer_Elapsed;
            Functionality_Timer.Interval = 10;
            Functionality_Timer.Start();

            await Tools_Variables_Mitigator.Set_If_Command_Prompt_Window_Is_Opened(true);
        }

        private void Functionality_Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Application.Current != null)
            {
                if (Application.Current.Dispatcher != null)
                {
                    if (Application.Current.Dispatcher.HasShutdownStarted == false)
                    {
                        Application.Current.Dispatcher.Invoke(async() =>
                        {
                            if (Application.Current.MainWindow != null)
                            {
                                if (Window_Is_Closing == false)
                                {
                                    switch (Menu_Expanded_Or_Contracted)
                                    {
                                        case 1:

                                            if (Main_Menu.Height < 120)
                                            {
                                                Main_Menu.Height += 10;
                                            }
                                            break;

                                        case 2:
                                            Main_Menu.Height = 0;
                                            Menu_Expanded_Or_Contracted = 0;
                                            break;
                                    }

                                    if (await Tools_Variables_Mitigator.Get_If_Command_Prompt_Window_Is_Activated() == true)
                                    {
                                        switch (this.WindowState)
                                        {
                                            case WindowState.Minimized:
                                                this.WindowState = WindowState.Normal;
                                                await Tools_Variables_Mitigator.Set_If_Command_Prompt_Window_Is_Activated(false);
                                                break;

                                            default:
                                                this.Activate();
                                                await Tools_Variables_Mitigator.Set_If_Command_Prompt_Window_Is_Activated(false);
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
            await Tools_Variables_Mitigator.Set_If_Command_Prompt_Window_Is_Opened(false);

            if (Functionality_Timer != null)
            {
                Functionality_Timer.Close();
                Functionality_Timer.Dispose();
            }
        }
    }
}
