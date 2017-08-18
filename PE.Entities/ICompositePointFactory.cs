namespace PE.Entities
{
	public interface ICompositePointFactory<TCompositePoint, TPoint>
		where TCompositePoint : ICompositePoint<TPoint>, new()
		where TPoint : IPoint
	{
		TCompositePoint Create(double x, double y, double z, double angle);

		TCompositePoint Create(double x, double y, double z, double angle,
			double xAbove, double yAbove, double zAbove, double angleAbove,
			double xBelow, double yBelow, double zBelow, double angleBelow);
	}
}
