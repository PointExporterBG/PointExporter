using PE.Common;
using PE.Common.Utils;
using PE.Controls.Base;

namespace PE.Controls
{
    public partial class Settings : BaseUserControl
    {
        #region Properties

        public double Radius
        {
            get
            {
                return ParseUtils.ParseDouble(tbxRadius.Text);
            }
        }

        public bool CalculatePlanar
        {
            get
            {
                return chbPlanar.Checked;
            }
        }

        public bool CalculateOffsets
        {
            get
            {
                return chbCalculateOffsets.Checked;
            }
        }

        public double? BearingRadius
        {
            get
            {
                return CalculateOffsets
                    ? ParseUtils.ParseDouble(tbxBearingRadius.Text)
                    : (double?)null;
            }
        }

        public bool CalculateBearingDepth
        {
            get
            {
                return chbCalculateBearingDepth.Checked;
            }
        }

        public double? BearingDepth
        {
            get
            {
                return CalculateBearingDepth
                    ? ParseUtils.ParseDouble(tbxBearingDepth.Text)
                    : (double?)null;
            }
        }

        public double OffsetZ
        {
            get
            {
                return ParseUtils.ParseDouble(tbxOffsetZ.Text);
            }
        }

        public Direction DirectionSign
        {
            get
            {
                return rbCounterClockwise.Checked
                    ? Direction.CounterClockwise
                    : Direction.Clockwise;
            }
        }

        #endregion

        public Settings()
        {
            InitializeComponent();
        }

        private void chbCalculateOffsets_CheckedChanged(object sender, System.EventArgs e)
        {
            lblBearingRadius.Visible = chbCalculateOffsets.Checked;
            tbxBearingRadius.Visible = chbCalculateOffsets.Checked;
            lblBearingMM.Visible = chbCalculateOffsets.Checked;
            chbCalculateBearingDepth.Visible = chbCalculateOffsets.Checked;

            ManageBearingDepthVisibility(chbCalculateOffsets.Checked && chbCalculateBearingDepth.Checked);
        }

        private void chbCalculateBearingDepth_CheckedChanged(object sender, System.EventArgs e)
        {
            ManageBearingDepthVisibility(chbCalculateBearingDepth.Checked);
        }

        private void ManageBearingDepthVisibility(bool visible)
        {
            lblBearingDepth.Visible = visible;
            tbxBearingDepth.Visible = visible;
            lblBearingDepthMM.Visible = visible;
        }

        public new bool Validate()
        {
            errorProvider.Clear();

            if (!ValidateRadius())
                return false;

            if (!ValidateOffsetZ())
                return false;

            if (CalculateOffsets)
            {
                if (!ValidateBearingRadius())
                    return false;

                if (CalculateBearingDepth)
                    if (!ValidateBearingDepth())
                        return false;
            }

            return true;
        }

        public override void SetResources()
        {
            gbSettings.Text = GetResource("settings");
            gbOffsets.Text = GetResource("offset_curves");
            gbDirection.Text = GetResource("direction");
            lblRadius.Text = GetResource("radius");
            lblRadiusMM.Text = GetResource("mm");
            lblBearingRadius.Text = GetResource("bearing_radius");
            lblBearingMM.Text = GetResource("mm");
            chbCalculateBearingDepth.Text = GetResource("calculate_bearing_depth");
            lblBearingDepth.Text = GetResource("bearing_depth");
            lblBearingDepthMM.Text = GetResource("mm");
            lblOffsetZ.Text = GetResource("offset_z");
            lblOffsetMM.Text = GetResource("mm");
            chbCalculateOffsets.Text = GetResource("calculate_offsets");
            chbPlanar.Text = GetResource("planar_curve");
            rbCounterClockwise.Text = GetResource("counter_clockwise");
            rbClockwise.Text = GetResource("clockwise");
        }

        private bool ValidateRadius()
        {
            if (string.IsNullOrWhiteSpace(tbxRadius.Text))
            {
                errorProvider.SetError(tbxRadius, GetResource("enter_radius"));
                return false;
            }

            double valueRadius;
            if (!double.TryParse(tbxRadius.Text, out valueRadius))
            {
                errorProvider.SetError(tbxRadius, GetResource("enter_number_for_radius"));
                return false;
            }

            return true;
        }

        private bool ValidateBearingRadius()
        {
            if (string.IsNullOrWhiteSpace(tbxBearingRadius.Text))
            {
                errorProvider.SetError(tbxBearingRadius, GetResource("enter_bearing_radius"));
                return false;
            }

            double valueBearingRadius;
            if (!double.TryParse(tbxBearingRadius.Text, out valueBearingRadius))
            {
                errorProvider.SetError(tbxBearingRadius, GetResource("enter_number_for_bearing_radius"));
                return false;
            }

            return true;
        }

        private bool ValidateBearingDepth()
        {
            if (string.IsNullOrWhiteSpace(tbxBearingDepth.Text))
            {
                errorProvider.SetError(tbxBearingDepth, GetResource("enter_bearing_depth"));
                return false;
            }

            double valueBearingDepth;
            if (!double.TryParse(tbxBearingDepth.Text, out valueBearingDepth))
            {
                errorProvider.SetError(tbxBearingDepth, GetResource("enter_number_for_bearing_depth"));
                return false;
            }

            return true;
        }

        private bool ValidateOffsetZ()
        {
            double valueOffsetZ;
            if (!double.TryParse(tbxOffsetZ.Text, out valueOffsetZ))
            {
                errorProvider.SetError(tbxOffsetZ, GetResource("enter_number_for_offset_z"));
                return false;
            }

            return true;
        }
    }
}
