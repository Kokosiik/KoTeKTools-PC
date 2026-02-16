using System;
using System.Drawing;
using System.Windows.Forms;

namespace KoTeK_GUI
{
    public partial class ColorPickerPopup : Form
    {
        private CustomColorPicker colorPicker;
        public event Action<Color> ColorSelected;

        public ColorPickerPopup()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.StartPosition = FormStartPosition.Manual;
            this.Size = new Size(290, 250);
            this.BackColor = ColorTranslator.FromHtml("#0c2129");

            colorPicker = new CustomColorPicker();
            colorPicker.Dock = DockStyle.Fill;
            colorPicker.ColorChanged += (s, e) =>
            {
                ColorSelected?.Invoke(colorPicker.SelectedColor);
            };

            this.Controls.Add(colorPicker);

            this.Deactivate += (s, e) => this.Close();
        }

        public void ShowAt(Control control)
        {
            var pos = control.PointToScreen(new Point(0, control.Height));
            this.Location = pos;
            this.Show(control.FindForm());
        }
    }
}