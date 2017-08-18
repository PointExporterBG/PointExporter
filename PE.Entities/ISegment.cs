using PE.Common;

namespace PE.Entities
{
	public interface ISegment
	{
		double StartHeight { get; set; }
		double EndHeight { get; set; }
		double StartAngle { get; set; }
		double EndAngle { get; set; }
		double Precision { get; set; }
		FormulaType Formula { get; set; }
	}
}
