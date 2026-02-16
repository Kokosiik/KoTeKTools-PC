namespace KoTeK_GUI.convert_form
{
    partial class btxpng_form
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
            this.check_zip = new System.Windows.Forms.CheckBox();
            this.preview_image = new System.Windows.Forms.PictureBox();
            this.out_path = new System.Windows.Forms.Label();
            this.convert_btn = new KoTeK_GUI.RoundedPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_choice = new KoTeK_GUI.RoundedPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.roundedPanel3 = new KoTeK_GUI.RoundedPanel();
            this.listImage = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.preview_image)).BeginInit();
            this.convert_btn.SuspendLayout();
            this.btn_choice.SuspendLayout();
            this.roundedPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.label1.Location = new System.Drawing.Point(228, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "Конвертация";
            // 
            // check_zip
            // 
            this.check_zip.AutoSize = true;
            this.check_zip.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold);
            this.check_zip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.check_zip.Location = new System.Drawing.Point(12, 320);
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
            this.preview_image.Location = new System.Drawing.Point(242, 40);
            this.preview_image.Name = "preview_image";
            this.preview_image.Size = new System.Drawing.Size(330, 300);
            this.preview_image.TabIndex = 23;
            this.preview_image.TabStop = false;
            this.preview_image.DragDrop += new System.Windows.Forms.DragEventHandler(this.btxpng_form_DragDrop);
            this.preview_image.DragEnter += new System.Windows.Forms.DragEventHandler(this.btxpng_form_DragEnter);
            // 
            // out_path
            // 
            this.out_path.AutoSize = true;
            this.out_path.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.out_path.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.out_path.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.out_path.Location = new System.Drawing.Point(12, 353);
            this.out_path.Name = "out_path";
            this.out_path.Size = new System.Drawing.Size(0, 16);
            this.out_path.TabIndex = 24;
            // 
            // convert_btn
            // 
            this.convert_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.convert_btn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.convert_btn.Controls.Add(this.label3);
            this.convert_btn.Location = new System.Drawing.Point(12, 84);
            this.convert_btn.Name = "convert_btn";
            this.convert_btn.Size = new System.Drawing.Size(186, 38);
            this.convert_btn.TabIndex = 20;
            this.convert_btn.Click += new System.EventHandler(this.CQ_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.label3.Location = new System.Drawing.Point(35, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Конвертировать";
            this.label3.Click += new System.EventHandler(this.CQ_Click);
            // 
            // btn_choice
            // 
            this.btn_choice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.btn_choice.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.btn_choice.Controls.Add(this.label2);
            this.btn_choice.Location = new System.Drawing.Point(12, 40);
            this.btn_choice.Name = "btn_choice";
            this.btn_choice.Size = new System.Drawing.Size(186, 38);
            this.btn_choice.TabIndex = 19;
            this.btn_choice.Click += new System.EventHandler(this.btn_choice_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.label2.Location = new System.Drawing.Point(60, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Выбрать";
            this.label2.Click += new System.EventHandler(this.btn_choice_Click);
            // 
            // roundedPanel3
            // 
            this.roundedPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.roundedPanel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.roundedPanel3.Controls.Add(this.listImage);
            this.roundedPanel3.Location = new System.Drawing.Point(12, 128);
            this.roundedPanel3.Name = "roundedPanel3";
            this.roundedPanel3.Size = new System.Drawing.Size(186, 191);
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
            this.listImage.Size = new System.Drawing.Size(180, 182);
            this.listImage.TabIndex = 7;
            this.listImage.SelectedIndexChanged += new System.EventHandler(this.listImage_SelectedIndexChanged);
            // 
            // btxpng_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.out_path);
            this.Controls.Add(this.preview_image);
            this.Controls.Add(this.convert_btn);
            this.Controls.Add(this.btn_choice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.check_zip);
            this.Controls.Add(this.roundedPanel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "btxpng_form";
            this.Text = "btxpng_form";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.btxpng_form_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.btxpng_form_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.preview_image)).EndInit();
            this.convert_btn.ResumeLayout(false);
            this.convert_btn.PerformLayout();
            this.btn_choice.ResumeLayout(false);
            this.btn_choice.PerformLayout();
            this.roundedPanel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundedPanel convert_btn;
        private System.Windows.Forms.Label label3;
        private RoundedPanel btn_choice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listImage;
        private System.Windows.Forms.CheckBox check_zip;
        private RoundedPanel roundedPanel3;
        private System.Windows.Forms.PictureBox preview_image;
        private System.Windows.Forms.Label out_path;
    }
}