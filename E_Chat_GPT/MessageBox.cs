using Microsoft.Build.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Chat_GPT
{
    public partial class MessageBox : Form
    {
        private string Error_TextBox_Content_Checkup = String.Empty;
        private List<string> Error_TextBox_Content;
        private bool Loaded;

        public MessageBox(List<string> Error)
        {
            Error_TextBox_Content = Error;
            InitializeComponent();
        }

       
        private void Error_TextBox_TextChanged(object sender, EventArgs e)
        {
            if(Loaded == true)
            {
                switch (Error_TextBox.Text.Length == Error_TextBox_Content_Checkup.Length)
                {
                    case true:
                        Error_TextBox_Content_Checkup = Error_TextBox.Text;
                        break;

                    case false:
                        Error_TextBox.Text = Error_TextBox_Content_Checkup;
                        break;
                }
            }
        }

        private void MessageBox_Load(object sender, EventArgs e)
        {
            int Error_List_Count = Error_TextBox_Content.Count();

            for (int count = 0; count < Error_List_Count; count++)
            {
                if (Error_List_Count > 0)
                {
                    Error_TextBox.AppendText(Error_TextBox_Content.ElementAt(count) + Environment.NewLine + Environment.NewLine);

                    if ((count + 1) % 2 == 0)
                    {
                        Error_TextBox.AppendText(Environment.NewLine + Environment.NewLine);
                    }
                }
            }

            Error_TextBox_Content_Checkup = Error_TextBox.Text;
            Loaded = true;
        }

        ~MessageBox()
        {
            this.Dispose();
        }
    }
}
