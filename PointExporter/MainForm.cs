#region Usings

using PE.Common.EventArguments;
using PE.Controls;
using PE.Controls.Base;
using PE.Entities;
using PE.Language;
using MetroFramework;
using MetroFramework.Controls;
using PE.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using PE.Common.ProgressInfo;

#endregion

namespace PointExporter
{
    public partial class PEMainForm<TCompositePoint, TPoint, TSegment> : BaseForm
        where TCompositePoint : ICompositePoint<TPoint>, new()
        where TPoint : IPoint, new()
        where TSegment : ISegment, new()
    {
        #region Fields

        private readonly ICalculateService<TCompositePoint, TPoint, TSegment> calculateService;
        private readonly IExportService<TCompositePoint, TPoint> exportService;
        private readonly ISegmentManager<TSegment> segmentManager;
        private readonly IResourceManager resourceManager;

        private IEnumerable<TCompositePoint> ResultPoints;

        #endregion

        #region Constructor
        public PEMainForm(ICalculateService<TCompositePoint, TPoint, TSegment> calculateService,
                          IExportService<TCompositePoint, TPoint> exportService,
                          ISegmentManager<TSegment> segmentManager,
                          IResourceManager resourceManager)
        {
            this.calculateService = calculateService;
            this.exportService = exportService;
            this.segmentManager = segmentManager;
            this.resourceManager = resourceManager;

            ResourceManager = resourceManager;

            InitializeComponent();

            InitializeFields();

            InitializeUserControlsLocalization();

            Thread.CurrentThread.CurrentUICulture = CultureInfo.InstalledUICulture;

            SetResources();
        }

        #endregion

        #region Event Handlers

        private async void btnCalculate_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            ProgressForm progressForm = new ProgressForm();
            progressForm.ResourceManager = resourceManager;
            Control[] lblProgressArray = progressForm.Controls.Find("lblProgress", true);
            Control[] metroProgressBarArray = progressForm.Controls.Find("metroProgressBar", true);

            IEnumerable<TSegment> segments = segmentManager.ParseSegments(ucSegments.SegmentRows);

            try
            {
                if (lblProgressArray.Any() && metroProgressBarArray.Any())
                {
                    progressForm.SetResources();
                    progressForm.Show();
                    MetroLabel lblProgress = lblProgressArray[0] as MetroLabel;
                    MetroProgressBar metroProgressBar = metroProgressBarArray[0] as MetroProgressBar;
                    lblProgress.Text = GetResource("calculating_0");

                    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                    progressForm.CancellationTokenSource = cancellationTokenSource;

                    ResultPoints = await calculateService.CalculatePointsAsync(
                        ucSettings.Radius, ucSettings.CalculatePlanar, ucSettings.CalculateOffsets, ucSettings.BearingRadius,
                        ucSettings.CalculateBearingDepth, ucSettings.BearingDepth,
                        ucSettings.OffsetZ, ucSettings.DirectionSign, segments,
                        cancellationTokenSource.Token, new Progress<int>(percent =>
                        {
                            lblProgress.Text = GetResource("calculating_percent", percent);
                            metroProgressBar.Value = percent;
                            metroProgressBar.Update();
                        }));

                    progressForm.Close();
                }
                else
                {
                    ResultPoints = await calculateService.CalculatePointsAsync(
                        ucSettings.Radius, ucSettings.CalculatePlanar, ucSettings.CalculateOffsets, ucSettings.BearingRadius,
                        ucSettings.CalculateBearingDepth, ucSettings.BearingDepth,
                        ucSettings.OffsetZ, ucSettings.DirectionSign, segments,
                        CancellationToken.None);
                }

                (ucCharts as Charts<TCompositePoint, TPoint>).DrawCharts(ResultPoints, ucSettings.CalculateOffsets, 
                    ucSettings.CalculatePlanar, ucSettings.Radius);

                tcMain.SelectTab(tpCharts);
            }
            catch (Exception exc)
            {
                MetroMessageBox.Show(this, exc.Message, GetResource("error"));
                progressForm.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tcMain.SelectTab(tpSettings);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (!ResultPoints.Any())
            {
                MetroMessageBox.Show(this, GetResource("calculate_before_export"), GetResource("information"));
                return;
            }

            saveFileDialog.ShowDialog();
        }

        private async void saveFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ProgressForm progressForm = new ProgressForm();
            progressForm.ResourceManager = resourceManager;
            Control[] lblProgressArray = progressForm.Controls.Find("lblProgress", true);
            Control[] metroProgressBarArray = progressForm.Controls.Find("metroProgressBar", true);

            try
            {
                if (lblProgressArray.Any() && metroProgressBarArray.Any())
                {
                    progressForm.SetResources();
                    progressForm.Show();
                    MetroLabel lblProgress = lblProgressArray[0] as MetroLabel;
                    MetroProgressBar metroProgressBar = metroProgressBarArray[0] as MetroProgressBar;
                    lblProgress.Text = GetResource("exporting_0");

                    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                    progressForm.CancellationTokenSource = cancellationTokenSource;

                    await exportService.ExportToExcelAsync(ResultPoints, ucSettings.CalculateOffsets, 
                        ucSettings.CalculatePlanar, ucSettings.CalculateBearingDepth, saveFileDialog.FileName,
                        cancellationTokenSource.Token, new Progress<ExportInfo>(exportInfo =>
                        {
                            lblProgress.Text = GetResource(string.Format("exporting_{0}_percent", exportInfo.InfoText), exportInfo.Percent);
                            metroProgressBar.Value = exportInfo.Percent;
                            metroProgressBar.Update();
                        }));

                    progressForm.Close();
                }
                else
                    await exportService.ExportToExcelAsync(ResultPoints, ucSettings.CalculateOffsets,
                        ucSettings.CalculatePlanar, ucSettings.CalculateBearingDepth, saveFileDialog.FileName, CancellationToken.None);
            }
            catch (Exception exc)
            {
                MetroMessageBox.Show(this, exc.Message, GetResource("error"));
                progressForm.Close();
            }
        }

        private void OnTitleTextChanged(object sender, TitleChangedEventArgs e)
        {
            Text = e.TitleText;
            Refresh();
        }

        private void OnCleaned(object sender, EventArgs e)
        {
            ucCharts.Clear();
        }

        #endregion

        #region Private Methods

        #region Initialization

        private void InitializeFields()
        {
            ucSegments.TitleChanged += OnTitleTextChanged;
            ucSegments.Cleaned += OnCleaned;

            tcMain.SelectTab(tpSettings);
            ResultPoints = new List<TCompositePoint>();
        }

        private void InitializeUserControlsLocalization()
        {
            ucSettings.ResourceManager = resourceManager;
            ucSegments.ResourceManager = resourceManager;
            ucCharts.ResourceManager = resourceManager;
        }

        #endregion

        #region Validation

        private bool ValidateForm()
        {
            if (!ucSettings.Validate())
                return false;

            if (!ucSegments.Validate())
                return false;

            return true;
        }

        #endregion

        #region Localization

        public override void SetResources()
        {
            btnCalculate.Text = GetResource("calculate");
            btnBack.Text = GetResource("back");
            btnExport.Text = GetResource("export");

            SetUserControlResources();
        }

        private void SetUserControlResources()
        {
            ucSettings.SetResources();
            ucSegments.SetResources();
            ucCharts.SetResources();
        }

        #endregion

        #endregion
    }
}
