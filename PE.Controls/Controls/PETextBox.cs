using MetroFramework;
using MetroFramework.Controls;
using PE.Common;
using System.Windows.Forms;

namespace PE.Controls
{
    public class PETextBox : MetroTextBox, IStylable
    {
        public void SetStyle(MetroColorStyle style)
        {
            Style = style;
        }

        public void SetTheme(MetroThemeStyle theme)
        {
            Theme = theme;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            SetStyle(Constants.DEFAULT_METRO_COLOR);
            SetTheme(Constants.DEFAULT_METRO_THEME);

            base.OnPaint(e);
        }
    }
}
