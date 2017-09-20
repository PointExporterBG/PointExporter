namespace PE.Controls
{
    partial class Settings
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tbxOffsetZ = new PE.Controls.PETextBox();
            this.lblOffsetZ = new MetroFramework.Controls.MetroLabel();
            this.lblRadiusMM = new MetroFramework.Controls.MetroLabel();
            this.tbxRadius = new PE.Controls.PETextBox();
            this.lblRadius = new MetroFramework.Controls.MetroLabel();
            this.lblOffsetMM = new MetroFramework.Controls.MetroLabel();
            this.gbDirection = new System.Windows.Forms.GroupBox();
            this.rbCounterClockwise = new System.Windows.Forms.RadioButton();
            this.rbClockwise = new System.Windows.Forms.RadioButton();
            this.gbOffsets = new System.Windows.Forms.GroupBox();
            this.lblBearingMM = new MetroFramework.Controls.MetroLabel();
            this.lblBearingRadius = new MetroFramework.Controls.MetroLabel();
            this.chbCalculateOffsets = new PE.Controls.PECheckBox();
            this.chbCalculateBearingDepth = new PE.Controls.PECheckBox();
            this.lblBearingDepth = new MetroFramework.Controls.MetroLabel();
            this.lblBearingDepthMM = new MetroFramework.Controls.MetroLabel();
            this.tbxBearingRadius = new PE.Controls.PETextBox();
            this.tbxBearingDepth = new PE.Controls.PETextBox();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.chbPlanar = new PE.Controls.PECheckBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbDirection.SuspendLayout();
            this.gbOffsets.SuspendLayout();
            this.gbSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxOffsetZ
            // 
            // 
            // 
            // 
            this.tbxOffsetZ.CustomButton.Image = null;
            this.tbxOffsetZ.CustomButton.Location = new System.Drawing.Point(42, 2);
            this.tbxOffsetZ.CustomButton.Name = "";
            this.tbxOffsetZ.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.tbxOffsetZ.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbxOffsetZ.CustomButton.TabIndex = 1;
            this.tbxOffsetZ.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbxOffsetZ.CustomButton.UseSelectable = true;
            this.tbxOffsetZ.CustomButton.Visible = false;
            this.tbxOffsetZ.Lines = new string[] {
        "0"};
            this.tbxOffsetZ.Location = new System.Drawing.Point(125, 250);
            this.tbxOffsetZ.MaxLength = 32767;
            this.tbxOffsetZ.Name = "tbxOffsetZ";
            this.tbxOffsetZ.PasswordChar = '\0';
            this.tbxOffsetZ.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbxOffsetZ.SelectedText = "";
            this.tbxOffsetZ.SelectionLength = 0;
            this.tbxOffsetZ.SelectionStart = 0;
            this.tbxOffsetZ.ShortcutsEnabled = true;
            this.tbxOffsetZ.Size = new System.Drawing.Size(60, 20);
            this.tbxOffsetZ.Style = MetroFramework.MetroColorStyle.Purple;
            this.tbxOffsetZ.TabIndex = 35;
            this.tbxOffsetZ.Text = "0";
            this.tbxOffsetZ.UseSelectable = true;
            this.tbxOffsetZ.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbxOffsetZ.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblOffsetZ
            // 
            this.lblOffsetZ.AutoSize = true;
            this.lblOffsetZ.Location = new System.Drawing.Point(21, 250);
            this.lblOffsetZ.Name = "lblOffsetZ";
            this.lblOffsetZ.Size = new System.Drawing.Size(94, 19);
            this.lblOffsetZ.TabIndex = 34;
            this.lblOffsetZ.Text = "Move curves Z";
            // 
            // lblRadiusMM
            // 
            this.lblRadiusMM.AutoSize = true;
            this.lblRadiusMM.Location = new System.Drawing.Point(184, 22);
            this.lblRadiusMM.Name = "lblRadiusMM";
            this.lblRadiusMM.Size = new System.Drawing.Size(41, 19);
            this.lblRadiusMM.TabIndex = 30;
            this.lblRadiusMM.Text = "[mm]";
            // 
            // tbxRadius
            // 
            // 
            // 
            // 
            this.tbxRadius.CustomButton.Image = null;
            this.tbxRadius.CustomButton.Location = new System.Drawing.Point(42, 2);
            this.tbxRadius.CustomButton.Name = "";
            this.tbxRadius.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.tbxRadius.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbxRadius.CustomButton.TabIndex = 1;
            this.tbxRadius.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbxRadius.CustomButton.UseSelectable = true;
            this.tbxRadius.CustomButton.Visible = false;
            this.tbxRadius.Lines = new string[0];
            this.tbxRadius.Location = new System.Drawing.Point(125, 21);
            this.tbxRadius.MaxLength = 32767;
            this.tbxRadius.Name = "tbxRadius";
            this.tbxRadius.PasswordChar = '\0';
            this.tbxRadius.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbxRadius.SelectedText = "";
            this.tbxRadius.SelectionLength = 0;
            this.tbxRadius.SelectionStart = 0;
            this.tbxRadius.ShortcutsEnabled = true;
            this.tbxRadius.Size = new System.Drawing.Size(60, 20);
            this.tbxRadius.Style = MetroFramework.MetroColorStyle.Purple;
            this.tbxRadius.TabIndex = 29;
            this.tbxRadius.UseSelectable = true;
            this.tbxRadius.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbxRadius.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblRadius
            // 
            this.lblRadius.AutoSize = true;
            this.lblRadius.Location = new System.Drawing.Point(21, 22);
            this.lblRadius.Name = "lblRadius";
            this.lblRadius.Size = new System.Drawing.Size(47, 19);
            this.lblRadius.TabIndex = 28;
            this.lblRadius.Text = "Radius";
            // 
            // lblOffsetMM
            // 
            this.lblOffsetMM.AutoSize = true;
            this.lblOffsetMM.Location = new System.Drawing.Point(184, 250);
            this.lblOffsetMM.Name = "lblOffsetMM";
            this.lblOffsetMM.Size = new System.Drawing.Size(41, 19);
            this.lblOffsetMM.TabIndex = 36;
            this.lblOffsetMM.Text = "[mm]";
            // 
            // gbDirection
            // 
            this.gbDirection.BackColor = System.Drawing.SystemColors.Window;
            this.gbDirection.Controls.Add(this.rbCounterClockwise);
            this.gbDirection.Controls.Add(this.rbClockwise);
            this.gbDirection.Location = new System.Drawing.Point(7, 282);
            this.gbDirection.Name = "gbDirection";
            this.gbDirection.Size = new System.Drawing.Size(222, 48);
            this.gbDirection.TabIndex = 37;
            this.gbDirection.TabStop = false;
            this.gbDirection.Text = "Direction";
            // 
            // rbCounterClockwise
            // 
            this.rbCounterClockwise.AutoSize = true;
            this.rbCounterClockwise.Checked = true;
            this.rbCounterClockwise.Location = new System.Drawing.Point(24, 19);
            this.rbCounterClockwise.Name = "rbCounterClockwise";
            this.rbCounterClockwise.Size = new System.Drawing.Size(113, 17);
            this.rbCounterClockwise.TabIndex = 28;
            this.rbCounterClockwise.TabStop = true;
            this.rbCounterClockwise.Text = "Counter Clockwise";
            this.rbCounterClockwise.UseVisualStyleBackColor = true;
            // 
            // rbClockwise
            // 
            this.rbClockwise.AutoSize = true;
            this.rbClockwise.Location = new System.Drawing.Point(141, 19);
            this.rbClockwise.Name = "rbClockwise";
            this.rbClockwise.Size = new System.Drawing.Size(73, 17);
            this.rbClockwise.TabIndex = 27;
            this.rbClockwise.Text = "Clockwise";
            this.rbClockwise.UseVisualStyleBackColor = true;
            // 
            // gbOffsets
            // 
            this.gbOffsets.BackColor = System.Drawing.SystemColors.Window;
            this.gbOffsets.Controls.Add(this.lblBearingMM);
            this.gbOffsets.Controls.Add(this.lblBearingRadius);
            this.gbOffsets.Controls.Add(this.chbCalculateOffsets);
            this.gbOffsets.Controls.Add(this.chbCalculateBearingDepth);
            this.gbOffsets.Controls.Add(this.lblBearingDepth);
            this.gbOffsets.Controls.Add(this.lblBearingDepthMM);
            this.gbOffsets.Controls.Add(this.tbxBearingRadius);
            this.gbOffsets.Controls.Add(this.tbxBearingDepth);
            this.gbOffsets.Location = new System.Drawing.Point(7, 83);
            this.gbOffsets.Name = "gbOffsets";
            this.gbOffsets.Size = new System.Drawing.Size(222, 153);
            this.gbOffsets.TabIndex = 38;
            this.gbOffsets.TabStop = false;
            this.gbOffsets.Text = "Offset curves";
            // 
            // lblBearingMM
            // 
            this.lblBearingMM.AutoSize = true;
            this.lblBearingMM.Location = new System.Drawing.Point(177, 54);
            this.lblBearingMM.Name = "lblBearingMM";
            this.lblBearingMM.Size = new System.Drawing.Size(41, 19);
            this.lblBearingMM.TabIndex = 36;
            this.lblBearingMM.Text = "[mm]";
            this.lblBearingMM.Visible = false;
            // 
            // lblBearingRadius
            // 
            this.lblBearingRadius.AutoSize = true;
            this.lblBearingRadius.Location = new System.Drawing.Point(14, 54);
            this.lblBearingRadius.Name = "lblBearingRadius";
            this.lblBearingRadius.Size = new System.Drawing.Size(93, 19);
            this.lblBearingRadius.TabIndex = 34;
            this.lblBearingRadius.Text = "Bearing radius";
            this.lblBearingRadius.Visible = false;
            // 
            // chbCalculateOffsets
            // 
            this.chbCalculateOffsets.AutoSize = true;
            this.chbCalculateOffsets.Location = new System.Drawing.Point(14, 26);
            this.chbCalculateOffsets.Name = "chbCalculateOffsets";
            this.chbCalculateOffsets.Size = new System.Drawing.Size(142, 15);
            this.chbCalculateOffsets.Style = MetroFramework.MetroColorStyle.Purple;
            this.chbCalculateOffsets.TabIndex = 0;
            this.chbCalculateOffsets.Text = "Calculate offset curves";
            this.chbCalculateOffsets.UseSelectable = true;
            this.chbCalculateOffsets.CheckedChanged += new System.EventHandler(this.chbCalculateOffsets_CheckedChanged);
            // 
            // chbCalculateBearingDepth
            // 
            this.chbCalculateBearingDepth.AutoSize = true;
            this.chbCalculateBearingDepth.Location = new System.Drawing.Point(14, 90);
            this.chbCalculateBearingDepth.Name = "chbCalculateBearingDepth";
            this.chbCalculateBearingDepth.Size = new System.Drawing.Size(149, 15);
            this.chbCalculateBearingDepth.Style = MetroFramework.MetroColorStyle.Purple;
            this.chbCalculateBearingDepth.TabIndex = 0;
            this.chbCalculateBearingDepth.Text = "Calculate bearing depth";
            this.chbCalculateBearingDepth.UseSelectable = true;
            this.chbCalculateBearingDepth.Visible = false;
            this.chbCalculateBearingDepth.CheckedChanged += new System.EventHandler(this.chbCalculateBearingDepth_CheckedChanged);
            // 
            // lblBearingDepth
            // 
            this.lblBearingDepth.AutoSize = true;
            this.lblBearingDepth.Location = new System.Drawing.Point(14, 120);
            this.lblBearingDepth.Name = "lblBearingDepth";
            this.lblBearingDepth.Size = new System.Drawing.Size(92, 19);
            this.lblBearingDepth.TabIndex = 0;
            this.lblBearingDepth.Text = "Bearing depth";
            this.lblBearingDepth.Visible = false;
            // 
            // lblBearingDepthMM
            // 
            this.lblBearingDepthMM.AutoSize = true;
            this.lblBearingDepthMM.Location = new System.Drawing.Point(177, 120);
            this.lblBearingDepthMM.Name = "lblBearingDepthMM";
            this.lblBearingDepthMM.Size = new System.Drawing.Size(41, 19);
            this.lblBearingDepthMM.TabIndex = 0;
            this.lblBearingDepthMM.Text = "[mm]";
            this.lblBearingDepthMM.Visible = false;
            // 
            // tbxBearingRadius
            // 
            // 
            // 
            // 
            this.tbxBearingRadius.CustomButton.Image = null;
            this.tbxBearingRadius.CustomButton.Location = new System.Drawing.Point(40, 2);
            this.tbxBearingRadius.CustomButton.Name = "";
            this.tbxBearingRadius.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.tbxBearingRadius.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbxBearingRadius.CustomButton.TabIndex = 1;
            this.tbxBearingRadius.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbxBearingRadius.CustomButton.UseSelectable = true;
            this.tbxBearingRadius.CustomButton.Visible = false;
            this.tbxBearingRadius.Lines = new string[0];
            this.tbxBearingRadius.Location = new System.Drawing.Point(120, 54);
            this.tbxBearingRadius.MaxLength = 32767;
            this.tbxBearingRadius.Name = "tbxBearingRadius";
            this.tbxBearingRadius.PasswordChar = '\0';
            this.tbxBearingRadius.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbxBearingRadius.SelectedText = "";
            this.tbxBearingRadius.SelectionLength = 0;
            this.tbxBearingRadius.SelectionStart = 0;
            this.tbxBearingRadius.ShortcutsEnabled = true;
            this.tbxBearingRadius.Size = new System.Drawing.Size(58, 20);
            this.tbxBearingRadius.Style = MetroFramework.MetroColorStyle.Purple;
            this.tbxBearingRadius.TabIndex = 35;
            this.tbxBearingRadius.UseSelectable = true;
            this.tbxBearingRadius.Visible = false;
            this.tbxBearingRadius.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbxBearingRadius.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tbxBearingDepth
            // 
            // 
            // 
            // 
            this.tbxBearingDepth.CustomButton.Image = null;
            this.tbxBearingDepth.CustomButton.Location = new System.Drawing.Point(40, 2);
            this.tbxBearingDepth.CustomButton.Name = "";
            this.tbxBearingDepth.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.tbxBearingDepth.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbxBearingDepth.CustomButton.TabIndex = 1;
            this.tbxBearingDepth.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbxBearingDepth.CustomButton.UseSelectable = true;
            this.tbxBearingDepth.CustomButton.Visible = false;
            this.tbxBearingDepth.Lines = new string[0];
            this.tbxBearingDepth.Location = new System.Drawing.Point(120, 120);
            this.tbxBearingDepth.MaxLength = 32767;
            this.tbxBearingDepth.Name = "tbxBearingDepth";
            this.tbxBearingDepth.PasswordChar = '\0';
            this.tbxBearingDepth.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbxBearingDepth.SelectedText = "";
            this.tbxBearingDepth.SelectionLength = 0;
            this.tbxBearingDepth.SelectionStart = 0;
            this.tbxBearingDepth.ShortcutsEnabled = true;
            this.tbxBearingDepth.Size = new System.Drawing.Size(58, 20);
            this.tbxBearingDepth.Style = MetroFramework.MetroColorStyle.Purple;
            this.tbxBearingDepth.TabIndex = 0;
            this.tbxBearingDepth.UseSelectable = true;
            this.tbxBearingDepth.Visible = false;
            this.tbxBearingDepth.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbxBearingDepth.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // gbSettings
            // 
            this.gbSettings.BackColor = System.Drawing.SystemColors.Window;
            this.gbSettings.Controls.Add(this.gbOffsets);
            this.gbSettings.Controls.Add(this.lblRadius);
            this.gbSettings.Controls.Add(this.gbDirection);
            this.gbSettings.Controls.Add(this.tbxRadius);
            this.gbSettings.Controls.Add(this.lblOffsetMM);
            this.gbSettings.Controls.Add(this.lblRadiusMM);
            this.gbSettings.Controls.Add(this.tbxOffsetZ);
            this.gbSettings.Controls.Add(this.lblOffsetZ);
            this.gbSettings.Controls.Add(this.chbPlanar);
            this.gbSettings.Location = new System.Drawing.Point(0, 0);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(236, 335);
            this.gbSettings.TabIndex = 39;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // chbPlanar
            // 
            this.chbPlanar.AutoSize = true;
            this.chbPlanar.Location = new System.Drawing.Point(22, 55);
            this.chbPlanar.Name = "chbPlanar";
            this.chbPlanar.Size = new System.Drawing.Size(88, 15);
            this.chbPlanar.Style = MetroFramework.MetroColorStyle.Purple;
            this.chbPlanar.TabIndex = 0;
            this.chbPlanar.Text = "Planar curve";
            this.chbPlanar.UseSelectable = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbSettings);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(236, 335);
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.gbDirection.ResumeLayout(false);
            this.gbDirection.PerformLayout();
            this.gbOffsets.ResumeLayout(false);
            this.gbOffsets.PerformLayout();
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PE.Controls.PETextBox tbxOffsetZ;
        private MetroFramework.Controls.MetroLabel lblOffsetZ;
        private MetroFramework.Controls.MetroLabel lblRadiusMM;
        private PE.Controls.PETextBox tbxRadius;
        private MetroFramework.Controls.MetroLabel lblRadius;
        private MetroFramework.Controls.MetroLabel lblOffsetMM;
        private System.Windows.Forms.GroupBox gbDirection;
        private System.Windows.Forms.RadioButton rbCounterClockwise;
        private System.Windows.Forms.RadioButton rbClockwise;
        private System.Windows.Forms.GroupBox gbOffsets;
        private MetroFramework.Controls.MetroLabel lblBearingMM;
        private PE.Controls.PETextBox tbxBearingRadius;
        private MetroFramework.Controls.MetroLabel lblBearingRadius;
        private PE.Controls.PECheckBox chbCalculateOffsets;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private PE.Controls.PECheckBox chbPlanar;
        private PECheckBox chbCalculateBearingDepth;
        private PETextBox tbxBearingDepth;
        private MetroFramework.Controls.MetroLabel lblBearingDepth;
        private MetroFramework.Controls.MetroLabel lblBearingDepthMM;
    }
}
