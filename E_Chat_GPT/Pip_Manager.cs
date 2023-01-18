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
    public partial class Pip_Manager : Form
    {
        private bool Is_Package_Installed;

        private sealed class Tools_Variables_Mitigator_Class : Tools_Variables
        {
            public static async Task<bool> Install_Python_Pakage(string Package_Name)
            {
                return await Python_Interpreter_Pip_Install(Package_Name);
            }

            public static async Task<bool> Unnstall_Python_Pakage(string Package_Name)
            {
                return await Python_Interpreter_Pip_Uninstall(Package_Name);
            }
        }

        public Pip_Manager(bool Install_Package)
        {
            Is_Package_Installed = Install_Package;
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            switch(Is_Package_Installed)
            {
                case true:
                    await Tools_Variables_Mitigator_Class.Install_Python_Pakage(textBox1.Text);
                    break;

                case false:
                    await Tools_Variables_Mitigator_Class.Unnstall_Python_Pakage(textBox1.Text);
                    break;
            }

            this.Close();
        }


        ~Pip_Manager()
        {
            this.Dispose();
        }
    }
}
