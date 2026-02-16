namespace KoTeK_GUI
{
    partial class billd_form
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
            this.out_path = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_choice = new KoTeK_GUI.RoundedPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_choice.SuspendLayout();
            this.SuspendLayout();
            // 
            // out_path
            // 
            this.out_path.AutoSize = true;
            this.out_path.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.out_path.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.out_path.Location = new System.Drawing.Point(13, 131);
            this.out_path.Name = "out_path";
            this.out_path.Size = new System.Drawing.Size(0, 20);
            this.out_path.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.label1.Location = new System.Drawing.Point(118, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Выберите .btx для копирования биллдбордов";
            // 
            // btn_choice
            // 
            this.btn_choice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.btn_choice.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.btn_choice.Controls.Add(this.label2);
            this.btn_choice.Location = new System.Drawing.Point(122, 62);
            this.btn_choice.Name = "btn_choice";
            this.btn_choice.Size = new System.Drawing.Size(337, 44);
            this.btn_choice.TabIndex = 6;
            this.btn_choice.Click += new System.EventHandler(this.btn_choice_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.label2.Location = new System.Drawing.Point(130, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Выбрать";
            this.label2.Click += new System.EventHandler(this.btn_choice_Click);
            // 
            // billd_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.btn_choice);
            this.Controls.Add(this.out_path);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "billd_form";
            this.Text = "billd_form";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.billd_form_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.billd_form_DragEnter);
            this.btn_choice.ResumeLayout(false);
            this.btn_choice.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundedPanel btn_choice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label out_path;
        private System.Windows.Forms.Label label1;
    }
}