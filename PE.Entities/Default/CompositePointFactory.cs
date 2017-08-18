namespace PE.Entities.Default
{
	public class CompositePointFactory<TCompositePoint, TPoint> : ICompositePointFactory<TCompositePoint, TPoint>
		where TCompositePoint : ICompositePoint<TPoint>, new()
		where TPoint : IPoint, new()
	{
		private IPointFactory<TPoint> pointFactory;

		public CompositePointFactory(IPointFactory<TPoint> pointFactory)
		{
			this.pointFactory = pointFactory;
		}

		public TCompositePoint Create(double x, double y, double z, double angle)
		{
			return new TCompositePoint()
			{
				Point = pointFactory.Create(x, y, z, angle)
			};
		}

		public TCompositePoint Create(double x, double y, double z, double angle,
			double xAbove, double yAbove, double zAbove, double angleAbove,
			double xBelow, double yBelow, double zBelow, double angleBelow)
		{
			return new TCompositePoint()
			{
				Point = pointFactory.Create(x, y, z, angle),
				AbovePoint = pointFactory.Create(xAbove, yAbove, zAbove, angleAbove),
				BelowPoint = pointFactory.Create(xBelow, yBelow, zBelow, angleBelow)
			};
		}
	}
}
