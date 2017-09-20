namespace PE.Entities.Default
{
	public class CompositePointFactory<TCompositePoint, TPoint> : ICompositePointFactory<TCompositePoint, TPoint>
		where TCompositePoint : ICompositePoint<TPoint>, new()
		where TPoint : IPoint, new()
	{
		public TCompositePoint Create(TPoint point, TPoint pointPlanar, 
            TPoint pointAbove, TPoint pointBelow, 
            TPoint pointAboveInner, TPoint pointBelowInner)
        {
            return new TCompositePoint()
            {
                Point = point,
                PlanarPoint = pointPlanar,
                AbovePoint = pointAbove,
                BelowPoint = pointBelow,
                AboveInnerPoint = pointAboveInner,
                BelowInnerPoint = pointBelowInner
            };
        }

    }
}
