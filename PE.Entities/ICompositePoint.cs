namespace PE.Entities
{
	public interface ICompositePoint<TPoint>
		where TPoint : IPoint
	{
		TPoint Point { get; set; }
        TPoint PlanarPoint { get; set; }
		TPoint AbovePoint { get; set; }
		TPoint BelowPoint { get; set; }
        TPoint AboveInnerPoint { get; set; }
        TPoint BelowInnerPoint { get; set; }
    }
}
