using PE.Controls.Base;
using System.Threading;

namespace PE.Controls
{
    public partial class ProgressForm : BaseForm
    {
        public CancellationTokenSource CancellationTokenSource { get; set; }
        
        public ProgressForm()
        {
            InitializeComponent();

            SetResources();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            if (CancellationTokenSource != null)
                CancellationTokenSource.Cancel();
        }

        public override void SetResources()
        {
            Text = GetResource("progress");
            btnCancel.Text = GetResource("cancel");
        }
    }
}
