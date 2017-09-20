using PE.Common;
using PE.Controls.Base;
using PE.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace PE.Controls
{
    public partial class Charts<TCompositePoint, TPoint> : BaseUserControl
        where TCompositePoint : ICompositePoint<TPoint>, new()
        where TPoint : IPoint, new()
    {
        public Charts()
        {
            InitializeComponent();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            int chartSideLength = Height - Constants.CHART_VERTICAL_OFFSETS;
            chartResultAngleZ.Size = new Size(chartSideLength, chartSideLength);
            chartResultXY.Size = new Size(chartSideLength, chartSideLength);
            chartResultXY.Location = new Point(Constants.CHART_HORIZONTAL_OFFSETS + chartSideLength, Constants.CHART_VERTICAL_LOCATION);
        }

        public void DrawCharts(IEnumerable<TCompositePoint> points, bool calculateOffsets, bool planar, double radius)
        {
            InitializeChartXY(points, planar, radius);
            InitializeChartAngleZ();

            foreach (TCompositePoint point in points)
            {
                if (planar)
                    chartResultXY.Series[0].Points.AddXY(Math.Cos(point.Point.Angle * Constants.RADIAN) * (radius + point.Point.Z),
                                                         Math.Sin(point.Point.Angle * Constants.RADIAN) * (radius + point.Point.Z));
                else
                    chartResultXY.Series[0].Points.AddXY(point.Point.X, point.Point.Y);

                chartResultAngleZ.Series[0].Points.AddXY(point.Point.Angle, point.Point.Z);
                if (calculateOffsets)
                {
                    chartResultAngleZ.Series[1].Points.AddXY(point.AbovePoint.Angle, point.AbovePoint.Z);
                    chartResultAngleZ.Series[2].Points.AddXY(point.BelowPoint.Angle, point.BelowPoint.Z);
                }
            }
        }

        private void InitializeChartXY(IEnumerable<TCompositePoint> points, bool planar, double radius)
        {
            chartResultXY.Series.Clear();
            foreach (var series in chartResultXY.Series)
                series.Points.Clear();
            chartResultXY.Series.Add("Series0");
            chartResultXY.Series[0].ChartType = SeriesChartType.Line;
            chartResultXY.Series[0].Color = Constants.DEFAULT_COLOR;
            chartResultXY.Legends.Clear();
            double maxX = planar
                ? points.Max(p => Math.Cos(p.Point.Angle * Constants.RADIAN) * (radius + p.Point.Z))
                : points.Max(p => p.Point.X);
            double minX = planar
                ? points.Min(p => Math.Cos(p.Point.Angle * Constants.RADIAN) * (radius + p.Point.Z))
                : points.Min(p => p.Point.X);
            double maxY = planar
                ? points.Max(p => Math.Sin(p.Point.Angle * Constants.RADIAN) * (radius + p.Point.Z))
                : points.Max(p => p.Point.Y);
            double minY = planar
                ? points.Min(p => Math.Sin(p.Point.Angle * Constants.RADIAN) * (radius + p.Point.Z))
                : points.Min(p => p.Point.Y);
            chartResultXY.ChartAreas[0].AxisX.Maximum = maxX;
            chartResultXY.ChartAreas[0].AxisX.Minimum = minX;
            chartResultXY.ChartAreas[0].AxisY.Maximum = maxY;
            chartResultXY.ChartAreas[0].AxisY.Minimum = minY;
            chartResultXY.ChartAreas[0].AxisX.Interval = (maxX - minX) / Constants.CHART_AXIS_LABELS_COUNT;
            chartResultXY.ChartAreas[0].AxisY.Interval = (maxY - minY) / Constants.CHART_AXIS_LABELS_COUNT;
            chartResultXY.ChartAreas[0].AxisX.LabelStyle.Format = Constants.CHART_AXIS_FORMAT;
            chartResultXY.ChartAreas[0].AxisY.LabelStyle.Format = Constants.CHART_AXIS_FORMAT;
            chartResultXY.ChartAreas[0].AxisX.MajorGrid.LineColor = Constants.CHART_LINES_COLOR;
            chartResultXY.ChartAreas[0].AxisY.MajorGrid.LineColor = Constants.CHART_LINES_COLOR;
        }

        private void InitializeChartAngleZ()
        {
            chartResultAngleZ.Series.Clear();
            foreach (var series in chartResultAngleZ.Series)
                series.Points.Clear();
            chartResultAngleZ.Series.Add("Series0");
            chartResultAngleZ.Series[0].ChartType = SeriesChartType.Line;
            chartResultAngleZ.Series[0].Color = Constants.DEFAULT_COLOR;
            chartResultAngleZ.Legends.Clear();
            chartResultAngleZ.Series.Add("Series1");
            chartResultAngleZ.Series[1].ChartType = SeriesChartType.Line;
            chartResultAngleZ.Series[1].Color = Constants.DEFAULT_COLOR;
            chartResultAngleZ.Series.Add("Series2");
            chartResultAngleZ.Series[2].ChartType = SeriesChartType.Line;
            chartResultAngleZ.Series[2].Color = Constants.DEFAULT_COLOR;
            chartResultAngleZ.ChartAreas[0].AxisX.LabelStyle.Format = Constants.CHART_AXIS_FORMAT;
            chartResultAngleZ.ChartAreas[0].AxisY.LabelStyle.Format = Constants.CHART_AXIS_FORMAT;
            chartResultAngleZ.ChartAreas[0].AxisX.MajorGrid.LineColor = Constants.CHART_LINES_COLOR;
            chartResultAngleZ.ChartAreas[0].AxisY.MajorGrid.LineColor = Constants.CHART_LINES_COLOR;
        }

        public void Clear()
        {
            chartResultXY.Series.Clear();
            chartResultAngleZ.Series.Clear();
        }

        public override void SetResources()
        {
            gbResults.Text = GetResource("results");
            chartResultAngleZ.ChartAreas[0].AxisX.Title = GetResource("angle");
            chartResultAngleZ.ChartAreas[0].AxisY.Title = GetResource("z");
            chartResultXY.ChartAreas[0].AxisX.Title = GetResource("x");
            chartResultXY.ChartAreas[0].AxisY.Title = GetResource("y");
        }
    }
}
