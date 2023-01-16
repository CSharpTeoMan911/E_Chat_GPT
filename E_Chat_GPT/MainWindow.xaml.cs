using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace E_Chat_GPT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Timers.Timer Functionality_Timer = new System.Timers.Timer();
        private bool Window_Is_Closing;
        private short Minimised_Or_Maximised;
        private short Contract_Or_Expand_Main_Menu;
        private bool Is_Chat_GPT_Page = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Functionality_Timer.Elapsed += Functionality_Timer_Elapsed;
            Functionality_Timer.Interval = 10;
            Functionality_Timer.Start();
        }

        private sealed class Tools_Variables_Mitigator_Class : Tools_Variables
        {
            public static Task<bool> Get_If_C_Sharp_Window_Is_Opened()
            {
                return Task.FromResult(C_Sharp_Tools_Window_Opened);
            }
        }

        private void Functionality_Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if(Application.Current != null)
            {
                if (Application.Current.Dispatcher != null)
                {
                    if (Application.Current.Dispatcher.HasShutdownStarted == false)
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            if (Application.Current.MainWindow != null)
                            {
                                if (Window_Is_Closing == false)
                                {
                                    switch(Is_Chat_GPT_Page)
                                    {
                                        case true:
                                            switch (Contract_Or_Expand_Main_Menu)
                                            {
                                                case 1:
                                                    if (Main_Menu.Height < Application.Current.MainWindow.Height - 50)
                                                    {
                                                        Main_Menu.Height += 20;
                                                    }
                                                    if (main_DockPanel.Margin.Left < Main_Menu.Width)
                                                    {
                                                        main_DockPanel.Margin = new Thickness(main_DockPanel.Margin.Left + 10, 50, 0, 0);
                                                    }
                                                    break;

                                                case 2:
                                                    main_DockPanel.Margin = new Thickness(0, 50, 0, 0);
                                                    Contract_Or_Expand_Main_Menu = 0;
                                                    Main_Menu.Height = 0;
                                                    break;
                                            }
                                            break;

                                        case false:
                                            main_DockPanel.Margin = new Thickness(0, 50, 0, 0);
                                            Contract_Or_Expand_Main_Menu = 0;
                                            Main_Menu.Height = 0;
                                            break;
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Window_Is_Closing = true;
        }

        private void Main_Navigation_Completed(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
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
                                // SECURITY FEATURE
                                switch(main.CoreWebView2.Source.Contains("login"))
                                {
                                    case true:
                                        Is_Chat_GPT_Page = false;
                                        break;

                                    case false:
                                        Is_Chat_GPT_Page = true;
                                        break;
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
                                Application.Current.MainWindow.WindowState = WindowState.Minimized;
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
                                Minimised_Or_Maximised++;

                                switch(Minimised_Or_Maximised)
                                {
                                    case 1:
                                        Application.Current.MainWindow.WindowState = WindowState.Maximized;
                                        Maximise_Or_Normalise_Button.Content = "\xEF2F";
                                        break;

                                    case 2:
                                        Minimised_Or_Maximised = 0;
                                        Application.Current.MainWindow.WindowState = WindowState.Normal;
                                        Maximise_Or_Normalise_Button.Content = "\xEF2E";
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
                                main.Dispose();
                                Environment.Exit(0);
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
                                Contract_Or_Expand_Main_Menu++;
                            }
                        }
                    }
                }
            }
        }

        private async void Open_C_Sharp_Tools(object sender, RoutedEventArgs e)
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
                                if(await Tools_Variables_Mitigator_Class.Get_If_C_Sharp_Window_Is_Opened() == false)
                                {
                                    C_Sharp_Tools c_sharp = new C_Sharp_Tools();
                                    c_sharp.Show();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
