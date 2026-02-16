namespace KoTeK_GUI
{
    partial class KoTeK
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KoTeK));
            this.panel3 = new System.Windows.Forms.Panel();
            this.atmos = new KoTeK_GUI.RoundedPanel();
            this.choice_true_vert_6 = new KoTeK_GUI.RoundedPanel();
            this.roundedPanel3 = new KoTeK_GUI.RoundedPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.copy = new KoTeK_GUI.RoundedPanel();
            this.choice_true_vert_2 = new KoTeK_GUI.RoundedPanel();
            this.roundedPanel11 = new KoTeK_GUI.RoundedPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.settings = new KoTeK_GUI.RoundedPanel();
            this.roundedPanel13 = new KoTeK_GUI.RoundedPanel();
            this.choice_true_vert_5 = new KoTeK_GUI.RoundedPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.convert = new KoTeK_GUI.RoundedPanel();
            this.choice_true_vert_1 = new KoTeK_GUI.RoundedPanel();
            this.roundedPanel10 = new KoTeK_GUI.RoundedPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.color = new KoTeK_GUI.RoundedPanel();
            this.choice_true_vert_4 = new KoTeK_GUI.RoundedPanel();
            this.roundedPanel14 = new KoTeK_GUI.RoundedPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.cut = new KoTeK_GUI.RoundedPanel();
            this.roundedPanel12 = new KoTeK_GUI.RoundedPanel();
            this.choice_true_vert_3 = new KoTeK_GUI.RoundedPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.grab_top = new System.Windows.Forms.Panel();
            this.wrap_app_btn = new KoTeK_GUI.RoundedPanel();
            this.close_app_btn = new KoTeK_GUI.RoundedPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.choice_true_5 = new KoTeK_GUI.RoundedPanel();
            this.profile = new KoTeK_GUI.RoundedPanel();
            this.logo_kotek = new KoTeK_GUI.RoundedPanel();
            this.roundedPanel9 = new KoTeK_GUI.RoundedPanel();
            this.choice_true_4 = new KoTeK_GUI.RoundedPanel();
            this.choice_text_4 = new System.Windows.Forms.Label();
            this.roundedPanel7 = new KoTeK_GUI.RoundedPanel();
            this.choice_true_3 = new KoTeK_GUI.RoundedPanel();
            this.choice_text_3 = new System.Windows.Forms.Label();
            this.roundedPanel5 = new KoTeK_GUI.RoundedPanel();
            this.choice_true_2 = new KoTeK_GUI.RoundedPanel();
            this.choice_text_2 = new System.Windows.Forms.Label();
            this.roundedPanel8 = new KoTeK_GUI.RoundedPanel();
            this.choice_true_1 = new KoTeK_GUI.RoundedPanel();
            this.choice_text_1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.main_view = new KoTeK_GUI.RoundedPanel();
            this.hello_text = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel3.SuspendLayout();
            this.atmos.SuspendLayout();
            this.copy.SuspendLayout();
            this.settings.SuspendLayout();
            this.convert.SuspendLayout();
            this.color.SuspendLayout();
            this.cut.SuspendLayout();
            this.grab_top.SuspendLayout();
            this.panel1.SuspendLayout();
            this.roundedPanel9.SuspendLayout();
            this.roundedPanel7.SuspendLayout();
            this.roundedPanel5.SuspendLayout();
            this.roundedPanel8.SuspendLayout();
            this.main_view.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.panel3.Controls.Add(this.atmos);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.copy);
            this.panel3.Controls.Add(this.settings);
            this.panel3.Controls.Add(this.convert);
            this.panel3.Controls.Add(this.color);
            this.panel3.Controls.Add(this.cut);
            this.panel3.Location = new System.Drawing.Point(0, 75);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(117, 388);
            this.panel3.TabIndex = 2;
            // 
            // atmos
            // 
            this.atmos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.atmos.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.atmos.Controls.Add(this.choice_true_vert_6);
            this.atmos.Controls.Add(this.roundedPanel3);
            this.atmos.Controls.Add(this.label8);
            this.atmos.Location = new System.Drawing.Point(2, 210);
            this.atmos.Name = "atmos";
            this.atmos.Size = new System.Drawing.Size(109, 44);
            this.atmos.TabIndex = 2;
            this.atmos.Click += new System.EventHandler(this.atmosphere_Click);
            // 
            // choice_true_vert_6
            // 
            this.choice_true_vert_6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.choice_true_vert_6.BackgroundImage = global::KoTeK_GUI.Properties.Resources.chioce_view_vert_bar;
            this.choice_true_vert_6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.choice_true_vert_6.Location = new System.Drawing.Point(101, 8);
            this.choice_true_vert_6.Name = "choice_true_vert_6";
            this.choice_true_vert_6.Size = new System.Drawing.Size(13, 31);
            this.choice_true_vert_6.TabIndex = 1;
            this.choice_true_vert_6.Visible = false;
            // 
            // roundedPanel3
            // 
            this.roundedPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.roundedPanel3.BackgroundImage = global::KoTeK_GUI.Properties.Resources.atmosphere_bar;
            this.roundedPanel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.roundedPanel3.Location = new System.Drawing.Point(2, 6);
            this.roundedPanel3.Name = "roundedPanel3";
            this.roundedPanel3.Size = new System.Drawing.Size(35, 35);
            this.roundedPanel3.TabIndex = 0;
            this.roundedPanel3.Click += new System.EventHandler(this.atmosphere_Click);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.label8.Location = new System.Drawing.Point(38, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 23);
            this.label8.TabIndex = 1;
            this.label8.Text = "atmos";
            this.label8.Click += new System.EventHandler(this.atmosphere_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.label7.Location = new System.Drawing.Point(60, 365);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "beta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.label1.Location = new System.Drawing.Point(5, 366);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "version:";
            // 
            // copy
            // 
            this.copy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.copy.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.copy.Controls.Add(this.choice_true_vert_2);
            this.copy.Controls.Add(this.roundedPanel11);
            this.copy.Controls.Add(this.label3);
            this.copy.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold);
            this.copy.Location = new System.Drawing.Point(2, 60);
            this.copy.Name = "copy";
            this.copy.Size = new System.Drawing.Size(109, 44);
            this.copy.TabIndex = 6;
            this.copy.Click += new System.EventHandler(this.copy_Click);
            // 
            // choice_true_vert_2
            // 
            this.choice_true_vert_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.choice_true_vert_2.BackgroundImage = global::KoTeK_GUI.Properties.Resources.chioce_view_vert_bar;
            this.choice_true_vert_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.choice_true_vert_2.Location = new System.Drawing.Point(101, 8);
            this.choice_true_vert_2.Name = "choice_true_vert_2";
            this.choice_true_vert_2.Size = new System.Drawing.Size(13, 31);
            this.choice_true_vert_2.TabIndex = 2;
            this.choice_true_vert_2.Visible = false;
            // 
            // roundedPanel11
            // 
            this.roundedPanel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.roundedPanel11.BackgroundImage = global::KoTeK_GUI.Properties.Resources.copy_bar;
            this.roundedPanel11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.roundedPanel11.Location = new System.Drawing.Point(2, 3);
            this.roundedPanel11.Name = "roundedPanel11";
            this.roundedPanel11.Size = new System.Drawing.Size(35, 35);
            this.roundedPanel11.TabIndex = 2;
            this.roundedPanel11.Click += new System.EventHandler(this.copy_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.label3.Location = new System.Drawing.Point(36, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "copy";
            this.label3.Click += new System.EventHandler(this.copy_Click);
            // 
            // settings
            // 
            this.settings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.settings.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.settings.Controls.Add(this.roundedPanel13);
            this.settings.Controls.Add(this.choice_true_vert_5);
            this.settings.Controls.Add(this.label5);
            this.settings.Location = new System.Drawing.Point(3, 315);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(109, 44);
            this.settings.TabIndex = 5;
            this.settings.Click += new System.EventHandler(this.settings_Click);
            // 
            // roundedPanel13
            // 
            this.roundedPanel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.roundedPanel13.BackgroundImage = global::KoTeK_GUI.Properties.Resources.setting_bar;
            this.roundedPanel13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.roundedPanel13.Location = new System.Drawing.Point(3, 6);
            this.roundedPanel13.Name = "roundedPanel13";
            this.roundedPanel13.Size = new System.Drawing.Size(35, 35);
            this.roundedPanel13.TabIndex = 8;
            this.roundedPanel13.Click += new System.EventHandler(this.settings_Click);
            // 
            // choice_true_vert_5
            // 
            this.choice_true_vert_5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.choice_true_vert_5.BackgroundImage = global::KoTeK_GUI.Properties.Resources.chioce_view_vert_bar;
            this.choice_true_vert_5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.choice_true_vert_5.Location = new System.Drawing.Point(101, 10);
            this.choice_true_vert_5.Name = "choice_true_vert_5";
            this.choice_true_vert_5.Size = new System.Drawing.Size(13, 31);
            this.choice_true_vert_5.TabIndex = 2;
            this.choice_true_vert_5.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.label5.Location = new System.Drawing.Point(37, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "settings";
            this.label5.Click += new System.EventHandler(this.settings_Click);
            // 
            // convert
            // 
            this.convert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.convert.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.convert.Controls.Add(this.choice_true_vert_1);
            this.convert.Controls.Add(this.roundedPanel10);
            this.convert.Controls.Add(this.label2);
            this.convert.Location = new System.Drawing.Point(2, 10);
            this.convert.Name = "convert";
            this.convert.Size = new System.Drawing.Size(109, 44);
            this.convert.TabIndex = 1;
            this.convert.Click += new System.EventHandler(this.convert_Click);
            // 
            // choice_true_vert_1
            // 
            this.choice_true_vert_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.choice_true_vert_1.BackgroundImage = global::KoTeK_GUI.Properties.Resources.chioce_view_vert_bar;
            this.choice_true_vert_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.choice_true_vert_1.Location = new System.Drawing.Point(101, 8);
            this.choice_true_vert_1.Name = "choice_true_vert_1";
            this.choice_true_vert_1.Size = new System.Drawing.Size(13, 31);
            this.choice_true_vert_1.TabIndex = 1;
            this.choice_true_vert_1.Visible = false;
            // 
            // roundedPanel10
            // 
            this.roundedPanel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.roundedPanel10.BackgroundImage = global::KoTeK_GUI.Properties.Resources.convert_bar;
            this.roundedPanel10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.roundedPanel10.Location = new System.Drawing.Point(2, 6);
            this.roundedPanel10.Name = "roundedPanel10";
            this.roundedPanel10.Size = new System.Drawing.Size(35, 35);
            this.roundedPanel10.TabIndex = 0;
            this.roundedPanel10.Click += new System.EventHandler(this.convert_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.label2.Location = new System.Drawing.Point(38, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "convert";
            this.label2.Click += new System.EventHandler(this.convert_Click);
            // 
            // color
            // 
            this.color.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.color.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.color.Controls.Add(this.choice_true_vert_4);
            this.color.Controls.Add(this.roundedPanel14);
            this.color.Controls.Add(this.label6);
            this.color.Location = new System.Drawing.Point(2, 160);
            this.color.Name = "color";
            this.color.Size = new System.Drawing.Size(109, 44);
            this.color.TabIndex = 2;
            this.color.Click += new System.EventHandler(this.color_Click);
            // 
            // choice_true_vert_4
            // 
            this.choice_true_vert_4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.choice_true_vert_4.BackgroundImage = global::KoTeK_GUI.Properties.Resources.chioce_view_vert_bar;
            this.choice_true_vert_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.choice_true_vert_4.Location = new System.Drawing.Point(101, 8);
            this.choice_true_vert_4.Name = "choice_true_vert_4";
            this.choice_true_vert_4.Size = new System.Drawing.Size(13, 31);
            this.choice_true_vert_4.TabIndex = 5;
            this.choice_true_vert_4.Visible = false;
            // 
            // roundedPanel14
            // 
            this.roundedPanel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.roundedPanel14.BackgroundImage = global::KoTeK_GUI.Properties.Resources.color_bar;
            this.roundedPanel14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.roundedPanel14.Location = new System.Drawing.Point(3, 6);
            this.roundedPanel14.Name = "roundedPanel14";
            this.roundedPanel14.Size = new System.Drawing.Size(35, 35);
            this.roundedPanel14.TabIndex = 6;
            this.roundedPanel14.Click += new System.EventHandler(this.color_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.label6.Location = new System.Drawing.Point(37, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "color";
            this.label6.Click += new System.EventHandler(this.color_Click);
            // 
            // cut
            // 
            this.cut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.cut.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.cut.Controls.Add(this.roundedPanel12);
            this.cut.Controls.Add(this.choice_true_vert_3);
            this.cut.Controls.Add(this.label4);
            this.cut.Location = new System.Drawing.Point(2, 110);
            this.cut.Name = "cut";
            this.cut.Size = new System.Drawing.Size(109, 44);
            this.cut.TabIndex = 3;
            this.cut.Click += new System.EventHandler(this.cut_Click);
            // 
            // roundedPanel12
            // 
            this.roundedPanel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.roundedPanel12.BackgroundImage = global::KoTeK_GUI.Properties.Resources.cut_bar;
            this.roundedPanel12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.roundedPanel12.Location = new System.Drawing.Point(3, 6);
            this.roundedPanel12.Name = "roundedPanel12";
            this.roundedPanel12.Size = new System.Drawing.Size(35, 35);
            this.roundedPanel12.TabIndex = 4;
            this.roundedPanel12.Click += new System.EventHandler(this.cut_Click);
            // 
            // choice_true_vert_3
            // 
            this.choice_true_vert_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.choice_true_vert_3.BackgroundImage = global::KoTeK_GUI.Properties.Resources.chioce_view_vert_bar;
            this.choice_true_vert_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.choice_true_vert_3.Location = new System.Drawing.Point(101, 8);
            this.choice_true_vert_3.Name = "choice_true_vert_3";
            this.choice_true_vert_3.Size = new System.Drawing.Size(13, 31);
            this.choice_true_vert_3.TabIndex = 4;
            this.choice_true_vert_3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.label4.Location = new System.Drawing.Point(37, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "cut";
            this.label4.Click += new System.EventHandler(this.cut_Click);
            // 
            // grab_top
            // 
            this.grab_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(37)))), ((int)(((byte)(45)))));
            this.grab_top.Controls.Add(this.wrap_app_btn);
            this.grab_top.Controls.Add(this.close_app_btn);
            this.grab_top.Location = new System.Drawing.Point(0, 0);
            this.grab_top.Name = "grab_top";
            this.grab_top.Size = new System.Drawing.Size(734, 25);
            this.grab_top.TabIndex = 3;
            this.grab_top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            // 
            // wrap_app_btn
            // 
            this.wrap_app_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(39)))), ((int)(((byte)(48)))));
            this.wrap_app_btn.BackgroundImage = global::KoTeK_GUI.Properties.Resources.wrap_app;
            this.wrap_app_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.wrap_app_btn.Location = new System.Drawing.Point(689, 3);
            this.wrap_app_btn.Name = "wrap_app_btn";
            this.wrap_app_btn.Size = new System.Drawing.Size(18, 19);
            this.wrap_app_btn.TabIndex = 1;
            this.wrap_app_btn.Click += new System.EventHandler(this.wrap_app_click);
            // 
            // close_app_btn
            // 
            this.close_app_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(39)))), ((int)(((byte)(48)))));
            this.close_app_btn.BackgroundImage = global::KoTeK_GUI.Properties.Resources.close_app;
            this.close_app_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.close_app_btn.Location = new System.Drawing.Point(713, 3);
            this.close_app_btn.Name = "close_app_btn";
            this.close_app_btn.Size = new System.Drawing.Size(18, 19);
            this.close_app_btn.TabIndex = 0;
            this.close_app_btn.Click += new System.EventHandler(this.close_app_click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.panel1.Controls.Add(this.choice_true_5);
            this.panel1.Controls.Add(this.profile);
            this.panel1.Controls.Add(this.logo_kotek);
            this.panel1.Controls.Add(this.roundedPanel9);
            this.panel1.Controls.Add(this.roundedPanel7);
            this.panel1.Controls.Add(this.roundedPanel5);
            this.panel1.Controls.Add(this.roundedPanel8);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(734, 57);
            this.panel1.TabIndex = 1;
            // 
            // choice_true_5
            // 
            this.choice_true_5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.choice_true_5.BackgroundImage = global::KoTeK_GUI.Properties.Resources.chioce_view_bar;
            this.choice_true_5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.choice_true_5.Location = new System.Drawing.Point(674, 39);
            this.choice_true_5.Name = "choice_true_5";
            this.choice_true_5.Size = new System.Drawing.Size(31, 19);
            this.choice_true_5.TabIndex = 9;
            this.choice_true_5.Visible = false;
            // 
            // profile
            // 
            this.profile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.profile.BackgroundImage = global::KoTeK_GUI.Properties.Resources.author_bar;
            this.profile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.profile.Location = new System.Drawing.Point(672, 8);
            this.profile.Name = "profile";
            this.profile.Size = new System.Drawing.Size(35, 35);
            this.profile.TabIndex = 9;
            this.profile.Click += new System.EventHandler(this.profile_Click);
            // 
            // logo_kotek
            // 
            this.logo_kotek.BackColor = System.Drawing.Color.White;
            this.logo_kotek.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("logo_kotek.BackgroundImage")));
            this.logo_kotek.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logo_kotek.Location = new System.Drawing.Point(-21, -20);
            this.logo_kotek.Name = "logo_kotek";
            this.logo_kotek.Size = new System.Drawing.Size(155, 90);
            this.logo_kotek.TabIndex = 0;
            this.logo_kotek.Click += new System.EventHandler(this.logo_kotek_Click);
            // 
            // roundedPanel9
            // 
            this.roundedPanel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.roundedPanel9.Controls.Add(this.choice_true_4);
            this.roundedPanel9.Controls.Add(this.choice_text_4);
            this.roundedPanel9.Location = new System.Drawing.Point(530, 3);
            this.roundedPanel9.Name = "roundedPanel9";
            this.roundedPanel9.Size = new System.Drawing.Size(105, 47);
            this.roundedPanel9.TabIndex = 5;
            this.roundedPanel9.Click += new System.EventHandler(this.choice_click_4);
            // 
            // choice_true_4
            // 
            this.choice_true_4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.choice_true_4.BackgroundImage = global::KoTeK_GUI.Properties.Resources.chioce_view_bar;
            this.choice_true_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.choice_true_4.Location = new System.Drawing.Point(38, 36);
            this.choice_true_4.Name = "choice_true_4";
            this.choice_true_4.Size = new System.Drawing.Size(31, 19);
            this.choice_true_4.TabIndex = 8;
            this.choice_true_4.Visible = false;
            this.choice_true_4.Click += new System.EventHandler(this.choice_click_4);
            // 
            // choice_text_4
            // 
            this.choice_text_4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.choice_text_4.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold);
            this.choice_text_4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.choice_text_4.Location = new System.Drawing.Point(3, 10);
            this.choice_text_4.Name = "choice_text_4";
            this.choice_text_4.Size = new System.Drawing.Size(99, 23);
            this.choice_text_4.TabIndex = 6;
            this.choice_text_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.choice_text_4.Click += new System.EventHandler(this.choice_click_4);
            // 
            // roundedPanel7
            // 
            this.roundedPanel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.roundedPanel7.Controls.Add(this.choice_true_3);
            this.roundedPanel7.Controls.Add(this.choice_text_3);
            this.roundedPanel7.Location = new System.Drawing.Point(400, 3);
            this.roundedPanel7.Name = "roundedPanel7";
            this.roundedPanel7.Size = new System.Drawing.Size(105, 47);
            this.roundedPanel7.TabIndex = 4;
            this.roundedPanel7.Click += new System.EventHandler(this.choice_click_3);
            // 
            // choice_true_3
            // 
            this.choice_true_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.choice_true_3.BackgroundImage = global::KoTeK_GUI.Properties.Resources.chioce_view_bar;
            this.choice_true_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.choice_true_3.Location = new System.Drawing.Point(38, 36);
            this.choice_true_3.Name = "choice_true_3";
            this.choice_true_3.Size = new System.Drawing.Size(31, 19);
            this.choice_true_3.TabIndex = 8;
            this.choice_true_3.Visible = false;
            this.choice_true_3.Click += new System.EventHandler(this.choice_click_3);
            // 
            // choice_text_3
            // 
            this.choice_text_3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.choice_text_3.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold);
            this.choice_text_3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.choice_text_3.Location = new System.Drawing.Point(7, 10);
            this.choice_text_3.Name = "choice_text_3";
            this.choice_text_3.Size = new System.Drawing.Size(95, 23);
            this.choice_text_3.TabIndex = 6;
            this.choice_text_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.choice_text_3.Click += new System.EventHandler(this.choice_click_3);
            // 
            // roundedPanel5
            // 
            this.roundedPanel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.roundedPanel5.Controls.Add(this.choice_true_2);
            this.roundedPanel5.Controls.Add(this.choice_text_2);
            this.roundedPanel5.Location = new System.Drawing.Point(270, 3);
            this.roundedPanel5.Name = "roundedPanel5";
            this.roundedPanel5.Size = new System.Drawing.Size(105, 47);
            this.roundedPanel5.TabIndex = 3;
            this.roundedPanel5.Click += new System.EventHandler(this.choice_click_2);
            // 
            // choice_true_2
            // 
            this.choice_true_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.choice_true_2.BackgroundImage = global::KoTeK_GUI.Properties.Resources.chioce_view_bar;
            this.choice_true_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.choice_true_2.Location = new System.Drawing.Point(38, 36);
            this.choice_true_2.Name = "choice_true_2";
            this.choice_true_2.Size = new System.Drawing.Size(31, 19);
            this.choice_true_2.TabIndex = 7;
            this.choice_true_2.Visible = false;
            this.choice_true_2.Click += new System.EventHandler(this.choice_click_2);
            // 
            // choice_text_2
            // 
            this.choice_text_2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.choice_text_2.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold);
            this.choice_text_2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.choice_text_2.Location = new System.Drawing.Point(3, 10);
            this.choice_text_2.Name = "choice_text_2";
            this.choice_text_2.Size = new System.Drawing.Size(99, 23);
            this.choice_text_2.TabIndex = 6;
            this.choice_text_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.choice_text_2.Click += new System.EventHandler(this.choice_click_2);
            // 
            // roundedPanel8
            // 
            this.roundedPanel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.roundedPanel8.Controls.Add(this.choice_true_1);
            this.roundedPanel8.Controls.Add(this.choice_text_1);
            this.roundedPanel8.Location = new System.Drawing.Point(140, 3);
            this.roundedPanel8.Name = "roundedPanel8";
            this.roundedPanel8.Size = new System.Drawing.Size(105, 47);
            this.roundedPanel8.TabIndex = 0;
            this.roundedPanel8.Click += new System.EventHandler(this.choice_click_1);
            // 
            // choice_true_1
            // 
            this.choice_true_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.choice_true_1.BackgroundImage = global::KoTeK_GUI.Properties.Resources.chioce_view_bar;
            this.choice_true_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.choice_true_1.Location = new System.Drawing.Point(38, 36);
            this.choice_true_1.Name = "choice_true_1";
            this.choice_true_1.Size = new System.Drawing.Size(31, 19);
            this.choice_true_1.TabIndex = 0;
            this.choice_true_1.Visible = false;
            this.choice_true_1.Click += new System.EventHandler(this.choice_click_1);
            // 
            // choice_text_1
            // 
            this.choice_text_1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.choice_text_1.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.choice_text_1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.choice_text_1.Location = new System.Drawing.Point(3, 10);
            this.choice_text_1.Name = "choice_text_1";
            this.choice_text_1.Size = new System.Drawing.Size(99, 23);
            this.choice_text_1.TabIndex = 6;
            this.choice_text_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.choice_text_1.Click += new System.EventHandler(this.choice_click_1);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 407);
            this.panel2.TabIndex = 2;
            // 
            // main_view
            // 
            this.main_view.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.main_view.BorderColor = System.Drawing.Color.Black;
            this.main_view.BorderWidth = 0;
            this.main_view.Controls.Add(this.hello_text);
            this.main_view.CornerRadius = 30;
            this.main_view.Location = new System.Drawing.Point(113, 75);
            this.main_view.Name = "main_view";
            this.main_view.Size = new System.Drawing.Size(630, 400);
            this.main_view.TabIndex = 6;
            // 
            // hello_text
            // 
            this.hello_text.AutoSize = true;
            this.hello_text.Font = new System.Drawing.Font("Segoe Script", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hello_text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(146)))), ((int)(((byte)(157)))));
            this.hello_text.Location = new System.Drawing.Point(176, 170);
            this.hello_text.Name = "hello_text";
            this.hello_text.Size = new System.Drawing.Size(295, 34);
            this.hello_text.TabIndex = 0;
            this.hello_text.Text = "Удачи в создании сборки";
            // 
            // KoTeK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.main_view);
            this.Controls.Add(this.grab_top);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KoTeK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KoTeK Tool";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.atmos.ResumeLayout(false);
            this.copy.ResumeLayout(false);
            this.copy.PerformLayout();
            this.settings.ResumeLayout(false);
            this.settings.PerformLayout();
            this.convert.ResumeLayout(false);
            this.color.ResumeLayout(false);
            this.color.PerformLayout();
            this.cut.ResumeLayout(false);
            this.cut.PerformLayout();
            this.grab_top.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.roundedPanel9.ResumeLayout(false);
            this.roundedPanel7.ResumeLayout(false);
            this.roundedPanel5.ResumeLayout(false);
            this.roundedPanel8.ResumeLayout(false);
            this.main_view.ResumeLayout(false);
            this.main_view.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel grab_top;
        private RoundedPanel close_app_btn;
        private RoundedPanel wrap_app_btn;
        private System.Windows.Forms.Label choice_text_1;
        private RoundedPanel choice_true_1;
        private RoundedPanel roundedPanel8;
        private RoundedPanel roundedPanel7;
        private System.Windows.Forms.Label choice_text_3;
        private RoundedPanel roundedPanel5;
        private System.Windows.Forms.Label choice_text_2;
        private RoundedPanel main_view;
        private RoundedPanel roundedPanel9;
        private System.Windows.Forms.Label choice_text_4;
        private RoundedPanel logo_kotek;
        private RoundedPanel choice_true_4;
        private RoundedPanel choice_true_3;
        private RoundedPanel choice_true_2;
        private RoundedPanel roundedPanel10;
        private System.Windows.Forms.Label hello_text;
        private System.Windows.Forms.Label label4;
        private RoundedPanel roundedPanel12;
        private System.Windows.Forms.Label label3;
        private RoundedPanel roundedPanel11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private RoundedPanel roundedPanel13;
        private System.Windows.Forms.Label label6;
        private RoundedPanel roundedPanel14;
        private RoundedPanel convert;
        private RoundedPanel color;
        private RoundedPanel copy;
        private RoundedPanel settings;
        private RoundedPanel cut;
        private RoundedPanel profile;
        private RoundedPanel choice_true_5;
        private RoundedPanel choice_true_vert_1;
        private RoundedPanel choice_true_vert_2;
        private RoundedPanel choice_true_vert_5;
        private RoundedPanel choice_true_vert_4;
        private RoundedPanel choice_true_vert_3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private RoundedPanel atmos;
        private RoundedPanel choice_true_vert_6;
        private RoundedPanel roundedPanel3;
        private System.Windows.Forms.Label label8;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

