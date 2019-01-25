

namespace MoniBase64
{
    partial class Form1
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
            this.PrzyciskDoKodowania = new System.Windows.Forms.Button();
            this.PrzycikdoOdkodowania = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // PrzyciskDoKodowania
            // 
            this.PrzyciskDoKodowania.BackColor = System.Drawing.SystemColors.HotTrack;
            this.PrzyciskDoKodowania.Location = new System.Drawing.Point(189, 41);
            this.PrzyciskDoKodowania.Margin = new System.Windows.Forms.Padding(4);
            this.PrzyciskDoKodowania.Name = "PrzyciskDoKodowania";
            this.PrzyciskDoKodowania.Size = new System.Drawing.Size(256, 116);
            this.PrzyciskDoKodowania.TabIndex = 0;
            this.PrzyciskDoKodowania.Text = "Znajdź plik tekstowy i zakoduj BASE64";
            this.PrzyciskDoKodowania.UseVisualStyleBackColor = false;
            this.PrzyciskDoKodowania.Click += new System.EventHandler(this.PrzyciskDoKodowania_Click);
            // 
            // PrzycikdoOdkodowania
            // 
            this.PrzycikdoOdkodowania.BackColor = System.Drawing.SystemColors.HotTrack;
            this.PrzycikdoOdkodowania.ForeColor = System.Drawing.SystemColors.InfoText;
            this.PrzycikdoOdkodowania.Location = new System.Drawing.Point(527, 41);
            this.PrzycikdoOdkodowania.Margin = new System.Windows.Forms.Padding(4);
            this.PrzycikdoOdkodowania.Name = "PrzycikdoOdkodowania";
            this.PrzycikdoOdkodowania.Size = new System.Drawing.Size(256, 116);
            this.PrzycikdoOdkodowania.TabIndex = 1;
            this.PrzycikdoOdkodowania.Text = "Znajdź plik tekstowy i odkoduj BASE64";
            this.PrzycikdoOdkodowania.UseVisualStyleBackColor = false;
            this.PrzycikdoOdkodowania.Click += new System.EventHandler(this.PrzyciskDoOdkodowania_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(27, 181);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(910, 258);
            this.listBox1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 496);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.PrzycikdoOdkodowania);
            this.Controls.Add(this.PrzyciskDoKodowania);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PrzyciskDoKodowania;
        private System.Windows.Forms.Button PrzycikdoOdkodowania;
        private System.Windows.Forms.ListBox listBox1;
       
    }
}

