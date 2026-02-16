namespace KoTeK_GUI
{
    partial class settings_form
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
            this.label1 = new System.Windows.Forms.Label();
            this.roundedPanel1 = new KoTeK_GUI.RoundedPanel();
            this.roundedPanel2 = new KoTeK_GUI.RoundedPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.roundedPanel3 = new KoTeK_GUI.RoundedPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.roundedPanel4 = new KoTeK_GUI.RoundedPanel();
            this.snow_no = new System.Windows.Forms.Label();
            this.snow_yes = new System.Windows.Forms.Label();
            this.roundedPanel1.SuspendLayout();
            this.roundedPanel2.SuspendLayout();
            this.roundedPanel3.SuspendLayout();
            this.roundedPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.label1.Location = new System.Drawing.Point(82, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(393, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите путь к папке где будут сохратся файлы";
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.roundedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.roundedPanel1.BorderWidth = 3;
            this.roundedPanel1.Controls.Add(this.roundedPanel2);
            this.roundedPanel1.Controls.Add(this.label2);
            this.roundedPanel1.Location = new System.Drawing.Point(12, 44);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Size = new System.Drawing.Size(560, 39);
            this.roundedPanel1.TabIndex = 1;
            // 
            // roundedPanel2
            // 
            this.roundedPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.roundedPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.roundedPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.roundedPanel2.BorderWidth = 3;
            this.roundedPanel2.Controls.Add(this.panel1);
            this.roundedPanel2.Location = new System.Drawing.Point(518, 0);
            this.roundedPanel2.Name = "roundedPanel2";
            this.roundedPanel2.Size = new System.Drawing.Size(42, 39);
            this.roundedPanel2.TabIndex = 2;
            this.roundedPanel2.Click += new System.EventHandler(this.Folder_path_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::KoTeK_GUI.Properties.Resources.folder;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(6, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(30, 30);
            this.panel1.TabIndex = 2;
            this.panel1.Click += new System.EventHandler(this.Folder_path_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 0;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // roundedPanel3
            // 
            this.roundedPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.roundedPanel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.roundedPanel3.BorderWidth = 3;
            this.roundedPanel3.Controls.Add(this.label3);
            this.roundedPanel3.Location = new System.Drawing.Point(12, 109);
            this.roundedPanel3.Name = "roundedPanel3";
            this.roundedPanel3.Size = new System.Drawing.Size(148, 39);
            this.roundedPanel3.TabIndex = 3;
            this.roundedPanel3.Click += new System.EventHandler(this.choice_snow_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.label3.Location = new System.Drawing.Point(51, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Снежинки";
            this.label3.Click += new System.EventHandler(this.choice_snow_Click);
            // 
            // roundedPanel4
            // 
            this.roundedPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.roundedPanel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.roundedPanel4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.roundedPanel4.BorderWidth = 3;
            this.roundedPanel4.Controls.Add(this.snow_no);
            this.roundedPanel4.Controls.Add(this.snow_yes);
            this.roundedPanel4.Location = new System.Drawing.Point(12, 109);
            this.roundedPanel4.Name = "roundedPanel4";
            this.roundedPanel4.Size = new System.Drawing.Size(42, 39);
            this.roundedPanel4.TabIndex = 4;
            // 
            // snow_no
            // 
            this.snow_no.Font = new System.Drawing.Font("Mongolian Baiti", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.snow_no.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.snow_no.Location = new System.Drawing.Point(10, 5);
            this.snow_no.Name = "snow_no";
            this.snow_no.Size = new System.Drawing.Size(25, 25);
            this.snow_no.TabIndex = 5;
            this.snow_no.Text = "✘";
            this.snow_no.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.snow_no.Click += new System.EventHandler(this.choice_snow_Click);
            // 
            // snow_yes
            // 
            this.snow_yes.Font = new System.Drawing.Font("Mongolian Baiti", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.snow_yes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.snow_yes.Location = new System.Drawing.Point(10, 5);
            this.snow_yes.Name = "snow_yes";
            this.snow_yes.Size = new System.Drawing.Size(25, 25);
            this.snow_yes.TabIndex = 5;
            this.snow_yes.Text = "✔";
            this.snow_yes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.snow_yes.Visible = false;
            this.snow_yes.Click += new System.EventHandler(this.choice_snow_Click);
            // 
            // settings_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.roundedPanel4);
            this.Controls.Add(this.roundedPanel3);
            this.Controls.Add(this.roundedPanel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "settings_form";
            this.Text = "settings_form";
            this.roundedPanel1.ResumeLayout(false);
            this.roundedPanel1.PerformLayout();
            this.roundedPanel2.ResumeLayout(false);
            this.roundedPanel3.ResumeLayout(false);
            this.roundedPanel3.PerformLayout();
            this.roundedPanel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private RoundedPanel roundedPanel1;
        private System.Windows.Forms.Label label2;
        private RoundedPanel roundedPanel2;
        private System.Windows.Forms.Panel panel1;
        private RoundedPanel roundedPanel3;
        private System.Windows.Forms.Label label3;
        private RoundedPanel roundedPanel4;
        private System.Windows.Forms.Label snow_no;
        private System.Windows.Forms.Label snow_yes;
    }
}