namespace KoTeK_GUI.sliced_form
{
    partial class map_form
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
            this.preview_image = new System.Windows.Forms.PictureBox();
            this.out_path = new System.Windows.Forms.Label();
            this.ready_cut = new KoTeK_GUI.RoundedPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_choice_image2 = new KoTeK_GUI.RoundedPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_choice_image = new KoTeK_GUI.RoundedPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.check_zip = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.preview_image)).BeginInit();
            this.ready_cut.SuspendLayout();
            this.btn_choice_image2.SuspendLayout();
            this.btn_choice_image.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.label1.Location = new System.Drawing.Point(241, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Нарезка карты";
            // 
            // preview_image
            // 
            this.preview_image.Location = new System.Drawing.Point(258, 51);
            this.preview_image.Name = "preview_image";
            this.preview_image.Size = new System.Drawing.Size(320, 299);
            this.preview_image.TabIndex = 10;
            this.preview_image.TabStop = false;
            this.preview_image.Visible = false;
            // 
            // out_path
            // 
            this.out_path.AutoSize = true;
            this.out_path.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.out_path.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.out_path.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.out_path.Location = new System.Drawing.Point(30, 355);
            this.out_path.Name = "out_path";
            this.out_path.Size = new System.Drawing.Size(0, 16);
            this.out_path.TabIndex = 17;
            // 
            // ready_cut
            // 
            this.ready_cut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.ready_cut.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.ready_cut.Controls.Add(this.label4);
            this.ready_cut.Location = new System.Drawing.Point(33, 206);
            this.ready_cut.Name = "ready_cut";
            this.ready_cut.Size = new System.Drawing.Size(186, 38);
            this.ready_cut.TabIndex = 18;
            this.ready_cut.Visible = false;
            this.ready_cut.Click += new System.EventHandler(this.ready_cut_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.label4.Location = new System.Drawing.Point(58, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Нарезать";
            this.label4.Click += new System.EventHandler(this.ready_cut_Click);
            // 
            // btn_choice_image2
            // 
            this.btn_choice_image2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.btn_choice_image2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.btn_choice_image2.Controls.Add(this.label3);
            this.btn_choice_image2.Location = new System.Drawing.Point(33, 151);
            this.btn_choice_image2.Name = "btn_choice_image2";
            this.btn_choice_image2.Size = new System.Drawing.Size(186, 38);
            this.btn_choice_image2.TabIndex = 11;
            this.btn_choice_image2.Visible = false;
            this.btn_choice_image2.Click += new System.EventHandler(this.btn_choice_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.label3.Location = new System.Drawing.Point(60, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Выбрать";
            this.label3.Click += new System.EventHandler(this.btn_choice_Click);
            // 
            // btn_choice_image
            // 
            this.btn_choice_image.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.btn_choice_image.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.btn_choice_image.Controls.Add(this.label2);
            this.btn_choice_image.Location = new System.Drawing.Point(217, 58);
            this.btn_choice_image.Name = "btn_choice_image";
            this.btn_choice_image.Size = new System.Drawing.Size(186, 38);
            this.btn_choice_image.TabIndex = 9;
            this.btn_choice_image.Click += new System.EventHandler(this.btn_choice_Click);
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
            // check_zip
            // 
            this.check_zip.AutoSize = true;
            this.check_zip.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold);
            this.check_zip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.check_zip.Location = new System.Drawing.Point(33, 330);
            this.check_zip.Name = "check_zip";
            this.check_zip.Size = new System.Drawing.Size(146, 20);
            this.check_zip.TabIndex = 19;
            this.check_zip.Text = "Запаковать в zip";
            this.check_zip.UseVisualStyleBackColor = true;
            this.check_zip.Visible = false;
            // 
            // map_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(630, 400);
            this.Controls.Add(this.check_zip);
            this.Controls.Add(this.ready_cut);
            this.Controls.Add(this.out_path);
            this.Controls.Add(this.btn_choice_image2);
            this.Controls.Add(this.preview_image);
            this.Controls.Add(this.btn_choice_image);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "map_form";
            this.Text = "cut_form";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.cutmap_form_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.cutmap_form_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.preview_image)).EndInit();
            this.ready_cut.ResumeLayout(false);
            this.ready_cut.PerformLayout();
            this.btn_choice_image2.ResumeLayout(false);
            this.btn_choice_image2.PerformLayout();
            this.btn_choice_image.ResumeLayout(false);
            this.btn_choice_image.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private RoundedPanel btn_choice_image;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox preview_image;
        private RoundedPanel btn_choice_image2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label out_path;
        private RoundedPanel ready_cut;
        private System.Windows.Forms.Label label4;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.CheckBox check_zip;
    }
}