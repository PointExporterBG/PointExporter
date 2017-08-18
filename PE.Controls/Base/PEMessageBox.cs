using Language;
using MetroFramework;
using System.Windows.Forms;

namespace Controls.Base
{
    public static class PEMessageBox
    {
        public static void Show(IWin32Window owner, IResourceManager resourceManager, string message, string title)
        {
            MetroMessageBox.Show(owner, resourceManager.GetResource(message), resourceManager.GetResource(title));
        }
    }
}
