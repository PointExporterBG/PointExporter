namespace PE.Entities.Default
{
	public class CompositePoint<TPoint> : ICompositePoint<TPoint>
		where TPoint : IPoint
	{
		public TPoint Point { get; set; }
		public TPoint AbovePoint { get; set; }
		public TPoint BelowPoint { get; set; }
	}
}
