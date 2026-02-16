namespace KoTeK_GUI.color_form
{
    partial class colorbtn_form
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
            this.out_path = new System.Windows.Forms.Label();
            this.check_zip = new System.Windows.Forms.CheckBox();
            this.preview_image = new System.Windows.Forms.PictureBox();
            this.roundedPanel3 = new KoTeK_GUI.RoundedPanel();
            this.listImage = new System.Windows.Forms.ListBox();
            this.roundedPanel4 = new KoTeK_GUI.RoundedPanel();
            this.choice_hex_btn = new KoTeK_GUI.RoundedPanel();
            this.inp_hex = new System.Windows.Forms.TextBox();
            this.btn_color = new KoTeK_GUI.RoundedPanel();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.preview_image)).BeginInit();
            this.roundedPanel3.SuspendLayout();
            this.roundedPanel4.SuspendLayout();
            this.btn_color.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.label1.Location = new System.Drawing.Point(226, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Покраска кнопок";
            // 
            // out_path
            // 
            this.out_path.AutoSize = true;
            this.out_path.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.out_path.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.out_path.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.out_path.Location = new System.Drawing.Point(15, 357);
            this.out_path.Name = "out_path";
            this.out_path.Size = new System.Drawing.Size(0, 16);
            this.out_path.TabIndex = 23;
            // 
            // check_zip
            // 
            this.check_zip.AutoSize = true;
            this.check_zip.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold);
            this.check_zip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.check_zip.Location = new System.Drawing.Point(15, 337);
            this.check_zip.Name = "check_zip";
            this.check_zip.Size = new System.Drawing.Size(146, 20);
            this.check_zip.TabIndex = 22;
            this.check_zip.Text = "Запаковать в zip";
            this.check_zip.UseVisualStyleBackColor = true;
            // 
            // preview_image
            // 
            this.preview_image.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.preview_image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.preview_image.Location = new System.Drawing.Point(250, 35);
            this.preview_image.Name = "preview_image";
            this.preview_image.Size = new System.Drawing.Size(320, 300);
            this.preview_image.TabIndex = 24;
            this.preview_image.TabStop = false;
            // 
            // roundedPanel3
            // 
            this.roundedPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.roundedPanel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.roundedPanel3.Controls.Add(this.listImage);
            this.roundedPanel3.Location = new System.Drawing.Point(12, 160);
            this.roundedPanel3.Name = "roundedPanel3";
            this.roundedPanel3.Size = new System.Drawing.Size(186, 171);
            this.roundedPanel3.TabIndex = 21;
            // 
            // listImage
            // 
            this.listImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.listImage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listImage.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.listImage.FormattingEnabled = true;
            this.listImage.ItemHeight = 14;
            this.listImage.Location = new System.Drawing.Point(3, 3);
            this.listImage.Name = "listImage";
            this.listImage.Size = new System.Drawing.Size(180, 154);
            this.listImage.TabIndex = 7;
            this.listImage.SelectedIndexChanged += new System.EventHandler(this.listImage_SelectedIndexChanged);
            // 
            // roundedPanel4
            // 
            this.roundedPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.roundedPanel4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.roundedPanel4.BorderWidth = 3;
            this.roundedPanel4.Controls.Add(this.choice_hex_btn);
            this.roundedPanel4.Controls.Add(this.inp_hex);
            this.roundedPanel4.Location = new System.Drawing.Point(12, 60);
            this.roundedPanel4.Name = "roundedPanel4";
            this.roundedPanel4.Size = new System.Drawing.Size(186, 38);
            this.roundedPanel4.TabIndex = 19;
            // 
            // choice_hex_btn
            // 
            this.choice_hex_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.choice_hex_btn.BackgroundImage = global::KoTeK_GUI.Properties.Resources.color_choice_btn;
            this.choice_hex_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.choice_hex_btn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.choice_hex_btn.BorderWidth = 3;
            this.choice_hex_btn.Location = new System.Drawing.Point(148, 0);
            this.choice_hex_btn.Name = "choice_hex_btn";
            this.choice_hex_btn.Size = new System.Drawing.Size(38, 38);
            this.choice_hex_btn.TabIndex = 13;
            this.choice_hex_btn.Click += new System.EventHandler(this.choice_hex_btn_Click);
            // 
            // inp_hex
            // 
            this.inp_hex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.inp_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inp_hex.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold);
            this.inp_hex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.inp_hex.Location = new System.Drawing.Point(12, 10);
            this.inp_hex.Name = "inp_hex";
            this.inp_hex.Size = new System.Drawing.Size(98, 19);
            this.inp_hex.TabIndex = 0;
            this.inp_hex.Text = "Введите #hex";
            this.inp_hex.Click += new System.EventHandler(this.inp_hex_Click);
            // 
            // btn_color
            // 
            this.btn_color.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.btn_color.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.btn_color.Controls.Add(this.label3);
            this.btn_color.Location = new System.Drawing.Point(9, 108);
            this.btn_color.Name = "btn_color";
            this.btn_color.Size = new System.Drawing.Size(186, 38);
            this.btn_color.TabIndex = 18;
            this.btn_color.Click += new System.EventHandler(this.color_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.label3.Location = new System.Drawing.Point(55, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Покрасить";
            this.label3.Click += new System.EventHandler(this.color_button_Click);
            // 
            // colorbtn_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.preview_image);
            this.Controls.Add(this.out_path);
            this.Controls.Add(this.check_zip);
            this.Controls.Add(this.roundedPanel3);
            this.Controls.Add(this.roundedPanel4);
            this.Controls.Add(this.btn_color);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "colorbtn_form";
            this.Text = "colorbtn_form";
            ((System.ComponentModel.ISupportInitialize)(this.preview_image)).EndInit();
            this.roundedPanel3.ResumeLayout(false);
            this.roundedPanel4.ResumeLayout(false);
            this.roundedPanel4.PerformLayout();
            this.btn_color.ResumeLayout(false);
            this.btn_color.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private RoundedPanel roundedPanel4;
        private RoundedPanel choice_hex_btn;
        private System.Windows.Forms.TextBox inp_hex;
        private RoundedPanel btn_color;
        private System.Windows.Forms.Label label3;
        private RoundedPanel roundedPanel3;
        private System.Windows.Forms.ListBox listImage;
        private System.Windows.Forms.Label out_path;
        private System.Windows.Forms.CheckBox check_zip;
        private System.Windows.Forms.PictureBox preview_image;
    }
}