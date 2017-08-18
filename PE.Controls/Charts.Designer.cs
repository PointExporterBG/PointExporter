using PE.Entities;

namespace PE.Controls
{
    partial class Charts<TCompositePoint, TPoint>
        where TCompositePoint : ICompositePoint<TPoint>, new()
        where TPoint : IPoint, new()
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.gbResults = new System.Windows.Forms.GroupBox();
            this.chartResultAngleZ = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartResultXY = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gbResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartResultAngleZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartResultXY)).BeginInit();
            this.SuspendLayout();
            // 
            // gbResults
            // 
            this.gbResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbResults.Controls.Add(this.chartResultAngleZ);
            this.gbResults.Controls.Add(this.chartResultXY);
            this.gbResults.Location = new System.Drawing.Point(0, 0);
            this.gbResults.Name = "gbResults";
            this.gbResults.Size = new System.Drawing.Size(927, 279);
            this.gbResults.TabIndex = 18;
            this.gbResults.TabStop = false;
            this.gbResults.Text = "Results";
            // 
            // chartResultAngleZ
            // 
            chartArea1.AxisX.Title = "Angle";
            chartArea1.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea1.AxisY.Title = "Z";
            chartArea1.Name = "ChartArea1";
            this.chartResultAngleZ.ChartAreas.Add(chartArea1);
            this.chartResultAngleZ.Location = new System.Drawing.Point(61, 11);
            this.chartResultAngleZ.Name = "chartResultAngleZ";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.chartResultAngleZ.Series.Add(series1);
            this.chartResultAngleZ.Size = new System.Drawing.Size(260, 260);
            this.chartResultAngleZ.TabIndex = 0;
            this.chartResultAngleZ.TabStop = false;
            this.chartResultAngleZ.Text = "chartResultAngleZ";
            // 
            // chartResultXY
            // 
            this.chartResultXY.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea2.AxisX.Title = "X";
            chartArea2.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea2.AxisY.Title = "Y";
            chartArea2.Name = "ChartArea1";
            this.chartResultXY.ChartAreas.Add(chartArea2);
            this.chartResultXY.Location = new System.Drawing.Point(335, 11);
            this.chartResultXY.Name = "chartResultXY";
            series2.ChartArea = "ChartArea1";
            series2.Name = "Series1";
            this.chartResultXY.Series.Add(series2);
            this.chartResultXY.Size = new System.Drawing.Size(260, 260);
            this.chartResultXY.TabIndex = 0;
            this.chartResultXY.TabStop = false;
            this.chartResultXY.Text = "chartResult";
            // 
            // Charts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.gbResults);
            this.Name = "Charts";
            this.Size = new System.Drawing.Size(929, 279);
            this.gbResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartResultAngleZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartResultXY)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbResults;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartResultAngleZ;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartResultXY;
    }
}
