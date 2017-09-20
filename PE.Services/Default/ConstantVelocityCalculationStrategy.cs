using PE.Common;
using PE.Entities;
using PE.Language;
using System;

namespace PE.Services.Default
{
    public class ConstantVelocityCalculationStrategy<TCompositePoint, TPoint, TSegment>
        : BaseCalculationStrategy<TCompositePoint, TPoint, TSegment>, ICalculationStrategy<TCompositePoint, TPoint, TSegment>
        where TCompositePoint : ICompositePoint<TPoint>, new()
        where TPoint : IPoint, new()
        where TSegment : ISegment, new()
    {
        public ConstantVelocityCalculationStrategy(ICompositePointFactory<TCompositePoint, TPoint> compositePointFactory,
            IPointFactory<TPoint> pointFactory, IResourceManager resourceManager)
            : base(compositePointFactory, pointFactory, resourceManager)
        {
        } 

        protected override TPoint CalculateCentral(TPoint pointPartial, TSegment segment,
            double radius, double offsetZ, double currentPosition, double middle)
        {
            double height = CalculateHeight(segment, currentPosition, middle);

            double x = pointPartial.X * radius;
            double y = pointPartial.Y * radius;
            double z = segment.StartHeight + height + offsetZ;
            double angle = currentPosition + segment.StartAngle;

            return pointFactory.Create(x, y, z, angle);
        }

        protected override double CalculateHeight(TSegment segment, double currentPosition, double middle = 0)
        {
            double height = currentPosition <= middle
                                          ? 2 * Math.Abs(segment.EndHeight - segment.StartHeight)
                                              * Math.Pow(currentPosition / Math.Abs(segment.EndAngle - segment.StartAngle), 2)
                                          : Math.Abs(segment.EndHeight - segment.StartHeight)
                                              - 2 * Math.Abs(segment.EndHeight - segment.StartHeight)
                                              * Math.Pow(1 - (currentPosition / Math.Abs(segment.EndAngle - segment.StartAngle)), 2);
            if (segment.StartHeight > segment.EndHeight)
                height = -height;

            return height;
        }

        protected override (TPoint pointAbove, TPoint pointBelow) CalculateAboveBelow(TPoint point, TSegment segment,
           double radius, double currentPosition, bool calculateOffsets, double? bearingRadius, double middle)
        {
            double zAbove;
            double zBelow;

            double height = CalculateHeight(segment, currentPosition, middle);

            if (currentPosition == Math.Abs(segment.EndAngle - segment.StartAngle))
            {
                zAbove = point.Z + bearingRadius.Value;
                zBelow = point.Z + bearingRadius.Value;
            }
            else
            {
                double nextPosition = currentPosition + segment.Precision;
                double nextHeight = nextPosition <= middle
                    ? 2 * Math.Abs(segment.EndHeight - segment.StartHeight)
                        * Math.Pow(nextPosition / Math.Abs(segment.EndAngle - segment.StartAngle), 2)
                    : Math.Abs(segment.EndHeight - segment.StartHeight)
                        - 2 * Math.Abs(segment.EndHeight - segment.StartHeight)
                        * Math.Pow(1 - (nextPosition / Math.Abs(segment.EndAngle - segment.StartAngle)), 2);
                if (segment.StartHeight > segment.EndHeight)
                    nextHeight = -nextHeight;
                double nextZ = segment.StartHeight + nextHeight;

                double offsetAngle = calculateOffsets ? (Math.PI * 2 * radius * segment.Precision) / 360 : 0;
                double BdivA = Math.Abs(height - nextHeight) / offsetAngle;
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
