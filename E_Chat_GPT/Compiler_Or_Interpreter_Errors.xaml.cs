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
    /// Interaction logic for Compiler_Or_Interpreter_Errors.xaml
    /// </summary>
    public partial class Compiler_Or_Interpreter_Errors : Window
    {
        protected bool Window_Is_Closing;
        private List<string> Error_List;

        public Compiler_Or_Interpreter_Errors(List<string> Error_List_Parameter)
        {
            Error_List = Error_List_Parameter;
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
                            if(this != null)
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
                                    Window_Is_Closing = false;
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            int Error_List_Count = Error_List.Count();

            for (int count = 0; count < Error_List_Count; count++)
            {
                if (Error_List_Count > 0)
                {
                    Code_Errors_TextBox.Text += "\n" + Error_List.ElementAt(count) + "\n";

                    if ((count + 1) % 2 == 0)
                    {
                        Code_Errors_TextBox.Text += "\n\n";
                    }
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Window_Is_Closing = true;
        }
    }
}
