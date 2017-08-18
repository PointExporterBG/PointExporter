using System;
using System.Globalization;

namespace PE.Common.Utils
{
    public static class ParseUtils
    {
        public static double ParseDouble(string value)
        {
            string valueDots = value.Replace(',', '.');
            return double.Parse(valueDots, NumberStyles.Any, CultureInfo.InvariantCulture);
        }

        public static bool CheckFloat(object value, bool allowEmpty = false)
        {
            string strValue = value.ToString();
            double fValue;
            return (allowEmpty || (!allowEmpty && !string.IsNullOrEmpty(strValue)
                && double.TryParse(strValue, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out fValue)));
        }

        public static bool CheckFormula(object value)
        {
            string strValue = value.ToString();
            FormulaType formula;
            return Enum.TryParse(strValue, out formula);
        }
    }
}
