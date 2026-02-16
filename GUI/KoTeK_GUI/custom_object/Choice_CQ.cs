using System;
using System.Drawing;
using System.Windows.Forms;

namespace KoTeK_GUI
{
    public partial class CompressionQualityPopup : Form
    {
        public event Action<string, string> ChoiceConfirmed;

        private RadioButton rbStrong, rbMediumComp, rbPoorComp;
        private RadioButton rbPoorQual, rbMediumQual, rbGoodQual, rbMaxQual;

        private ToolTip tooltip;

        public CompressionQualityPopup()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.StartPosition = FormStartPosition.Manual;
            this.Size = new Size(360, 240);
            this.BackColor = ColorTranslator.FromHtml("#0c2129");
            this.ForeColor = Color.White;
            this.Font = new Font("Segoe UI", 9);

            tooltip = new ToolTip
            {
                AutoPopDelay = 10000,
                InitialDelay = 500,
                ReshowDelay = 200,
                ShowAlways = true
            };

            var lblTitle = new Label
            {
                Text = "Выберите настройку",
                Location = new Point(0, 10),
                Size = new Size(360, 24),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = ColorTranslator.FromHtml("#7a929d"),
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };

            var panelCompression = new Panel
            {
                Location = new Point(20, 50),
                Size = new Size(150, 110),
                BackColor = Color.Transparent
            };

            var lblCompression = new Label { Text = "Выберите сжатие", Location = new Point(10, 0), AutoSize = true, ForeColor = ColorTranslator.FromHtml("#7a929d") };
            panelCompression.Controls.Add(lblCompression);

            rbStrong = CreateRadioButton("Сильное", 10, 25);
            var infoStrong = CreateInfoIcon(10 + rbStrong.Width + 5, 25);
            tooltip.SetToolTip(infoStrong, "Маленький вес и потеря качества");
            panelCompression.Controls.AddRange(new Control[] { rbStrong, infoStrong });

            rbMediumComp = CreateRadioButton("Среднее", 10, 50);
            var infoMedium = CreateInfoIcon(10 + rbMediumComp.Width + 5, 50);
            tooltip.SetToolTip(infoMedium, "Баланс веса и качества");
            panelCompression.Controls.AddRange(new Control[] { rbMediumComp, infoMedium });

            rbPoorComp = CreateRadioButton("Плохое", 10, 75);
            var infoPoor = CreateInfoIcon(10 + rbPoorComp.Width + 5, 75);
            tooltip.SetToolTip(infoPoor, "Большой вес и хорошее качество");
            panelCompression.Controls.AddRange(new Control[] { rbPoorComp, infoPoor });

            var panelQuality = new Panel
            {
                Location = new Point(180, 50),
                Size = new Size(170, 140),
                BackColor = Color.Transparent
            };

            var lblQuality = new Label { Text = "Выберите качество", Location = new Point(10, 0), AutoSize = true, ForeColor = ColorTranslator.FromHtml("#7a929d") };
            panelQuality.Controls.Add(lblQuality);

            rbPoorQual = CreateRadioButton("Плохое", 10, 25);
            var infoQPoor = CreateInfoIcon(10 + rbPoorQual.Width + 5, 25);
            tooltip.SetToolTip(infoQPoor, "4 формулы и быстрая конвертация");
            panelQuality.Controls.AddRange(new Control[] { rbPoorQual, infoQPoor });

            rbMediumQual = CreateRadioButton("Среднее", 10, 50);
            var infoQMed = CreateInfoIcon(10 + rbMediumQual.Width + 5, 50);
            tooltip.SetToolTip(infoQMed, "25 формул и средняя скорость конвертации");
            panelQuality.Controls.AddRange(new Control[] { rbMediumQual, infoQMed });

            rbGoodQual = CreateRadioButton("Хорошее", 10, 75);
            var infoQGood = CreateInfoIcon(10 + rbGoodQual.Width + 5, 75);
            tooltip.SetToolTip(infoQGood, "100 формул и долгая конвертация");
            panelQuality.Controls.AddRange(new Control[] { rbGoodQual, infoQGood });

            rbMaxQual = CreateRadioButton("Максимальное", 10, 100);
            var infoQMax = CreateInfoIcon(10 + rbMaxQual.Width + 5, 100);
            tooltip.SetToolTip(infoQMax, "1024 формулы и очень долгая конвертация");
            panelQuality.Controls.AddRange(new Control[] { rbMaxQual, infoQMax });

            var btnDone = new Button
            {
                Text = "Готово",
                Location = new Point(120, 190),
                Size = new Size(120, 30),
                BackColor = ColorTranslator.FromHtml("#123747"),
                ForeColor = ColorTranslator.FromHtml("#7a929d"),
                FlatStyle = FlatStyle.Flat
            };
            btnDone.FlatAppearance.BorderSize = 0;
            btnDone.Click += (s, e) =>
            {
                string comp = rbStrong.Checked ? "Сильное" :
                              rbMediumComp.Checked ? "Среднее" : "Плохое";

                string qual = rbPoorQual.Checked ? "Плохое" :
                              rbMediumQual.Checked ? "Среднее" :
                              rbGoodQual.Checked ? "Хорошее" : "Максимальное";

                ChoiceConfirmed?.Invoke(comp, qual);
                this.Close();
            };

            rbStrong.Checked = true;
            rbMaxQual.Checked = true;

            this.Controls.AddRange(new Control[]
            {
                lblTitle,
                panelCompression,
                panelQuality,
                btnDone
            });

            this.Deactivate += (s, e) => this.Close();
        }

        private RadioButton CreateRadioButton(string text, int x, int y)
        {
            return new RadioButton
            {
                Text = text,
                Location = new Point(x, y),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                AutoSize = true
            };
        }

        private Label CreateInfoIcon(int x, int y)
        {
            return new Label
            {
                Text = "ⓘ",
                Location = new Point(x, y),
                ForeColor = Color.LightBlue,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                Cursor = Cursors.Hand,
                AutoSize = true
            };
        }

        public void ShowAt(Control ownerControl)
        {
            if (ownerControl == null) throw new ArgumentNullException(nameof(ownerControl));
            var pos = ownerControl.PointToScreen(new Point(0, ownerControl.Height));
            this.Location = pos;
            this.Show(ownerControl.FindForm());
            this.BringToFront();
        }
    }
}