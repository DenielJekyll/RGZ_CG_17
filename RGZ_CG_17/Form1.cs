using System;
using System.Drawing;
using System.Windows.Forms;
using OpenTK;

namespace RGZ_CG_17
{
    public partial class Form : System.Windows.Forms.Form
    {
        private bool _initialized = false;
        private Renderer r;
        private Spline s;
        private Point _mouse1, _mouse2;
        private bool _isMoving = false;

        public Form()
        {
            InitializeComponent();
            r = new Renderer(GLC);
            s = new Spline();
        }

        private void GLControl_Resize(object sender, EventArgs e)
        {
            if (!_initialized) return;
            r.ApplyResize();
        }

        private void GLControl_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    {
                        _isMoving = true;
                        _mouse1 = e.Location;
                    }
                    break;
                case MouseButtons.Left:
                    {
                        _mouse2 = e.Location;
                    }
                    break;
            }
        }

        private void GLControl_MouseMove(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right: {
                if (_isMoving)
                {
                    if (Math.Abs(_mouse1.X - e.X) > r.Scale || Math.Abs(_mouse1.Y - e.Y) > r.Scale)
                    {
                        r.Move(_mouse1.X - e.X, _mouse1.Y - e.Y);
                        _mouse1 = e.Location;
                        r.Refresh();
                    }
                }
            }
            break;
                case MouseButtons.Left: {
                r.Refresh();
            }
            break;
        }
    }

        private void GLControl_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    {
                        _isMoving = false;
                    }
                    break;
                case MouseButtons.Left:
                    {
                        var pt = new PointF(e.X / r.Scale - r.TranslateX, -e.Y / r.Scale - r.TranslateY);
                        s.AddPoint(pt);
                        r.Refresh();
                    }
                    break;
            }
        }

        private void GLControl_Load(object sender, EventArgs e)
        {
            ((GLControl)sender).MakeCurrent();
            r.Initialize();

            _initialized = true;
        }

        private void accuracyValue_trackBar_Scroll(object sender, EventArgs e)
        {
            accuracyValue_label.Text = accuracyValue_trackBar.Value.ToString();
            s.Steps = accuracyValue_trackBar.Value;
            r.Refresh();
        }

        private void spline_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            r.DrawMode ^= (1 << Convert.ToInt32(((CheckBox)sender).Tag));
            r.Refresh();
        }

        private void GLControl_Paint(object sender, PaintEventArgs e)
        {
            if (!_initialized) return;
            ((GLControl)sender).MakeCurrent();

            r.Begin();
            r.DrawGrid();
            r.DrawAxis();
            r.DrawSpline(s);
            r.DrawPoints(s);
            r.End();

            ((GLControl)sender).SwapBuffers();
        }
    }
}
