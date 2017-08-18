namespace PE.Entities
{
	public interface ICompositePoint<TPoint>
		where TPoint : IPoint
	{
		TPoint Point { get; set; }
		TPoint AbovePoint { get; set; }
		TPoint BelowPoint { get; set; }
	}
}
