using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace KoTeK_GUI
{
    [DefaultProperty("CornerRadius")]
    [ToolboxItem(true)]
    public partial class RoundedPanel : Panel
    {
        private int cornerRadius = 10;
        private Color borderColor = Color.Transparent;
        private int borderWidth = 1;

        [Category("Rounded Panel")]
        [Description("Радиус скругления углов панели")]
        [DefaultValue(10)]
        [DisplayName("Rounded Panel")]
        public int CornerRadius
        {
            get => cornerRadius;
            set
            {
                if (cornerRadius != value)
                {
                    cornerRadius = Math.Max(0, value);
                    UpdateRegion();
                    Invalidate();
                }
            }
        }

        [Category("Rounded Panel")]
        [Description("Цвет границы панели")]
        [DefaultValue(typeof(Color), "Transparent")]
        [DisplayName("Border Color")]
        public Color BorderColor
        {
            get => borderColor;
            set
            {
                if (borderColor != value)
                {
                    borderColor = value;
                    Invalidate();
                }
            }
        }

        [Category("Rounded Panel")]
        [Description("Толщина границы панели")]
        [DefaultValue(1)]
        [DisplayName("Border Width")]
        public int BorderWidth
        {
            get => borderWidth;
            set
            {
                if (borderWidth != value)
                {
                    borderWidth = Math.Max(0, value);
                    Invalidate();
                }
            }
        }

        public RoundedPanel()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.BackColor = Color.White;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateRegion();
        }

        private void UpdateRegion()
        {
            if (cornerRadius <= 0 || Width == 0 || Height == 0)
            {
                Region = null;
                return;
            }

            var path = new GraphicsPath();
            int r = Math.Min(cornerRadius, Math.Min(Width, Height) / 2);

            int offset = borderWidth > 0 ? borderWidth / 2 : 0;

            path.AddArc(offset, offset, r, r, 180, 90);
            path.AddArc(Width - r - offset, offset, r, r, 270, 90);
            path.AddArc(Width - r - offset, Height - r - offset, r, r, 0, 90);
            path.AddArc(offset, Height - r - offset, r, r, 90, 90);
            path.CloseFigure();

            Region = new Region(path);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (borderWidth > 0 && borderColor != Color.Transparent)
            {
                using (var pen = new Pen(borderColor, borderWidth))
                {
                    int r = Math.Min(cornerRadius, Math.Min(Width, Height) / 2);
                    int offset = borderWidth / 2;

                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    var rect = new Rectangle(offset, offset,
                        Width - borderWidth, Height - borderWidth);

                    using (var path = GetRoundedRectPath(rect, r))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            }
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();

            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            int r = Math.Min(radius, Math.Min(rect.Width, rect.Height) / 2);

            path.AddArc(rect.X, rect.Y, r, r, 180, 90);
            path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
            path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
            path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}