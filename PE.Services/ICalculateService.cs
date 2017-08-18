using PE.Common;
using PE.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PE.Services
{
	public interface ICalculateService<TCompositePoint, TPoint, TSegment>
		where TCompositePoint : ICompositePoint<TPoint>, new()
		where TPoint : IPoint, new()
        where TSegment : ISegment, new()
	{
        Task<IEnumerable<TCompositePoint>> CalculatePointsAsync(double radius, double? bearingRadius, bool calculateOffsets,
            double offsetZ, Direction directionSign, IEnumerable<TSegment> segments,
            CancellationToken cancellationToken, IProgress<int> progress = null);

        IEnumerable<TCompositePoint> CalculatePoints(double radius, double? bearingRadius, bool calculateOffsets,
			   double offsetZ, Direction directionSign, IEnumerable<TSegment> segments,
               CancellationToken cancellationToken, IProgress<int> progress = null);
	}
}
