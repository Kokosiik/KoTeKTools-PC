using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class SnowOverlayForm : Form
{
    private List<Snowflake> snowflakes = new List<Snowflake>();
    private Random rand = new Random();
    private Timer timer;
    private Form ownerForm;

    public SnowOverlayForm(Form owner)
    {
        if (owner == null) throw new ArgumentNullException(nameof(owner));
        ownerForm = owner;

        FormBorderStyle = FormBorderStyle.None;
        ShowInTaskbar = false;
        TopMost = true;
        BackColor = Color.Black;
        TransparencyKey = Color.Black;
        Enabled = false;
        DoubleBuffered = true;
        SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.UserPaint |
                 ControlStyles.OptimizedDoubleBuffer, true);

        ownerForm.Move += OnOwnerMoved;
        ownerForm.Resize += OnOwnerResized;
        ownerForm.LocationChanged += OnOwnerMoved;
        ownerForm.SizeChanged += OnOwnerResized;

        for (int i = 0; i < 130; i++)
            AddNewSnowflake();

        timer = new Timer { Interval = 20 };
        timer.Tick += OnTimerTick;
        timer.Start();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        UpdatePositionAndSize();
    }

    private void OnOwnerMoved(object sender, EventArgs e) => UpdatePositionAndSize();
    private void OnOwnerResized(object sender, EventArgs e) => UpdatePositionAndSize();

    private void UpdatePositionAndSize()
    {
        if (ownerForm == null || ownerForm.IsDisposed || !ownerForm.IsHandleCreated)
            return;

        this.Size = ownerForm.ClientSize;
        this.Location = ownerForm.PointToScreen(Point.Empty);
    }

    private void AddNewSnowflake()
    {
        snowflakes.Add(new Snowflake
        {
            X = rand.Next(0, Width),
            Y = rand.Next(-Height, 0),
            Speed = 1 + rand.NextDouble() * 3,
            Size = 2 + rand.Next(5),
            Drift = (float)(rand.NextDouble() - 0.7) * 0.111520511f
        });
    }

    private void OnTimerTick(object sender, EventArgs e)
    {
        if (ownerForm?.IsDisposed == true) return;

        for (int i = snowflakes.Count - 1; i >= 0; i--)
        {
            var flake = snowflakes[i];
            flake.Y += (float)flake.Speed;
            flake.X += flake.Drift;

            if (flake.Y > Height || flake.X < -10 || flake.X > Width + 10)
            {
                snowflakes.RemoveAt(i);
                AddNewSnowflake();
            }
        }
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.Clear(Color.Black);
        foreach (var flake in snowflakes)
        {
            using (var brush = new SolidBrush(Color.FromArgb(150, 240, 248, 255)))
            {
                e.Graphics.FillEllipse(brush, flake.X, flake.Y, flake.Size, flake.Size);
            }
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            timer?.Stop();
            timer?.Dispose();
            if (ownerForm != null)
            {
                ownerForm.Move -= OnOwnerMoved;
                ownerForm.Resize -= OnOwnerResized;
                ownerForm.LocationChanged -= OnOwnerMoved;
                ownerForm.SizeChanged -= OnOwnerResized;
            }
        }
        base.Dispose(disposing);
    }
}

public class Snowflake
{
    public float X, Y;
    public double Speed;
    public float Size;
    public float Drift;
}