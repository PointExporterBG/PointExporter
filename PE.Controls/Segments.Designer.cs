using PE.Entities;

namespace PE.Controls
{
    partial class Segments<TCompositePoint, TPoint, TSegment>
        where TCompositePoint : ICompositePoint<TPoint>, new()
        where TPoint : IPoint, new()
        where TSegment : ISegment, new()
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbSegments = new System.Windows.Forms.GroupBox();
            this.btnExportSegments = new MetroFramework.Controls.MetroButton();
            this.btnImportSegments = new MetroFramework.Controls.MetroButton();
            this.btnClearSegments = new MetroFramework.Controls.MetroButton();
            this.dgvSegments = new MetroFramework.Controls.MetroGrid();
            this.startHeightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endHeightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startAngleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endAngleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formulaDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.segmentDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.segmentDataSet = new PE.Controls.SegmentDataSet();
            this.saveExportSegmentsDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.cmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiInsertRow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteRow = new System.Windows.Forms.ToolStripMenuItem();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbSegments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSegments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.segmentDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.segmentDataSet)).BeginInit();
            this.cmMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSegments
            // 
            this.gbSegments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSegments.BackColor = System.Drawing.SystemColors.Window;
            this.gbSegments.Controls.Add(this.btnExportSegments);
            this.gbSegments.Controls.Add(this.btnImportSegments);
            this.gbSegments.Controls.Add(this.btnClearSegments);
            this.gbSegments.Controls.Add(this.dgvSegments);
            this.gbSegments.Location = new System.Drawing.Point(0, 0);
            this.gbSegments.Name = "gbSegments";
            this.gbSegments.Size = new System.Drawing.Size(674, 279);
            this.gbSegments.TabIndex = 17;
            this.gbSegments.TabStop = false;
            this.gbSegments.Text = "Segments";
            // 
            // btnExportSegments
            // 
            this.btnExportSegments.Location = new System.Drawing.Point(268, 19);
            this.btnExportSegments.Name = "btnExportSegments";
            this.btnExportSegments.Size = new System.Drawing.Size(119, 30);
            this.btnExportSegments.TabIndex = 11;
            this.btnExportSegments.Text = "Save layout";
            this.btnExportSegments.UseSelectable = true;
            this.btnExportSegments.Click += new System.EventHandler(this.btnExportSegments_Click);
            // 
            // btnImportSegments
            // 
            this.btnImportSegments.Location = new System.Drawing.Point(142, 19);
            this.btnImportSegments.Name = "btnImportSegments";
            this.btnImportSegments.Size = new System.Drawing.Size(119, 30);
            this.btnImportSegments.TabIndex = 10;
            this.btnImportSegments.Text = "Open layout";
            this.btnImportSegments.UseSelectable = true;
            this.btnImportSegments.Click += new System.EventHandler(this.btnImportSegments_Click);
            // 
            // btnClearSegments
            // 
            this.btnClearSegments.Location = new System.Drawing.Point(16, 19);
            this.btnClearSegments.Name = "btnClearSegments";
            this.btnClearSegments.Size = new System.Drawing.Size(119, 30);
            this.btnClearSegments.TabIndex = 9;
            this.btnClearSegments.Text = "New layout";
            this.btnClearSegments.UseSelectable = true;
            this.btnClearSegments.Click += new System.EventHandler(this.btnClearSegments_Click);
            // 
            // dgvSegments
            // 
            this.dgvSegments.AllowUserToAddRows = false;
            this.dgvSegments.AllowUserToResizeRows = false;
            this.dgvSegments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSegments.AutoGenerateColumns = false;
            this.dgvSegments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSegments.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvSegments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSegments.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvSegments.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(65)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(73)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSegments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSegments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSegments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.startHeightDataGridViewTextBoxColumn,
            this.endHeightDataGridViewTextBoxColumn,
            this.startAngleDataGridViewTextBoxColumn,
            this.endAngleDataGridViewTextBoxColumn,
            this.precisionDataGridViewTextBoxColumn,
            this.formulaDataGridViewComboBoxColumn});
            this.dgvSegments.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvSegments.DataMember = "Segments";
            this.dgvSegments.DataSource = this.segmentDataSetBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(73)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSegments.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSegments.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSegments.EnableHeadersVisualStyles = false;
            this.dgvSegments.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvSegments.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvSegments.Location = new System.Drawing.Point(17, 57);
            this.dgvSegments.Name = "dgvSegments";
            this.dgvSegments.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(65)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(73)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSegments.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSegments.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSegments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSegments.Size = new System.Drawing.Size(640, 207);
            this.dgvSegments.Style = MetroFramework.MetroColorStyle.Purple;
            this.dgvSegments.TabIndex = 8;
            this.dgvSegments.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSegments_CellEndEdit);
            this.dgvSegments.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvSegments_CellValidating);
            this.dgvSegments.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvSegments_RowValidating);
            this.dgvSegments.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvSegments_MouseClick);
            // 
            // startHeightDataGridViewTextBoxColumn
            // 
            this.startHeightDataGridViewTextBoxColumn.DataPropertyName = "startHeight";
            this.startHeightDataGridViewTextBoxColumn.HeaderText = "Start Height [mm]";
            this.startHeightDataGridViewTextBoxColumn.Name = "startHeightDataGridViewTextBoxColumn";
            this.startHeightDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // endHeightDataGridViewTextBoxColumn
            // 
            this.endHeightDataGridViewTextBoxColumn.DataPropertyName = "endHeight";
            this.endHeightDataGridViewTextBoxColumn.HeaderText = "End Height [mm]";
            this.endHeightDataGridViewTextBoxColumn.Name = "endHeightDataGridViewTextBoxColumn";
            this.endHeightDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // startAngleDataGridViewTextBoxColumn
            // 
            this.startAngleDataGridViewTextBoxColumn.DataPropertyName = "startAngle";
            this.startAngleDataGridViewTextBoxColumn.HeaderText = "Start Angle [°]";
            this.startAngleDataGridViewTextBoxColumn.Name = "startAngleDataGridViewTextBoxColumn";
            this.startAngleDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // endAngleDataGridViewTextBoxColumn
            // 
            this.endAngleDataGridViewTextBoxColumn.DataPropertyName = "endAngle";
            this.endAngleDataGridViewTextBoxColumn.HeaderText = "End Angle [°]";
            this.endAngleDataGridViewTextBoxColumn.Name = "endAngleDataGridViewTextBoxColumn";
            this.endAngleDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // precisionDataGridViewTextBoxColumn
            // 
            this.precisionDataGridViewTextBoxColumn.DataPropertyName = "precision";
            this.precisionDataGridViewTextBoxColumn.HeaderText = "Precision";
            this.precisionDataGridViewTextBoxColumn.Name = "precisionDataGridViewTextBoxColumn";
            this.precisionDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // formulaDataGridViewComboBoxColumn
            // 
            this.formulaDataGridViewComboBoxColumn.DataPropertyName = "formula";
            this.formulaDataGridViewComboBoxColumn.HeaderText = "Formula";
            this.formulaDataGridViewComboBoxColumn.Name = "formulaDataGridViewComboBoxColumn";
            this.formulaDataGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // segmentDataSetBindingSource
            // 
            this.segmentDataSetBindingSource.DataSource = this.segmentDataSet;
            this.segmentDataSetBindingSource.Position = 0;
            // 
            // segmentDataSet
            // 
            this.segmentDataSet.DataSetName = "SegmentDataSet";
            this.segmentDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // saveExportSegmentsDialog
            // 
            this.saveExportSegmentsDialog.Filter = "Segments csv file (*.segments)|*.segments";
            this.saveExportSegmentsDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveExportSegmentsDialog_FileOk);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Segments csv file (*.segments)|*.segments";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // cmMenu
            // 
            this.cmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiInsertRow,
            this.tsmiDeleteRow});
            this.cmMenu.Name = "cmMenu";
            this.cmMenu.Size = new System.Drawing.Size(157, 48);
            this.cmMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmMenu_ItemClicked);
            // 
            // tsmiInsertRow
            // 
            this.tsmiInsertRow.Name = "tsmiInsertRow";
            this.tsmiInsertRow.Size = new System.Drawing.Size(156, 22);
            this.tsmiInsertRow.Text = "Insert segment";
            // 
            // tsmiDeleteRow
            // 
            this.tsmiDeleteRow.Name = "tsmiDeleteRow";
            this.tsmiDeleteRow.Size = new System.Drawing.Size(156, 22);
            this.tsmiDeleteRow.Text = "Delete segment";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // Segments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbSegments);
            this.Name = "Segments";
            this.Size = new System.Drawing.Size(674, 279);
            this.gbSegments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSegments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.segmentDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.segmentDataSet)).EndInit();
            this.cmMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSegments;
        private MetroFramework.Controls.MetroButton btnExportSegments;
        private MetroFramework.Controls.MetroButton btnImportSegments;
        private MetroFramework.Controls.MetroButton btnClearSegments;
        private MetroFramework.Controls.MetroGrid dgvSegments;
        private System.Windows.Forms.BindingSource segmentDataSetBindingSource;
        private SegmentDataSet segmentDataSet;
        private System.Windows.Forms.SaveFileDialog saveExportSegmentsDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ContextMenuStrip cmMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiInsertRow;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteRow;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DataGridViewTextBoxColumn startHeightDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endHeightDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startAngleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endAngleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn formulaDataGridViewComboBoxColumn;
    }
}
