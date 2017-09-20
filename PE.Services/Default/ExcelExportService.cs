using PE.Common;
using PE.Common.Exceptions;
using PE.Common.ProgressInfo;
using PE.Entities;
using PE.Language;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace PE.Services.Default
{
    public class ExcelExportService<TCompositePoint, TPoint> : IExportService<TCompositePoint, TPoint>
        where TCompositePoint : ICompositePoint<TPoint>, new()
        where TPoint : IPoint, new()
    {
        private IResourceManager resourceManager;

        public ExcelExportService(IResourceManager resourceManager)
        {
            this.resourceManager = resourceManager;
        }

        public async Task ExportToExcelAsync(IEnumerable<TCompositePoint> points, bool calculateOffsets, 
            bool calculatePlanar, bool calculateBearingDepth, string fileName,
            CancellationToken cancellationToken, IProgress<ExportInfo> progress = null)
        {
            await Task.Run(() => ExportToExcel(points, calculateOffsets, calculatePlanar, calculateBearingDepth, fileName, cancellationToken, progress),
                cancellationToken);
        }

        public void ExportToExcel(IEnumerable<TCompositePoint> points, bool calculateOffsets,
            bool calculatePlanar, bool calculateBearingDepth, string fileName,
            CancellationToken cancellationToken, IProgress<ExportInfo> progress = null)
        {
            if (calculatePlanar)
            {
                ExportPoints(points.Select(p => p.PlanarPoint), fileName, "planar", cancellationToken, progress);
            }
            else
            {
                ExportPoints(points.Select(p => p.Point), fileName, "main", cancellationToken, progress);
            }

            if (calculateOffsets)
            {
                ExportPoints(points.Select(p => p.AbovePoint), fileName, "above", cancellationToken, progress);

                ExportPoints(points.Select(p => p.BelowPoint), fileName, "below", cancellationToken, progress);

                if (calculateBearingDepth)
                {
                    ExportPoints(points.Select(p => p.AboveInnerPoint), fileName, "above_inner", cancellationToken, progress);

                    ExportPoints(points.Select(p => p.BelowInnerPoint), fileName, "below_inner", cancellationToken, progress);
                }
            }
        }

        private void ExportPoints(IEnumerable<TPoint> points, string fileName, string infoText,
            CancellationToken cancellationToken, IProgress<ExportInfo> progress = null)
        {
            DataTable dtPoints = PointsToTable(points, infoText, cancellationToken, progress);

            fileName = GenerateFileName(fileName, infoText);

            ExportPointsToExcel(dtPoints, fileName, infoText, cancellationToken, progress);
        }

        private static string GenerateFileName(string fileName, string infoText = null)
        {
            return fileName.Insert(fileName.Length - 5, string.Format("_{0}", infoText));
        }

        private static DataTable PointsToTable(IEnumerable<TPoint> points, string infoText,
            CancellationToken cancellationToken, IProgress<ExportInfo> progress = null)
        {
            cancellationToken.ThrowIfCancellationRequested();

            DataTable dtPoints = new DataTable();
            dtPoints.Columns.Add(Constants.COLUMN_X, typeof(double));
            dtPoints.Columns.Add(Constants.COLUMN_Y, typeof(double));
            dtPoints.Columns.Add(Constants.COLUMN_Z, typeof(double));
            dtPoints.Columns.Add(Constants.COLUMN_ANGLE, typeof(double));

            // half of export
            int index = 0;
            int count = points.Count();
            foreach (IPoint point in points)
            {
                cancellationToken.ThrowIfCancellationRequested();

                DataRow row = dtPoints.NewRow();
                row[Constants.COLUMN_X] = point.X;
                row[Constants.COLUMN_Y] = point.Y;
                row[Constants.COLUMN_Z] = point.Z;
                row[Constants.COLUMN_ANGLE] = point.Angle;
                dtPoints.Rows.Add(row);

                if (progress != null)
                    progress.Report(new ExportInfo(index++ * 50 / count, infoText));
            }

            return dtPoints;
        }

        private void ExportPointsToExcel(DataTable dtPoints, string fileName, string infoText,
            CancellationToken cancellationToken, IProgress<ExportInfo> progress = null)
        {
            cancellationToken.ThrowIfCancellationRequested();

            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

            if (excelApp == null)
                throw new PEException(resourceManager, "excel_not_installed");

            cancellationToken.ThrowIfCancellationRequested();
            Microsoft.Office.Interop.Excel.Workbook excelWorkBook = excelApp.Workbooks.Add(Type.Missing);

            cancellationToken.ThrowIfCancellationRequested();
            Microsoft.Office.Interop.Excel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add();
            excelWorkSheet.Name = "points";

            int i = 1;
            IEnumerable<PropertyInfo> properties = typeof(IPoint).GetProperties();
            foreach (DataColumn column in dtPoints.Columns)
            {
                cancellationToken.ThrowIfCancellationRequested();

                excelWorkSheet.Cells[1, i++] = column.ColumnName;
            }

            // next half of export
            int index = dtPoints.Rows.Count;
            int count = dtPoints.Rows.Count * 2;
            i = 1;
            foreach (DataRow drPoint in dtPoints.Rows)
            {
                int j = 1;
                foreach (DataColumn column in dtPoints.Columns)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    excelWorkSheet.Cells[i + 1, j] = drPoint[column.ColumnName];
                    j++;
                }
                i++;

                if (progress != null)
                    progress.Report(new ExportInfo(index++ * 100 / count, infoText));
            }

            excelWorkBook.SaveAs(fileName);
            excelWorkBook.Close();
            excelApp.Quit();
        }
    }
}
