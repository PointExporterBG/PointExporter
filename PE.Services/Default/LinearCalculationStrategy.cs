using PE.Common;
using PE.Common.Exceptions;
using PE.Entities;
using PE.Language;
using System;

namespace PE.Services.Default
{
    public class LinearCalculationStrategy<TCompositePoint, TPoint, TSegment>
        : BaseCalculationStrategy<TCompositePoint, TPoint>, ICalculationStrategy<TCompositePoint, TPoint, TSegment>
        where TCompositePoint : ICompositePoint<TPoint>, new()
        where TPoint : IPoint
        where TSegment : ISegment, new()
    {
        public LinearCalculationStrategy(ICompositePointFactory<TCompositePoint, TPoint> compositePointFactory, IResourceManager resourceManager)
            : base(compositePointFactory, resourceManager)
        {
        }

        public TCompositePoint CalculatePoint(double radius, double? bearingRadius,
            double offsetZ, Direction directionSign, bool calculateOffsets, double middle,
            double currentPosition, TSegment segment)
        {
            double x = (int)directionSign * radius * Math.Cos((currentPosition + segment.StartAngle) * Constants.RADIAN);
            double y = (int)directionSign * radius * Math.Sin((currentPosition + segment.StartAngle) * Constants.RADIAN);
            double z = segment.StartHeight + offsetZ;
            double angle = currentPosition + segment.StartAngle;

            if (!calculateOffsets)
                return compositePointFactory.Create(x, y, z, angle);

            if (!bearingRadius.HasValue)
                throw new PEArgumentException(resourceManager, "bearing_radius_required_for_offset");

            return compositePointFactory.Create(
                x, y, z, angle,
                x, y, z + bearingRadius.Value, angle,
                x, y, z - bearingRadius.Value, angle);
        }
    }
}
