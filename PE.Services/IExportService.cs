using PE.Common.ProgressInfo;
using PE.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PE.Services
{
    public interface IExportService<TCompositePoint, TPoint>
        where TCompositePoint : ICompositePoint<TPoint>, new()
        where TPoint : IPoint, new()
    {
        Task ExportToExcelAsync(IEnumerable<TCompositePoint> points, bool calculateOffsets, 
            bool calculatePlanar, bool calculateBearingDepth, string fileName,
            CancellationToken cancellationToken, IProgress<ExportInfo> progress = null);

        void ExportToExcel(IEnumerable<TCompositePoint> points, bool calculateOffsets, 
            bool calculatePlanar, bool calculateBearingDepth, string fileName,
            CancellationToken cancellationToken, IProgress<ExportInfo> progress = null);
    }
}
