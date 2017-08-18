using PE.Entities;

namespace PointExporter
{
	partial class PEMainForm<TCompositePoint, TPoint, TSegment>
		where TCompositePoint : ICompositePoint<TPoint>, new()
		where TPoint : IPoint, new()
		where TSegment : ISegment, new()
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tcMain = new PE.Controls.PETabControl();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.btnCalculate = new MetroFramework.Controls.MetroButton();
            this.ucSegments = new PE.Controls.Default.PointSegments();
            this.ucSettings = new PE.Controls.Settings();
            this.tpCharts = new System.Windows.Forms.TabPage();
            this.btnExport = new MetroFramework.Controls.MetroButton();
            this.btnBack = new MetroFramework.Controls.MetroButton();
            this.ucCharts = new PE.Controls.Default.PointCharts();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tcMain.SuspendLayout();
            this.tpSettings.SuspendLayout();
            this.tpCharts.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMain.Controls.Add(this.tpSettings);
            this.tcMain.Controls.Add(this.tpCharts);
            this.tcMain.Location = new System.Drawing.Point(15, 60);
            this.tcMain.Name = "tcMain";
            this.tcMain.Padding = new System.Drawing.Point(6, 8);
            this.tcMain.SelectedIndex = 1;
            this.tcMain.Size = new System.Drawing.Size(948, 392);
            this.tcMain.TabIndex = 3;
            this.tcMain.TabStop = false;
            this.tcMain.UseSelectable = true;
            // 
            // tpSettings
            // 
            this.tpSettings.BackColor = System.Drawing.SystemColors.Window;
            this.tpSettings.Controls.Add(this.btnCalculate);
            this.tpSettings.Controls.Add(this.ucSegments);
            this.tpSettings.Controls.Add(this.ucSettings);
            this.tpSettings.Location = new System.Drawing.Point(4, 38);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Size = new System.Drawing.Size(940, 350);
            this.tpSettings.TabIndex = 0;
            this.tpSettings.Text = "Settings";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCalculate.Location = new System.Drawing.Point(410, 300);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(129, 37);
            this.btnCalculate.TabIndex = 4;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseSelectable = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // ucSegments
            // 
            this.ucSegments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSegments.CalculateOffsets = false;
            this.ucSegments.Location = new System.Drawing.Point(257, 8);
            this.ucSegments.Name = "ucSegments";
            this.ucSegments.ResultPoints = null;
            this.ucSegments.Size = new System.Drawing.Size(674, 279);
            this.ucSegments.TabIndex = 3;
            this.ucSegments.TitleText = "Point Exporter";
            this.ucSegments.UseSelectable = true;
            // 
            // ucSettings
            // 
            this.ucSettings.Location = new System.Drawing.Point(12, 8);
            this.ucSettings.Name = "ucSettings";
            this.ucSettings.Size = new System.Drawing.Size(239, 279);
            this.ucSettings.TabIndex = 2;
            this.ucSettings.UseSelectable = true;
            // 
            // tpCharts
            // 
            this.tpCharts.BackColor = System.Drawing.SystemColors.Window;
            this.tpCharts.Controls.Add(this.btnExport);
            this.tpCharts.Controls.Add(this.btnBack);
            this.tpCharts.Controls.Add(this.ucCharts);
            this.tpCharts.Location = new System.Drawing.Point(4, 38);
            this.tpCharts.Name = "tpCharts";
            this.tpCharts.Size = new System.Drawing.Size(940, 350);
            this.tpCharts.TabIndex = 1;
            this.tpCharts.Text = "Charts";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExport.Location = new System.Drawing.Point(454, 300);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(129, 37);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export";
            this.btnExport.UseSelectable = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnBack.Location = new System.Drawing.Point(300, 300);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(129, 37);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseSelectable = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ucCharts
            // 
            this.ucCharts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucCharts.BackColor = System.Drawing.SystemColors.Window;
            this.ucCharts.Location = new System.Drawing.Point(10, 11);
            this.ucCharts.Name = "ucCharts";
            this.ucCharts.Size = new System.Drawing.Size(850, 278);
            this.ucCharts.TabIndex = 0;
            this.ucCharts.UseSelectable = true;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // PEMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(977, 469);
            this.Controls.Add(this.tcMain);
            this.MinimumSize = new System.Drawing.Size(977, 469);
            this.Name = "PEMainForm";
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Point exporter";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.tcMain.ResumeLayout(false);
            this.tpSettings.ResumeLayout(false);
            this.tpCharts.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private PE.Controls.PETabControl tcMain;
        private System.Windows.Forms.TabPage tpSettings;
        private System.Windows.Forms.TabPage tpCharts;
        private PE.Controls.Default.PointCharts ucCharts;
        private PE.Controls.Settings ucSettings;
        private PE.Controls.Default.PointSegments ucSegments;
        private MetroFramework.Controls.MetroButton btnCalculate;
        private MetroFramework.Controls.MetroButton btnBack;
        private MetroFramework.Controls.MetroButton btnExport;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

