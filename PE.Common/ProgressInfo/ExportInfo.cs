namespace PE.Common.ProgressInfo
{
    public class ExportInfo
    {
        public int Percent { get; private set; }
        public string InfoText { get; private set; }

        public ExportInfo(int percent, string infoText)
        {
            Percent = percent;
            InfoText = infoText;
        }
    }
}
