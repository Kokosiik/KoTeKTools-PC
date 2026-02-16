using KoTeK_GUI.atmosphere_form;
using KoTeK_GUI.color_form;
using KoTeK_GUI.convert_form;
using KoTeK_GUI.sliced_form;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KoTeK_GUI
{
    public partial class KoTeK : Form
    {
        private SnowOverlayForm snowOverlay;
        private settings_form settingsControl;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public KoTeK()
        {
            InitializeComponent();

            settings_form settingsForm = new settings_form(this);
            settingsForm.StartSettings();

            this.Shown += (s, e) => Check_Snow();
            this.Resize += KoTeK_Resize;
        }

        //  Управление эффектами и состоянием формы
        public void ShowSnowEffect()
        {
            if (snowOverlay == null || snowOverlay.IsDisposed)
            {
                snowOverlay = new SnowOverlayForm(this);
                snowOverlay.Show();
            }
        }

        public void HideSnowEffect()
        {
            snowOverlay?.Close();
            snowOverlay = null;
        }

        public void Check_Snow()
        {
            string snow = settings_form.GetSnowSetting();
            if (snow == "1")
                ShowSnowEffect();
            else
                HideSnowEffect();
        }

        public void MovableForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.MouseDown += new MouseEventHandler(Form_MouseDown);

            var panel = new Panel { Dock = DockStyle.Fill };
            panel.MouseDown += new MouseEventHandler(Form_MouseDown);
            this.Controls.Add(panel);
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        //  Обработчики кнопок верхней панели (закрытие / сворачивание)
        private void close_app_click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void wrap_app_click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //  Обработчики основных режимов приложения
        private void convert_Click(object sender, EventArgs e)
        {
            System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml("#7a929d");

            this.choice_text_1.Text = "png<>btx";
            this.choice_text_2.Text = "common";
            this.choice_text_3.Text = "dff<>mod";
            this.choice_text_4.Text = "gnrl";

            this.roundedPanel8.BorderColor = color;
            this.roundedPanel5.BorderColor = color;
            this.roundedPanel7.BorderColor = color;
            this.roundedPanel9.BorderColor = color;

            this.choice_true_1.Visible = false;
            this.choice_true_2.Visible = false;
            this.choice_true_3.Visible = false;
            this.choice_true_4.Visible = false;
            this.choice_true_5.Visible = false;

            this.choice_true_vert_1.Visible = true;
            this.choice_true_vert_2.Visible = false;
            this.choice_true_vert_3.Visible = false;
            this.choice_true_vert_4.Visible = false;
            this.choice_true_vert_5.Visible = false;
            this.choice_true_vert_6.Visible = false;
        }

        private void copy_Click(object sender, EventArgs e)
        {
            System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml("#7a929d");
            System.Drawing.Color colorTr = System.Drawing.Color.FromArgb(0, color);

            this.choice_text_1.Text = "logo";
            this.choice_text_2.Text = "billd";
            this.choice_text_3.Text = "foliage";
            this.choice_text_4.Text = "";

            this.roundedPanel8.BorderColor = color;
            this.roundedPanel5.BorderColor = color;
            this.roundedPanel7.BorderColor = color;
            this.roundedPanel9.BorderColor = colorTr;

            this.choice_true_1.Visible = false;
            this.choice_true_2.Visible = false;
            this.choice_true_3.Visible = false;
            this.choice_true_4.Visible = false;
            this.choice_true_5.Visible = false;

            this.choice_true_vert_1.Visible = false;
            this.choice_true_vert_2.Visible = true;
            this.choice_true_vert_3.Visible = false;
            this.choice_true_vert_4.Visible = false;
            this.choice_true_vert_5.Visible = false;
            this.choice_true_vert_6.Visible = false;
        }

        private void cut_Click(object sender, EventArgs e)
        {
            System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml("#7a929d");
            System.Drawing.Color colorTr = System.Drawing.Color.FromArgb(0, color);

            this.choice_text_1.Text = "map";
            this.choice_text_2.Text = "";
            this.choice_text_3.Text = "";
            this.choice_text_4.Text = "";

            this.roundedPanel8.BorderColor = color;
            this.roundedPanel5.BorderColor = colorTr;
            this.roundedPanel7.BorderColor = colorTr;
            this.roundedPanel9.BorderColor = colorTr;

            this.choice_true_1.Visible = false;
            this.choice_true_2.Visible = false;
            this.choice_true_3.Visible = false;
            this.choice_true_4.Visible = false;
            this.choice_true_5.Visible = false;

            this.choice_true_vert_1.Visible = false;
            this.choice_true_vert_2.Visible = false;
            this.choice_true_vert_3.Visible = true;
            this.choice_true_vert_4.Visible = false;
            this.choice_true_vert_5.Visible = false;
            this.choice_true_vert_6.Visible = false;
        }

        private void color_Click(object sender, EventArgs e)
        {
            System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml("#7a929d");
            System.Drawing.Color colorTr = System.Drawing.Color.FromArgb(0, color);

            this.choice_text_1.Text = "image";
            this.choice_text_2.Text = "button";
            this.choice_text_3.Text = "";
            this.choice_text_4.Text = "";

            this.roundedPanel8.BorderColor = color;
            this.roundedPanel5.BorderColor = color;
            this.roundedPanel7.BorderColor = colorTr;
            this.roundedPanel9.BorderColor = colorTr;

            this.choice_true_1.Visible = false;
            this.choice_true_2.Visible = false;
            this.choice_true_3.Visible = false;
            this.choice_true_4.Visible = false;
            this.choice_true_5.Visible = false;

            this.choice_true_vert_1.Visible = false;
            this.choice_true_vert_2.Visible = false;
            this.choice_true_vert_3.Visible = false;
            this.choice_true_vert_4.Visible = true;
            this.choice_true_vert_5.Visible = false;
            this.choice_true_vert_6.Visible = false;
        }

        private void atmosphere_Click(object sender, EventArgs e)
        {
            System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml("#7a929d");
            System.Drawing.Color colorTr = System.Drawing.Color.FromArgb(0, color);

            this.choice_text_1.Text = "colorcycle";
            this.choice_text_2.Text = "timecyc";
            this.choice_text_3.Text = "";
            this.choice_text_4.Text = "";

            this.roundedPanel8.BorderColor = color;
            this.roundedPanel5.BorderColor = color;
            this.roundedPanel7.BorderColor = colorTr;
            this.roundedPanel9.BorderColor = colorTr;

            this.choice_true_1.Visible = false;
            this.choice_true_2.Visible = false;
            this.choice_true_3.Visible = false;
            this.choice_true_4.Visible = false;
            this.choice_true_5.Visible = false;

            this.choice_true_vert_1.Visible = false;
            this.choice_true_vert_2.Visible = false;
            this.choice_true_vert_3.Visible = false;
            this.choice_true_vert_4.Visible = false;
            this.choice_true_vert_5.Visible = false;
            this.choice_true_vert_6.Visible = true;
        }

        private void settings_Click(object sender, EventArgs e)
        {
            System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml("#7a929d");
            System.Drawing.Color colorTr = System.Drawing.Color.FromArgb(0, color);

            this.choice_text_1.Text = "";
            this.choice_text_2.Text = "";
            this.choice_text_3.Text = "";
            this.choice_text_4.Text = "";

            this.roundedPanel8.BorderColor = colorTr;
            this.roundedPanel5.BorderColor = colorTr;
            this.roundedPanel7.BorderColor = colorTr;
            this.roundedPanel9.BorderColor = colorTr;

            this.choice_true_1.Visible = false;
            this.choice_true_2.Visible = false;
            this.choice_true_3.Visible = false;
            this.choice_true_4.Visible = false;
            this.choice_true_5.Visible = false;

            this.choice_true_vert_1.Visible = false;
            this.choice_true_vert_2.Visible = false;
            this.choice_true_vert_3.Visible = false;
            this.choice_true_vert_4.Visible = false;
            this.choice_true_vert_5.Visible = true;
            this.choice_true_vert_6.Visible = false;

            main_view.Controls.Clear();

            settings_form settingsForm = new settings_form(this);

            settingsForm.TopLevel = false;
            settingsForm.FormBorderStyle = FormBorderStyle.None;
            settingsForm.Dock = DockStyle.Fill;
            settingsForm.Visible = true;

            main_view.Controls.Add(settingsForm);
            settingsForm.Show();
        }

        private void profile_Click(object sender, EventArgs e)
        {
            System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml("#7a929d");
            System.Drawing.Color colorTr = System.Drawing.Color.FromArgb(0, color);

            this.choice_text_1.Text = "";
            this.choice_text_2.Text = "";
            this.choice_text_3.Text = "";
            this.choice_text_4.Text = "";

            this.roundedPanel8.BorderColor = colorTr;
            this.roundedPanel5.BorderColor = colorTr;
            this.roundedPanel7.BorderColor = colorTr;
            this.roundedPanel9.BorderColor = colorTr;

            this.choice_true_1.Visible = false;
            this.choice_true_2.Visible = false;
            this.choice_true_3.Visible = false;
            this.choice_true_4.Visible = false;
            this.choice_true_5.Visible = true;

            this.choice_true_vert_1.Visible = false;
            this.choice_true_vert_2.Visible = false;
            this.choice_true_vert_3.Visible = false;
            this.choice_true_vert_4.Visible = false;
            this.choice_true_vert_5.Visible = false;
            this.choice_true_vert_6.Visible = false;

            LoadFormInMainView(() => new profile_form());
        }

        //  Обработчики выбора подрежимов
        private void choice_click_1(object sender, EventArgs e)
        {
            if (choice_text_1.Text != "")
            {
                this.choice_true_1.Visible = true;
                this.choice_true_2.Visible = false;
                this.choice_true_3.Visible = false;
                this.choice_true_4.Visible = false;
                this.choice_true_5.Visible = false;
            }

            switch (choice_text_1.Text)
            {
                case "logo":
                    LoadFormInMainView(() => new logo_form());
                    break;

                case "image":
                    LoadFormInMainView(() => new colorImage_form());
                    break;

                case "colorcycle":
                    LoadFormInMainView(() => new colorcycle_form());
                    break;

                case "map":
                    LoadFormInMainView(() => new map_form());
                    break;

                case "png<>btx":
                    LoadFormInMainView(() => new btxpng_form());
                    break;
            }
        }

        private void choice_click_2(object sender, EventArgs e)
        {
            if (choice_text_1.Text != "")
            {
                this.choice_true_1.Visible = false;
                this.choice_true_2.Visible = true;
                this.choice_true_3.Visible = false;
                this.choice_true_4.Visible = false;
                this.choice_true_5.Visible = false;
            }

            switch (choice_text_2.Text)
            {
                case "billd":
                    LoadFormInMainView(() => new billd_form());
                    break;

                case "timecyc":
                    LoadFormInMainView(() => new timecyc_form());
                    break;

                case "button":
                    LoadFormInMainView(() => new colorbtn_form());
                    break;

                case "common":
                    LoadFormInMainView(() => new ComingSoom());
                    break;
            }
        }

        private void choice_click_3(object sender, EventArgs e)
        {
            if (choice_text_1.Text != "")
            {
                this.choice_true_1.Visible = false;
                this.choice_true_2.Visible = false;
                this.choice_true_3.Visible = true;
                this.choice_true_4.Visible = false;
                this.choice_true_5.Visible = false;
            }

            switch (choice_text_3.Text)
            {
                case "foliage":
                    LoadFormInMainView(() => new folliage_form());
                    break;

                case "dff<>mod":
                    LoadFormInMainView(() => new ComingSoom());
                    break;
            }
        }

        private void choice_click_4(object sender, EventArgs e)
        {
            if (choice_text_1.Text != "")
            {
                this.choice_true_1.Visible = false;
                this.choice_true_2.Visible = false;
                this.choice_true_3.Visible = false;
                this.choice_true_4.Visible = true;
                this.choice_true_5.Visible = false;
            }

            switch (choice_text_3.Text)
            {
                case "gnrl":
                    LoadFormInMainView(() => new ComingSoom());
                    break;
            }
        }

        private void LoadFormInMainView(Func<Form> formFactory)
        {
            main_view.Controls.Clear();

            Form form = formFactory();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Visible = true;

            main_view.Controls.Add(form);
            form.Show();
        }

        //  Обработчик клика по логотипу (возврат на главный экран)
        private void logo_kotek_Click(object sender, EventArgs e)
        {
            main_view.Controls.Clear();
            main_view.Controls.Add(hello_text);

            System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml("#7a929d");
            System.Drawing.Color colorTr = System.Drawing.Color.FromArgb(0, color);

            this.choice_text_1.Text = "";
            this.choice_text_2.Text = "";
            this.choice_text_3.Text = "";
            this.choice_text_4.Text = "";

            this.roundedPanel8.BorderColor = colorTr;
            this.roundedPanel5.BorderColor = colorTr;
            this.roundedPanel7.BorderColor = colorTr;
            this.roundedPanel9.BorderColor = colorTr;

            this.choice_true_1.Visible = false;
            this.choice_true_2.Visible = false;
            this.choice_true_3.Visible = false;
            this.choice_true_4.Visible = false;
            this.choice_true_5.Visible = false;

            this.choice_true_vert_1.Visible = false;
            this.choice_true_vert_2.Visible = false;
            this.choice_true_vert_3.Visible = false;
            this.choice_true_vert_4.Visible = false;
            this.choice_true_vert_5.Visible = false;
            this.choice_true_vert_6.Visible = false;
        }

        // Изменения размера окна
        private void KoTeK_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                HideSnowEffect();
            }
            else if (this.WindowState == FormWindowState.Normal || this.WindowState == FormWindowState.Maximized)
            {
                if (settings_form.GetSnowSetting() == "1")
                {
                    ShowSnowEffect();
                }
            }
        }
    }
}