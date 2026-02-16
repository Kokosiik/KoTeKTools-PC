namespace KoTeK_GUI.atmosphere_form
{
    partial class colorcycle_form
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
            this.inp_ready = new KoTeK_GUI.RoundedPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.out_path = new System.Windows.Forms.Label();
            this.roundedPanel1 = new KoTeK_GUI.RoundedPanel();
            this.inp_hex_picker = new KoTeK_GUI.RoundedPanel();
            this.inp_hex = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.inp_ready.SuspendLayout();
            this.roundedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inp_ready
            // 
            this.inp_ready.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.inp_ready.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.inp_ready.Controls.Add(this.label6);
            this.inp_ready.Location = new System.Drawing.Point(207, 143);
            this.inp_ready.Name = "inp_ready";
            this.inp_ready.Size = new System.Drawing.Size(166, 38);
            this.inp_ready.TabIndex = 27;
            this.inp_ready.Click += new System.EventHandler(this.inp_ready_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.label6.Location = new System.Drawing.Point(53, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Создать";
            this.label6.Click += new System.EventHandler(this.inp_ready_Click);
            // 
            // out_path
            // 
            this.out_path.AutoSize = true;
            this.out_path.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.out_path.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.out_path.Location = new System.Drawing.Point(12, 203);
            this.out_path.Name = "out_path";
            this.out_path.Size = new System.Drawing.Size(0, 23);
            this.out_path.TabIndex = 26;
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.roundedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.roundedPanel1.BorderWidth = 3;
            this.roundedPanel1.Controls.Add(this.inp_hex_picker);
            this.roundedPanel1.Controls.Add(this.inp_hex);
            this.roundedPanel1.Location = new System.Drawing.Point(189, 70);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Size = new System.Drawing.Size(200, 38);
            this.roundedPanel1.TabIndex = 24;
            // 
            // inp_hex_picker
            // 
            this.inp_hex_picker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.inp_hex_picker.BackgroundImage = global::KoTeK_GUI.Properties.Resources.color_choice_btn;
            this.inp_hex_picker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.inp_hex_picker.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.inp_hex_picker.BorderWidth = 3;
            this.inp_hex_picker.Location = new System.Drawing.Point(162, 0);
            this.inp_hex_picker.Name = "inp_hex_picker";
            this.inp_hex_picker.Size = new System.Drawing.Size(38, 38);
            this.inp_hex_picker.TabIndex = 13;
            this.inp_hex_picker.Click += new System.EventHandler(this.inp_hex_picker_Click);
            // 
            // inp_hex
            // 
            this.inp_hex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.inp_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inp_hex.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold);
            this.inp_hex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.inp_hex.Location = new System.Drawing.Point(12, 10);
            this.inp_hex.Name = "inp_hex";
            this.inp_hex.Size = new System.Drawing.Size(105, 19);
            this.inp_hex.TabIndex = 0;
            this.inp_hex.Text = "Введите #hex";
            this.inp_hex.Click += new System.EventHandler(this.inp_hex_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.label1.Location = new System.Drawing.Point(197, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Изменение окружения";
            // 
            // colorcycle_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(584, 370);
            this.Controls.Add(this.inp_ready);
            this.Controls.Add(this.out_path);
            this.Controls.Add(this.roundedPanel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "colorcycle_form";
            this.Text = "colorcycle";
            this.inp_ready.ResumeLayout(false);
            this.inp_ready.PerformLayout();
            this.roundedPanel1.ResumeLayout(false);
            this.roundedPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundedPanel inp_ready;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label out_path;
        private RoundedPanel roundedPanel1;
        private RoundedPanel inp_hex_picker;
        private System.Windows.Forms.TextBox inp_hex;
        private System.Windows.Forms.Label label1;
    }
}