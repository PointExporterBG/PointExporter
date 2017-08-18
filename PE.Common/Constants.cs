using MetroFramework;
using System;
using System.Drawing;

namespace PE.Common
{
	public static class Constants
	{
        public const string APPLICATION_NAME = "PointExporter";
		public const string DEFAULT_FILE_NAME = "untitled";
		public const string DEFAULT_FILE_EXTENSION = "segments";
		public const string DEFAULT_TITLE_TEXT = "Point Exporter";
		public const string DEFAULT_START_HEIGHT = "2";
		public const string DEFAULT_END_HEIGHT = "5";
		public const string DEFAULT_START_ANGLE = "0";
		public const string DEFAULT_END_ANGLE = "90";
		public const string DEFAULT_PRECISION = "0.1";
		public const FormulaType DEFAULT_FORMULA = FormulaType.Cycloidal;
		public const int START_HEIGHT = 0;
		public const int END_HEIGHT = 1;
		public const int START_ANGLE = 2;
		public const int END_ANGLE = 3;
		public const int PRECISION = 4;
		public const int FORMULA = 5;
		public const string COLUMN_START_HEIGHT = "startHeight";
		public const string COLUMN_END_HEIGHT = "endHeight";
		public const string COLUMN_START_ANGLE = "startAngle";
		public const string COLUMN_END_ANGLE = "endAngle";
		public const string COLUMN_PRECISION = "precision";
		public const string COLUMN_FORMULA = "formula";
		public const string COLUMN_ANGLE = "angle";
		public const string COLUMN_X = "X";
		public const string COLUMN_Y = "Y";
		public const string COLUMN_Z = "Z";
		public const string TABLE_SEGMENTS = "Segments";
        public const int CHART_HORIZONTAL_OFFSETS = 70;
        public const int CHART_VERTICAL_OFFSETS = 19;
        public const int CHART_VERTICAL_LOCATION = 11;
        public const string CHART_AXIS_FORMAT = "0.##";
        public const int CHART_AXIS_LABELS_COUNT = 6;


        public static readonly double RADIAN = Math.PI / 180;
        public static readonly Color DEFAULT_COLOR = Color.Purple;
        public static readonly MetroColorStyle DEFAULT_METRO_COLOR = MetroColorStyle.Purple;
        public static readonly MetroThemeStyle DEFAULT_METRO_THEME = MetroThemeStyle.Default;
        public static readonly Color CHART_LINES_COLOR = Color.Gray;
    }
}
