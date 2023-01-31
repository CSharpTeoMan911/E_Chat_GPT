using Microsoft.Build.Framework.XamlTypes;
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
    public partial class Help_Page : Form
    {
        private string content;

        public Help_Page()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = content;
        }

        private void Help_Page_Load(object sender, EventArgs e)
        {
            content = textBox1.Text;
            this.ActiveControl = label1;
        }
    }
}
