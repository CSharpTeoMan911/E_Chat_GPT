namespace E_Chat_GPT
{
    partial class MessageBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Error_TextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Error_TextBox
            // 
            this.Error_TextBox.AcceptsReturn = true;
            this.Error_TextBox.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Error_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Error_TextBox.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_TextBox.ForeColor = System.Drawing.Color.LightGray;
            this.Error_TextBox.Location = new System.Drawing.Point(22, 70);
            this.Error_TextBox.Multiline = true;
            this.Error_TextBox.Name = "Error_TextBox";
            this.Error_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Error_TextBox.Size = new System.Drawing.Size(353, 184);
            this.Error_TextBox.TabIndex = 0;
            this.Error_TextBox.TextChanged += new System.EventHandler(this.Error_TextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(163, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 45);
            this.label2.TabIndex = 1;
            this.label2.Text = ":( ";
            // 
            // MessageBox
            // 
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(375, 254);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Error_TextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "MessageBox";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.MessageBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Error_TextBox;
        private System.Windows.Forms.Label label2;
    }
}