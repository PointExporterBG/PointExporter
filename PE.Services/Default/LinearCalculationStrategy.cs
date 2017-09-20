using PE.Common;
using PE.Entities;
using PE.Language;

namespace PE.Services.Default
{
    public class LinearCalculationStrategy<TCompositePoint, TPoint, TSegment>
        : BaseCalculationStrategy<TCompositePoint, TPoint, TSegment>, ICalculationStrategy<TCompositePoint, TPoint, TSegment>
        where TCompositePoint : ICompositePoint<TPoint>, new()
        where TPoint : IPoint, new()
        where TSegment : ISegment, new()
    {
        public LinearCalculationStrategy(ICompositePointFactory<TCompositePoint, TPoint> compositePointFactory,
            IPointFactory<TPoint> pointFactory, IResourceManager resourceManager)
            : base(compositePointFactory, pointFactory, resourceManager)
        {
        }

        protected override void Validate(TSegment segment, bool calculateOffsets, double? bearingRadius,
            bool calculateBearingDepth, double? bearingDepth)
        {
            ValidateBearingRadius(calculateOffsets, bearingRadius);
            ValidateBearingDepth(calculateBearingDepth, bearingDepth);
        }

        protected override TPoint CalculateCentral(TPoint pointPartial, TSegment segment,
            double radius, double offsetZ, double currentPosition, double middle)
        {
            double x = pointPartial.X * radius;
            double y = pointPartial.Y * radius;
            double z = segment.StartHeight + offsetZ;
            double angle = currentPosition + segment.StartAngle;

            return pointFactory.Create(x, y, z, angle);
        }

        protected override (TPoint pointAbove, TPoint pointBelow) CalculateAboveBelow(TPoint point, TSegment segment,
            double radius, double currentPosition, bool calculateOffsets, double? bearingRadius, double middle)
        {
            double zAbove = calculateOffsets && bearingRadius.HasValue ? point.Z + bearingRadius.Value : 0;
            double zBelow = calculateOffsets && bearingRadius.HasValue ? point.Z - bearingRadius.Value : 0;

            return (pointFactory.Create(point.X, point.Y, zAbove, point.Angle),
                    pointFactory.Create(point.X, point.Y, zBelow, point.Angle));
        }
    }
}
