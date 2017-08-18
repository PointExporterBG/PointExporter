using PE.Common;
using PE.Entities;
using PE.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PE.Services.Default
{
    public class CalculateService<TCompositePoint, TPoint, TSegment> : ICalculateService<TCompositePoint, TPoint, TSegment>
		where TCompositePoint : ICompositePoint<TPoint>, new()
		where TPoint : IPoint, new()
        where TSegment : ISegment, new()
    {
		private Dictionary<FormulaType, ICalculationStrategy<TCompositePoint, TPoint, TSegment>> formulas;
		private ICompositePointFactory<TCompositePoint, TPoint> compositePointFactory;
        private IResourceManager resourceManager;

        public CalculateService(ICompositePointFactory<TCompositePoint, TPoint> compositePointFactory, IResourceManager resourceManager)
		{
			this.compositePointFactory = compositePointFactory;
            this.resourceManager = resourceManager;

			formulas = new Dictionary<FormulaType, ICalculationStrategy<TCompositePoint, TPoint, TSegment>>();
			formulas.Add(FormulaType.Linear, new LinearCalculationStrategy<TCompositePoint, TPoint, TSegment>(compositePointFactory, resourceManager));
			formulas.Add(FormulaType.Cycloidal, new CycloidalCalculationStrategy<TCompositePoint, TPoint, TSegment>(compositePointFactory, resourceManager));
			formulas.Add(FormulaType.ConstantVelocity, new ConstantVelocityCalculationStrategy<TCompositePoint, TPoint, TSegment>(compositePointFactory, resourceManager));
		}

        public async Task<IEnumerable<TCompositePoint>> CalculatePointsAsync(double radius, double? bearingRadius, bool calculateOffsets,
            double offsetZ, Direction directionSign, IEnumerable<TSegment> segments,
            CancellationToken cancellationToken, IProgress<int> progress = null)
        {
            return await Task.Run(() => CalculatePoints(radius, bearingRadius, calculateOffsets, 
                    offsetZ, directionSign, segments, cancellationToken, progress),
                cancellationToken);
        }

        public IEnumerable<TCompositePoint> CalculatePoints(double radius, double? bearingRadius, bool calculateOffsets,
			double offsetZ, Direction directionSign, IEnumerable<TSegment> segments,
            CancellationToken cancellationToken, IProgress<int> progress = null)
		{
			ICollection<TCompositePoint> resultPoints = new List<TCompositePoint>();

            int index = 1;
            int totalProgress = segments.Count();

			foreach (TSegment segment in segments)
            {
                cancellationToken.ThrowIfCancellationRequested();

                double middle = Math.Abs(segment.EndAngle - segment.StartAngle) / 2;
				for (double i = 0; i <= Math.Abs(segment.EndAngle - segment.StartAngle); )
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    TCompositePoint point = formulas[segment.Formula].CalculatePoint(radius, bearingRadius,
						offsetZ, directionSign, calculateOffsets, middle, i, segment);

					resultPoints.Add(point);
					i += segment.Precision;
				}

                if (progress != null)
                    progress.Report(index++ * 100 / totalProgress);
			}

			return resultPoints;
		}
	}
}
