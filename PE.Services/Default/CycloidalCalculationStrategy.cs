using PE.Common;
using PE.Entities;
using PE.Language;
using System;

namespace PE.Services.Default
{
    public class CycloidalCalculationStrategy<TCompositePoint, TPoint, TSegment>
        : BaseCalculationStrategy<TCompositePoint, TPoint, TSegment>, ICalculationStrategy<TCompositePoint, TPoint, TSegment>
        where TCompositePoint : ICompositePoint<TPoint>, new()
        where TPoint : IPoint, new()
        where TSegment : ISegment, new()
    {
        public CycloidalCalculationStrategy(ICompositePointFactory<TCompositePoint, TPoint> compositePointFactory,
            IPointFactory<TPoint> pointFactory, IResourceManager resourceManager)
            : base(compositePointFactory, pointFactory, resourceManager)
        {
        }

        protected override TPoint CalculateCentral(TPoint pointPartial, TSegment segment,
            double radius, double offsetZ, double currentPosition, double middle)
        {
            double Hi = CalculateHeight(segment, currentPosition);

            double x = pointPartial.X * radius;
            double y = pointPartial.Y * radius;
            double z = segment.StartHeight + Hi + offsetZ;
            double angle = currentPosition + segment.StartAngle;

            return pointFactory.Create(x, y, z, angle);
        }

        protected override double CalculateHeight(TSegment segment, double currentPosition, double middle = 0)
        {
            double prop = currentPosition / Math.Abs(segment.EndAngle - segment.StartAngle);
            return (segment.EndHeight - segment.StartHeight) * (prop - (1 / (2 * Math.PI)) * Math.Sin(2 * Math.PI * prop));
        }

        protected override (TPoint pointAbove, TPoint pointBelow) CalculateAboveBelow(TPoint point, TSegment segment,
            double radius, double currentPosition, bool calculateOffsets, double? bearingRadius, double middle)
        {
            double zAbove;
            double zBelow;

            double Hi = CalculateHeight(segment, currentPosition);

            if (currentPosition == Math.Abs(segment.EndAngle - segment.StartAngle))
            {
                zAbove = point.Z + bearingRadius.Value;
                zBelow = point.Z + bearingRadius.Value;
            }
            else
            {
                double nextPosition = currentPosition + segment.Precision;
                double nextProp = nextPosition / Math.Abs(segment.EndAngle - segment.StartAngle);
                double nextHi = (segment.EndHeight - segment.StartHeight) * (nextProp - (1 / (2 * Math.PI)) * Math.Sin(2 * Math.PI * nextProp));
                double nextZ = segment.StartHeight + nextHi;

                double offsetAngle = (Math.PI * 2 * radius * segment.Precision) / 360;
                double BdivA = Math.Abs(Hi - nextHi) / offsetAngle;
                double arctangBdivA = Math.Atan(BdivA);
                double diffTemp = Math.Sin((90 - (arctangBdivA * 180) / Math.PI) * Constants.RADIAN) * bearingRadius.Value;
                double diff = bearingRadius.Value / Math.Cos(Math.Acos(diffTemp / bearingRadius.Value));

                zAbove = point.Z + diff;
                zBelow = point.Z - diff;
            }

            return (pointFactory.Create(point.X, point.Y, zAbove, point.Angle),
                    pointFactory.Create(point.X, point.Y, zBelow, point.Angle));
        }
    }
}
