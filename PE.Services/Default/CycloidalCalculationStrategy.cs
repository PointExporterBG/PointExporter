using PE.Common;
using PE.Common.Exceptions;
using PE.Entities;
using PE.Language;
using System;

namespace PE.Services.Default
{
    public class CycloidalCalculationStrategy<TCompositePoint, TPoint, TSegment>
        : BaseCalculationStrategy<TCompositePoint, TPoint>, ICalculationStrategy<TCompositePoint, TPoint, TSegment>
        where TCompositePoint : ICompositePoint<TPoint>, new()
        where TPoint : IPoint
        where TSegment : ISegment, new()
    {
        public CycloidalCalculationStrategy(ICompositePointFactory<TCompositePoint, TPoint> compositePointFactory, IResourceManager resourceManager)
            : base(compositePointFactory, resourceManager)
        {
        }

        public TCompositePoint CalculatePoint(double radius, double? bearingRadius,
            double offsetZ, Direction directionSign, bool calculateOffsets, double middle,
            double currentPosition, TSegment segment)
        {
            if (segment.EndAngle - segment.StartAngle == 0)
                throw new PEArgumentException(resourceManager, "end_angle_not_equal_start_angle");

            double prop = currentPosition / Math.Abs(segment.EndAngle - segment.StartAngle);
            double Hi = (segment.EndHeight - segment.StartHeight) * (prop - (1 / (2 * Math.PI)) * Math.Sin(2 * Math.PI * prop));

            double x = (int)directionSign * Math.Cos((currentPosition + segment.StartAngle) * Constants.RADIAN) * radius;
            double y = (int)directionSign * Math.Sin((currentPosition + segment.StartAngle) * Constants.RADIAN) * radius;
            double z = segment.StartHeight + Hi + offsetZ;
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
            double nextProp = nextPosition / Math.Abs(segment.EndAngle - segment.StartAngle);
            double nextHi = (segment.EndHeight - segment.StartHeight) * (nextProp - (1 / (2 * Math.PI)) * Math.Sin(2 * Math.PI * nextProp));
            double nextZ = segment.StartHeight + nextHi;

            double offsetAngle = (Math.PI * 2 * radius * segment.Precision) / 360;
            double BdivA = Math.Abs(Hi - nextHi) / offsetAngle;
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
