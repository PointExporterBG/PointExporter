namespace PE.Entities
{
	public interface IPointFactory<TPoint> 
		where TPoint : IPoint, new()
	{
		TPoint Create(double x, double y, double z, double angle);
	}
}
