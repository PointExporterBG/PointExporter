using PE.Common;
using PE.Common.Exceptions;
using PE.Entities;
using PE.Language;
using System;

namespace PE.Services.Default
{
    public class ConstantVelocityCalculationStrategy<TCompositePoint, TPoint, TSegment>
        : BaseCalculationStrategy<TCompositePoint, TPoint>, ICalculationStrategy<TCompositePoint, TPoint, TSegment>
        where TCompositePoint : ICompositePoint<TPoint>, new()
        where TPoint : IPoint
        where TSegment : ISegment, new()
    {
        public ConstantVelocityCalculationStrategy(ICompositePointFactory<TCompositePoint, TPoint> compositePointFactory, IResourceManager resourceManager)
            : base(compositePointFactory, resourceManager)
        {
        }

        public TCompositePoint CalculatePoint(double radius, double? bearingRadius,
            double offsetZ, Direction directionSign, bool calculateOffsets, double middle,
            double currentPosition, TSegment segment)
        {
            if (segment.EndAngle - segment.StartAngle == 0)
                throw new PEArgumentException(resourceManager, "end_angle_not_equal_start_angle");

            double height = currentPosition <= middle
                                        ? 2 * Math.Abs(segment.EndHeight - segment.StartHeight)
                                            * Math.Pow(currentPosition / Math.Abs(segment.EndAngle - segment.StartAngle), 2)
                                        : Math.Abs(segment.EndHeight - segment.StartHeight)
                                            - 2 * Math.Abs(segment.EndHeight - segment.StartHeight)
                                            * Math.Pow(1 - (currentPosition / Math.Abs(segment.EndAngle - segment.StartAngle)), 2);
            if (segment.StartHeight > segment.EndHeight)
                height = -height;

            double x = (int)directionSign * Math.Cos((currentPosition + segment.StartAngle) * Constants.RADIAN) * radius;
            double y = (int)directionSign * Math.Sin((currentPosition + segment.StartAngle) * Constants.RADIAN) * radius;
            double z = segment.StartHeight + height + offsetZ;
            double angle = currentPosition + segment.StartAngle;

            if (!calculateOffsets)
                return compositePointFactory.Create(x, y, z, angle);

            if (!bearingRadius.HasValue)
                throw new PEArgumentException(resourceManager, "bearing_radius_required_for_offset");

            if (bearingRadius.Value == 0)
                throw new PEArgumentException(resourceManager, "bearing_radius_0");

            if (currentPosition == Math.Abs(segment.EndAngle - segment.StartAngle))
                return compositePointFactory.Create(
                    x, y, z, angle,
                    x, y, z + bearingRadius.Value, angle,
                    x, y, z + bearingRadius.Value, angle);

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

            return compositePointFactory.Create(
                x, y, z, angle,
                x, y, z + diff, angle,
                x, y, z - diff, angle);
        }
    }
}
