using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Chat_GPT
{
    public partial class Save_File_MessageBox : Form
    {
        private string File_Extension;
        private string Code;

        public Save_File_MessageBox(string Selected_Code, string Chosen_Language)
        {
            Code = Selected_Code;

            switch (Chosen_Language)
            {
                case "C_Sharp":
                    File_Extension = ".cs";
                    break;

                case "Python":
                    File_Extension = ".py";
                    break;

                case "Batch":
                    File_Extension = ".bat";
                    break;

                case "PowerShell":
                    File_Extension = ".ps1";
                    break;
            }

            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null || textBox1.Text == String.Empty)
            {
                using (System.Windows.Forms.FolderBrowserDialog file_path_extractor = new System.Windows.Forms.FolderBrowserDialog())
                {
                    if (file_path_extractor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        using (StreamWriter code_file_writer = File.CreateText(file_path_extractor.SelectedPath + "\\" + textBox1.Text + File_Extension))
                        {
                            await code_file_writer.WriteAsync(Code);
                            await code_file_writer.FlushAsync();
                            file_path_extractor.Dispose();
                            code_file_writer.Dispose();
                        }
                    }
                }
            }

            this.Close();
        }

        ~Save_File_MessageBox()
        {
            this.Dispose();
        }
    }
}
