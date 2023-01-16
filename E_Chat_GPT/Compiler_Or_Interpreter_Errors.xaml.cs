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
        private bool Window_Is_Closing;
        private List<string> Error_List = new List<string>();

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
            for(int count = 0; count < Error_List.Count(); count++)
            {
                if(count > 0)
                {
                    Code_Errors_TextBox.Text += "\n" + Error_List.ElementAt(count) + "\n";

                    if (count % 2 == 0)
                    {
                        Code_Errors_TextBox.Text += "\n\n\n";
                    }
                }
            }
        }
    }
}
