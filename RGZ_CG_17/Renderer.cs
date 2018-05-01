using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace RGZ_CG_17 {
    public class Renderer {
        private GLControl _g;
        private Color BackgroundColor = Color.White;
        private Color GridColor = Color.DarkGray;
        private Color Graph1Color = Color.Red;
        private Color Graph2Color = Color.LimeGreen;
        private Color Graph3Color = Color.Blue;
        private Color Point1Color = Color.Black;

        public readonly float ZoomIn = 1.2f;
        public readonly float ZoomOut = 0.83333f;

        private int CellSize = 1;
        private int xl, yl;
        private int _drawMode = 1;

        public int DrawMode {
            get { return _drawMode; }
            set { _drawMode = value; }
        }

        private int xm { get { return xl + _g.Width; } }
        private int ym { get { return yl + _g.Height; } }

        public float Scale = 30f;
        public float TranslateX = 0;
        public float TranslateY = 0;

        public Renderer(GLControl g) {
            this._g = g;
            xl = -_g.Width / 2;
            yl = -_g.Height / 2;
            TranslateX = _g.Width / 2 / Scale;
            TranslateY = -_g.Height / 2 / Scale;
        }

        public void Initialize() {
            GL.ClearColor(BackgroundColor);
            GL.Viewport(_g.ClientSize);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, _g.Width, -_g.Height, 0, -1, 1);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
        }

        public void ApplyResize() {
            Initialize();
        }

        public void Refresh() {
            _g.Invalidate();
        }

        public void ScaleIn(int delta = 1) {
            Scale *= (float)Math.Pow(ZoomIn, delta);
        }

        public void ScaleOut(int delta = 1) {
            if (Scale <= 2) return;
            Scale *= (float)Math.Pow(ZoomOut, delta);
        }

        public void Move(int dx, int dy) {
            TranslateX -= (float)dx / Scale;
            TranslateY += (float)dy / Scale;
        }

        public void Begin() {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.LoadIdentity();
            GL.Scale(Scale, Scale, 1);
            GL.Translate(TranslateX, TranslateY, 0);
        }

        public void DrawGrid()
        {
            GL.LineWidth(1);
            GL.Color3(GridColor);
            GL.Begin(PrimitiveType.Lines);
            for (int i = xl - xl % CellSize; i < xm + xm % CellSize; i += CellSize) {
                GL.Vertex2(i, yl);
                GL.Vertex2(i, ym);
            }
            for (int i = yl - yl % CellSize; i < ym + ym % CellSize; i += CellSize) {
                GL.Vertex2(xl, i);
                GL.Vertex2(xm, i);
            }
            GL.End();
        }

        public void DrawAxis() {
            GL.LineWidth(3);
            GL.Color3(GridColor);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(xl, 0);
            GL.Vertex2(xm, 0);
            GL.Vertex2(0, yl);
            GL.Vertex2(0, ym);
            GL.End();
        }

        public void DrawSpline(Spline s) {
            GL.LineWidth(2);
            if ((_drawMode & (1 << 0)) != 0) {
                GL.Color3(Graph1Color);
                GL.Begin(PrimitiveType.LineStrip);
                foreach (var pt in s.PointsView) {
                    GL.Vertex2(pt.X, pt.Y);
                }
                GL.End();
            }

            if ((_drawMode & (1 << 1)) != 0) {
                GL.Color3(Graph2Color);
                GL.Begin(PrimitiveType.LineStrip);
                foreach (var pt in s.dPoints)
                {
                    GL.Vertex2(pt.X, pt.Y);
                }
                GL.End();
            }

            if ((_drawMode & (1 << 2)) != 0) {
                GL.Color3(Graph3Color);
                GL.Begin(PrimitiveType.LineStrip);
                foreach (var pt in s.iPoints) {
                    GL.Vertex2(pt.X, pt.Y);
                }
                GL.End();
            }
        }

        public void DrawPoints(Spline s) {
            GL.Color3(Point1Color);
            GL.Begin(PrimitiveType.Quads);
            foreach (var pt in s.Points) {
                GL.Vertex2(pt.X - 0.1, pt.Y + 0.1);
                GL.Vertex2(pt.X - 0.1, pt.Y - 0.1);
                GL.Vertex2(pt.X + 0.1, pt.Y - 0.1);
                GL.Vertex2(pt.X + 0.1, pt.Y + 0.1);
            }
            GL.End();
        }
    }
}
