using System;
using System.Drawing;
using System.Windows.Forms;

namespace KoTeK_GUI
{
    public partial class CustomColorPicker : UserControl
    {
        private Color _selectedHueColor = Color.Red;
        private Point _selectedPoint = new Point(255, 0);
        private Bitmap _cachedSquare;
        private Bitmap _cachedHueStrip;
        private bool _cacheInvalid = true;

        public event EventHandler ColorChanged;

        public CustomColorPicker()
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            this.Size = new Size(260, 240);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            _cacheInvalid = true;
            Invalidate();
        }

        private void InvalidateCache()
        {
            _cacheInvalid = true;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_cacheInvalid)
            {
                RebuildCache();
                _cacheInvalid = false;
            }

            int size = Math.Min(this.Width - 30, this.Height);
            if (_cachedSquare != null)
                e.Graphics.DrawImage(_cachedSquare, 0, 0);
            if (_cachedHueStrip != null)
                e.Graphics.DrawImage(_cachedHueStrip, size + 5, 0);

            DrawSelector(e.Graphics);
        }

        private void RebuildCache()
        {
            int size = Math.Min(this.Width - 30, this.Height);
            if (size <= 0) return;
            _cachedSquare?.Dispose();
            _cachedSquare = new Bitmap(size, size, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            var rect = new Rectangle(0, 0, size, size);
            var data = _cachedSquare.LockBits(rect, System.Drawing.Imaging.ImageLockMode.WriteOnly, _cachedSquare.PixelFormat);
            var bytes = new byte[data.Stride * data.Height];

            for (int y = 0; y < size; y++)
            {
                float v = 1.0f - (float)y / (size - 1);
                for (int x = 0; x < size; x++)
                {
                    float s = (float)x / (size - 1);
                    Color c = FromHsv(GetHue(), s, v);

                    int index = y * data.Stride + x * 4;
                    bytes[index] = c.B; // Blue
                    bytes[index + 1] = c.G; // Green
                    bytes[index + 2] = c.R; // Red
                    bytes[index + 3] = c.A; // Alpha
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(bytes, 0, data.Scan0, bytes.Length);
            _cachedSquare.UnlockBits(data);

            _cachedHueStrip?.Dispose();
            _cachedHueStrip = new Bitmap(20, size, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            var hueRect = new Rectangle(0, 0, 20, size);
            var hueData = _cachedHueStrip.LockBits(hueRect, System.Drawing.Imaging.ImageLockMode.WriteOnly, _cachedHueStrip.PixelFormat);
            var hueBytes = new byte[hueData.Stride * hueData.Height];

            for (int y = 0; y < size; y++)
            {
                float h = 360f * (1.0f - (float)y / (size - 1));
                Color c = FromHsv(h, 1, 1);
                for (int x = 0; x < 20; x++)
                {
                    int index = y * hueData.Stride + x * 4;
                    hueBytes[index] = c.B;
                    hueBytes[index + 1] = c.G;
                    hueBytes[index + 2] = c.R;
                    hueBytes[index + 3] = c.A;
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(hueBytes, 0, hueData.Scan0, hueBytes.Length);
            _cachedHueStrip.UnlockBits(hueData);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            HandleClick(e.Location);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                HandleClick(e.Location);
        }

        private void HandleClick(Point pt)
        {
            int size = Math.Min(this.Width - 30, this.Height);

            if (pt.X >= 0 && pt.X < size && pt.Y >= 0 && pt.Y < size)
            {
                _selectedPoint = new Point(
                    (int)(pt.X * 255f / (size - 1)),
                    (int)(pt.Y * 255f / (size - 1))
                );
                Invalidate();
                ColorChanged?.Invoke(this, EventArgs.Empty);
            }
            else if (pt.X >= size + 5 && pt.X <= size + 25 && pt.Y >= 0 && pt.Y < size)
            {
                float hue = 360f * (1.0f - (float)pt.Y / (size - 1));
                _selectedHueColor = FromHsv(hue, 1, 1);
                InvalidateCache();
                ColorChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private void DrawSelector(Graphics g)
        {
            int size = Math.Min(this.Width - 30, this.Height);
            int x = (int)(_selectedPoint.X * (size - 1) / 255f);
            int y = (int)(_selectedPoint.Y * (size - 1) / 255f);
            g.DrawRectangle(Pens.White, x - 3, y - 3, 6, 6);
            g.DrawRectangle(Pens.Black, x - 4, y - 4, 8, 8);
        }

        public Color SelectedColor
        {
            get
            {
                float h = GetHue();
                float s = _selectedPoint.X / 255f;
                float v = 1.0f - (_selectedPoint.Y / 255f);
                return FromHsv(h, s, v);
            }
        }

        private float GetHue() => ColorToHue(_selectedHueColor);

        private float ColorToHue(Color c)
        {
            float r = c.R / 255f, g = c.G / 255f, b = c.B / 255f;
            float max = Math.Max(r, Math.Max(g, b));
            float min = Math.Min(r, Math.Min(g, b));
            if (max == min) return 0;
            float delta = max - min;
            float h = 0;
            if (max == r) h = (g - b) / delta % 6;
            else if (max == g) h = (b - r) / delta + 2;
            else if (max == b) h = (r - g) / delta + 4;
            return h * 60;
        }

        public static Color FromHsv(float h, float s, float v)
        {
            h = (h % 360 + 360) % 360;
            s = Math.Max(0, Math.Min(1, s));
            v = Math.Max(0, Math.Min(1, v));
            if (s == 0) return Color.FromArgb((int)(v * 255), (int)(v * 255), (int)(v * 255));
            float f = h / 60;
            int i = (int)Math.Floor(f);
            float p = v * (1 - s);
            float q = v * (1 - s * (f - i));
            float t = v * (1 - s * (1 - (f - i)));
            int r, g, b;
            switch (i % 6)
            {
                case 0: r = (int)(v * 255); g = (int)(t * 255); b = (int)(p * 255); break;
                case 1: r = (int)(q * 255); g = (int)(v * 255); b = (int)(p * 255); break;
                case 2: r = (int)(p * 255); g = (int)(v * 255); b = (int)(t * 255); break;
                case 3: r = (int)(p * 255); g = (int)(q * 255); b = (int)(v * 255); break;
                case 4: r = (int)(t * 255); g = (int)(p * 255); b = (int)(v * 255); break;
                default: r = (int)(v * 255); g = (int)(p * 255); b = (int)(q * 255); break;
            }
            return Color.FromArgb(r, g, b);
        }
    }
}