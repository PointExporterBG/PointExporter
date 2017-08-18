using PE.Common;

namespace PE.Entities.Default
{
	public class Segment : ISegment
	{
		public double StartHeight { get; set; }
		public double EndHeight { get; set; }
		public double StartAngle { get; set; }
		public double EndAngle { get; set; }
		public double Precision { get; set; }
		public FormulaType Formula { get; set; }
	}
}
