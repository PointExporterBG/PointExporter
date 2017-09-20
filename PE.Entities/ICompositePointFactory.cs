namespace PE.Entities
{
	public interface ICompositePointFactory<TCompositePoint, TPoint>
		where TCompositePoint : ICompositePoint<TPoint>, new()
		where TPoint : IPoint
	{
		TCompositePoint Create(TPoint point, TPoint pointPlanar,
            TPoint pointAbove, TPoint pointBelow,
            TPoint pointAboveInner, TPoint pointBelowInner);
	}
}
