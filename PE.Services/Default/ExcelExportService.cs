using PE.Common;
using PE.Common.Exceptions;
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

        public async Task ExportToExcelAsync(IEnumerable<TCompositePoint> points, bool calculateOffsets, string fileName,
            CancellationToken cancellationToken, IProgress<int> progress = null)
        {
            await Task.Run(() => ExportToExcel(points, calculateOffsets, fileName, cancellationToken, progress),
                cancellationToken);
        }

        public void ExportToExcel(IEnumerable<TCompositePoint> points, bool calculateOffsets, string fileName,
            CancellationToken cancellationToken, IProgress<int> progress = null)
        {
            int index = 1;
            int totalProgress = 2 * points.Count(); // 2 -> 1 call PointsToTable + 1 call ExportPointsToExcel

            if (!calculateOffsets)
            {
                DataTable dtPoints = PointsToTable(points.Select(p => p.Point), ref index, totalProgress, cancellationToken, progress);
                ExportPointsToExcel(dtPoints, fileName, ref index, totalProgress, cancellationToken, progress);
            }
            else
            {
                totalProgress = 6 * totalProgress;  // 6 -> 3 calls PointsToTable + 3 calls ExportPointsToExcel

                DataTable dtPoints = PointsToTable(points.Select(p => p.Point), ref index, totalProgress, cancellationToken, progress);
                ExportPointsToExcel(dtPoints, fileName, ref index, totalProgress, cancellationToken, progress);

                dtPoints = PointsToTable(points.Select(p => p.AbovePoint), ref index, totalProgress, cancellationToken, progress);
                ExportPointsToExcel(dtPoints, fileName.Insert(fileName.Length - 5, "_above"), ref index, totalProgress, cancellationToken, progress);

                dtPoints = PointsToTable(points.Select(p => p.BelowPoint), ref index, totalProgress, cancellationToken, progress);
                ExportPointsToExcel(dtPoints, fileName.Insert(fileName.Length - 5, "_below"), ref index, totalProgress, cancellationToken, progress);
            }
        }

        private static DataTable PointsToTable(IEnumerable<TPoint> points, ref int index, int totalProgress,
            CancellationToken cancellationToken, IProgress<int> progress = null)
        {
            cancellationToken.ThrowIfCancellationRequested();

            DataTable dtPoints = new DataTable();
            dtPoints.Columns.Add(Constants.COLUMN_X, typeof(double));
            dtPoints.Columns.Add(Constants.COLUMN_Y, typeof(double));
            dtPoints.Columns.Add(Constants.COLUMN_Z, typeof(double));
            dtPoints.Columns.Add(Constants.COLUMN_ANGLE, typeof(double));

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
                    progress.Report(index++ * 100 / totalProgress);
            }

            return dtPoints;
        }

        private void ExportPointsToExcel(DataTable dtPoints, string fileName, ref int index, int totalProgress,
            CancellationToken cancellationToken, IProgress<int> progress = null)
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
                    progress.Report(index++ * 100 / totalProgress);
            }

            excelWorkBook.SaveAs(fileName);
            excelWorkBook.Close();
            excelApp.Quit();
        }
    }
}
