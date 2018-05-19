using System;
using System.Collections.Generic;
using System.Drawing;

namespace RGZ_CG_31 { 
    public class Spline {
        private char[] _separators = { ' ', '\n', '\r', '\t' };
        private List<SplineFunction> splinePoints;
        private List<PointF> _points;
        private List<PointF> _pointsView;
        public List<PointF> dPoints;
        public List<PointF> iPoints;

        private int _steps = 10;

        public int Steps {
            get { return _steps; }
            set { _steps = Math.Abs(value); ApplyChanges(); }
        }

        public List<PointF> Points { get { return _points; } }
        public List<PointF> PointsView { get { return _pointsView; } }

        public Spline() {
            splinePoints = new List<SplineFunction>();
            _points = new List<PointF>();
            _pointsView = new List<PointF>();
            dPoints = new List<PointF>();
            iPoints = new List<PointF>();
        }

        #region Calculations

        private void CreateSF() {
            splinePoints = new List<SplineFunction>();
            SplineFunction prev = null;
            foreach (var pt in _points) {
                var splinePoints1 = new SplineFunction {
                    X = pt.X,
                    A = pt.Y
                };
                if (_points.IndexOf(pt) > 0) {
                    splinePoints1.H = pt.X - prev.X;
                }
                splinePoints.Add(splinePoints1);
                prev = splinePoints1;
            }

            if (splinePoints.Count == 0)
                throw new InvalidOperationException("List is empty");
            splinePoints[0].C = 0;
            splinePoints[splinePoints.Count - 1].C = 0;
        }

        public void CountC() {
            float A = 0, B = 0, C = 0, F = 0;
            float[] a = new float[splinePoints.Count - 1];
            float[] b = new float[splinePoints.Count - 1];
            a.Initialize(); 
            b.Initialize();
            for (int i = 1; i < splinePoints.Count - 1; i++) {
                A = splinePoints[i].H;
                B = splinePoints[i + 1].H;
                float dy = splinePoints[i].A - splinePoints[i - 1].A;
                float dy1 = splinePoints[i + 1].A - splinePoints[i].A;
                C = 2 * (A + B);
                F = 6 * (dy1 / B - dy / A);
                float z = (A * a[i - 1] + C);
                a[i] = -B / z;
                b[i] = (F - A * b[i - 1]) / z;
            }
            splinePoints[splinePoints.Count - 2].C = (F - A * b[splinePoints.Count - 2]) / (C + A * a[splinePoints.Count - 2]);
            for (int i = splinePoints.Count - 2; i >= 1; i--) {
                splinePoints[i].C = a[i] * splinePoints[i + 1].C + b[i];
            }
        }

        private void CountBAD() {
            splinePoints[0].B = 0;
            splinePoints[0].D = 0;
            for (int i = 1, j = 0; i < splinePoints.Count; i++, j++) {
                splinePoints[i].D = (splinePoints[i].C - splinePoints[j].C);
                splinePoints[i].D /= splinePoints[i].H;
                splinePoints[i].B = ((splinePoints[i].A - splinePoints[j].A) / splinePoints[i].H) + (splinePoints[i].H * (2 * splinePoints[i].C + splinePoints[j].C) / 6);
            }
            for (int i = 0; i < splinePoints.Count; i++) {
                splinePoints[i].C /= 2;
                splinePoints[i].D /= 6;
            }
        }

        private void CalculatePoints() {
            int n = _steps * splinePoints.Count;
            _pointsView = new List<PointF>(n);
            _pointsView.Add(new PointF(splinePoints[0].X, splinePoints[0].Func()));
            iPoints = new List<PointF>(n);
            SplineFunction pf_prev = null;
            float y = 0, y0 = 0, y1;
            foreach (var pf in splinePoints) {
                if (splinePoints.IndexOf(pf) > 0) {
                    float part = (pf.X - pf_prev.X) / _steps;
                    float X = pf_prev.X;
                    y1 = pf.I_Func(X);
                    for (int j = 0; j < _steps; j++) {
                        X += part;
                        y = pf.Func(X);
                        _pointsView.Add(new PointF(X, y));
                        y = -y1 + y0 + pf.I_Func(X);
                        iPoints.Add(new PointF(X, y));
                    }
                    y0 = y;
                }
                pf_prev = pf;
            }
        }
        #endregion

        private double Func(int i, double ds) {
            double res = splinePoints[i].A;
            res += splinePoints[i].B * (ds - splinePoints[i].X);
            res += splinePoints[i].C * (ds - splinePoints[i].X) * (ds - splinePoints[i].X);
            res += splinePoints[i].D * (ds - splinePoints[i].X) * (ds - splinePoints[i].X) * (ds - splinePoints[i].X);
            return res;
        }

        public static double Func(double a, double b, double c, double d, double x, double s) {
            double an = a;
            an += b * (s - x);
            an += c * (s - x) * (s - x);
            an += d * (s - x) * (s - x) * (s - x);
            return an;
        }

        private void ApplyChanges() {
            if (_points.Count < 2) return;
            _points.Sort((x, y) => x.X.CompareTo(y.X));
            CreateSF();
            CountC();
            CountBAD();
            CalculatePoints();
        }

        private static int SortByX(PointF p1, PointF p2) {
            if (p1.X > p2.X) return 1;
            if (p1.X < p2.X) return -1;
            if (p1.X.Equals(p2.X)) return p1.Y < p2.Y ? -1 : 1;
            return 0;
        }

        public void AddPoint(PointF pt) {
            int id;
            if (!(id = _points.FindIndex(x => x.X.Equals(pt.X))).Equals(-1)) {
                _points[id] = new PointF(pt.X, pt.Y);
            } else _points.Add(pt);
            ApplyChanges();
        }

        public void Clear() {
            _points.Clear();
            _pointsView.Clear();
            dPoints.Clear();
            iPoints.Clear();
        }
    }
}