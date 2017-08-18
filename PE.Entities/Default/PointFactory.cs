namespace PE.Entities.Default
{
	public class PointFactory<TPoint> : IPointFactory<TPoint>
		where TPoint : IPoint, new()
	{
		public TPoint Create(double x, double y, double z, double angle)
		{
			return new TPoint()
			{
				X = x,
				Y = y,
				Z = z,
				Angle = angle
			};
		}
	}
}
