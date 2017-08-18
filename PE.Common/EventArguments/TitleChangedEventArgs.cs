using System;

namespace PE.Common.EventArguments
{
    public class TitleChangedEventArgs : EventArgs
    {
        public string TitleText { get; private set; }

        public TitleChangedEventArgs(string titleText)
        {
            TitleText = titleText;
        }
    }
}
