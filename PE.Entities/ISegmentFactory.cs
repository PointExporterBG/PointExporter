using PE.Common;

namespace PE.Entities
{
	public interface ISegmentFactory<TSegment>
		where TSegment : ISegment, new()
	{
		TSegment Create(double startHeight, double endHeight, 
			double startAngle, double endAngle, double precision, FormulaType formula);
	}
}
