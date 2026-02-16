namespace KoTeK_GUI
{
    partial class ComingSoom
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
            this.hello_text = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // hello_text
            // 
            this.hello_text.AutoSize = true;
            this.hello_text.Font = new System.Drawing.Font("Segoe Script", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hello_text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.hello_text.Location = new System.Drawing.Point(178, 122);
            this.hello_text.Name = "hello_text";
            this.hello_text.Size = new System.Drawing.Size(202, 34);
            this.hello_text.TabIndex = 1;
            this.hello_text.Text = "Comming Soon...";
            // 
            // ComingSoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(568, 322);
            this.Controls.Add(this.hello_text);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ComingSoom";
            this.Text = "ComingSoom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label hello_text;
    }
}