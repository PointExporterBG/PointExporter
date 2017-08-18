using PE.Common;

namespace PE.Entities.Default
{
	public class SegmentFactory<TSegment> : ISegmentFactory<TSegment>
		where TSegment : ISegment, new()
	{
		public TSegment Create(double startHeight, double endHeight,
			double startAngle, double endAngle, double precision, FormulaType formula)
		{
			return new TSegment() 
			{
 				StartHeight = startHeight,
				EndHeight = endHeight,
				StartAngle = startAngle,
				EndAngle = endAngle,
				Precision = precision,
				Formula = formula
			};
		}
	}
}
