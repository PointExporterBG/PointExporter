using PE.Common;
using PE.Entities;

namespace PE.Services
{
	public interface ICalculationStrategy<TCompositePoint, TPoint, TSegment>
		where TCompositePoint : ICompositePoint<TPoint>
		where TPoint : IPoint
        where TSegment : ISegment, new()
    {
		TCompositePoint CalculatePoint(double radius, double? bearingRadius,
			double offsetZ, Direction directionSign, bool calculateOffsets, double middle,
			double currentPosition, TSegment segment);
	}
}
