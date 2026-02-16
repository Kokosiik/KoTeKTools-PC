using System;
using System.Drawing;
using System.Windows.Forms;

namespace KoTeK_GUI
{
    public class BeforeAfterViewer : Control
    {
        private Image _beforeImage;
        private Image _afterImage;
        private int _splitPosition;
        private bool _isDragging;

        public Image BeforeImage
        {
            get => _beforeImage;
            set { _beforeImage = value; Invalidate(); }
        }

        public Image AfterImage
        {
            get => _afterImage;
            set { _afterImage = value; Invalidate(); }
        }

        public BeforeAfterViewer()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.DoubleBuffer, true);
            _splitPosition = Width / 2;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (_splitPosition == 0 || _splitPosition > Width)
                _splitPosition = Width / 2;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.FromArgb(12, 33, 41));

            if (_beforeImage == null || _afterImage == null)
                return;

            Rectangle fullRect = ClientRectangle;

            if (_splitPosition > 0)
            {
                Rectangle leftRect = new Rectangle(0, 0, _splitPosition, fullRect.Height);
                g.SetClip(leftRect);
                g.DrawImage(_beforeImage, fullRect);
                g.ResetClip();
            }

            if (_splitPosition < fullRect.Width)
            {
                Rectangle rightRect = new Rectangle(_splitPosition, 0, fullRect.Width - _splitPosition, fullRect.Height);
                g.SetClip(rightRect);
                g.DrawImage(_afterImage, fullRect);
                g.ResetClip();
            }

            using (var pen = new Pen(Color.White, 2))
            {
                g.DrawLine(pen, _splitPosition, 0, _splitPosition, fullRect.Height);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = true;
                UpdateSplitPosition(e.X);
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_isDragging)
                UpdateSplitPosition(e.X);
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _isDragging = false;
            base.OnMouseUp(e);
        }

        private void UpdateSplitPosition(int x)
        {
            _splitPosition = Math.Max(0, Math.Min(Width, x));
            Invalidate();
        }
    }
}