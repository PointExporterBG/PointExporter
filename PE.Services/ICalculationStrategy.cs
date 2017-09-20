using PE.Common;
using PE.Entities;

namespace PE.Services
{
    public interface ICalculationStrategy<TCompositePoint, TPoint, TSegment>
        where TCompositePoint : ICompositePoint<TPoint>
        where TPoint : IPoint
        where TSegment : ISegment, new()
    {
        TCompositePoint CalculatePoint(double radius, bool calculatePlanar,
            bool calculateOffsets, double? bearingRadius, bool calculateBearingDepth, double? bearingDepth,
            double offsetZ, Direction directionSign, double middle, double currentPosition, TSegment segment);
    }
}
