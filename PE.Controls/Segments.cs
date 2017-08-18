using PE.Common;
using PE.Common.EventArguments;
using PE.Common.Utils;
using PE.Controls.Base;
using PE.Entities;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PE.Controls
{
    public partial class Segments<TCompositePoint, TPoint, TSegment> : BaseUserControl
        where TCompositePoint : ICompositePoint<TPoint>, new()
        where TPoint : IPoint, new()
        where TSegment : ISegment, new()
    {
        #region Properties

        public DataGridViewRowCollection SegmentRows
        {
            get
            {
                return dgvSegments.Rows;
            }
        }

        public bool CalculateOffsets { get; set; }

        public IEnumerable<TCompositePoint> ResultPoints { get; set; }

        private string DefaultFileNameExtension
        {
            get
            {
                return string.Format("{0}.{1}", Constants.DEFAULT_FILE_NAME, Constants.DEFAULT_FILE_EXTENSION);
            }
        }

        private string titleText;
        public string TitleText
        {
            get { return titleText; }
            set
            {
                titleText = value;
                if (TitleChanged != null)
                    TitleChanged(this, new TitleChangedEventArgs(titleText));
            }
        }

        #endregion

        public delegate void TitleChangedEventHandler(object sender, TitleChangedEventArgs args);
        public event TitleChangedEventHandler TitleChanged;

        public event EventHandler Cleaned;

        private string FileName;
        private bool isFileChanged = false;

        public Segments()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            TitleText = Constants.DEFAULT_TITLE_TEXT;
            base.OnLoad(e);
        }

        private void btnClearSegments_Click(object sender, System.EventArgs e)
        {
            bool promptToSave = PromptToSave();
            if (!promptToSave)
                return;

            ClearSegments();

            SetInfo(DefaultFileNameExtension);
        }

        private void btnImportSegments_Click(object sender, System.EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void btnExportSegments_Click(object sender, System.EventArgs e)
        {
            saveExportSegmentsDialog.FileName = FileName;
            saveExportSegmentsDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool promptToSave = PromptToSave();
            if (!promptToSave)
                return;

            ClearSegments();

            SetInfo(openFileDialog.FileName);

            ParseSegments();
        }

        private void saveExportSegmentsDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveSegmentsToFile(saveExportSegmentsDialog.FileName);
            FileName = saveExportSegmentsDialog.FileName;
            TitleText = string.Format("{0} - {1}", Constants.DEFAULT_TITLE_TEXT, FileName);
        }

        private void dgvSegments_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvSegments.Rows[e.RowIndex].ErrorText = string.Empty;
            if (e.ColumnIndex == Constants.START_HEIGHT && e.RowIndex > 0)
            {
                dgvSegments.Rows[e.RowIndex - 1].Cells[Constants.END_HEIGHT].Value =
                    dgvSegments.Rows[e.RowIndex].Cells[Constants.START_HEIGHT].Value;
            }
            else if (e.ColumnIndex == Constants.END_HEIGHT && e.RowIndex < dgvSegments.Rows.Count - 1)
            {
                dgvSegments.Rows[e.RowIndex + 1].Cells[Constants.START_HEIGHT].Value =
                    dgvSegments.Rows[e.RowIndex].Cells[Constants.END_HEIGHT].Value;
            }
            else if (e.ColumnIndex == Constants.START_ANGLE && e.RowIndex > 0)
            {
                dgvSegments.Rows[e.RowIndex - 1].Cells[Constants.END_ANGLE].Value =
                    dgvSegments.Rows[e.RowIndex].Cells[Constants.START_ANGLE].Value;
                //if (ParseDouble(dgvSegments.Rows[e.RowIndex - 1].Cells[3].Value.ToString()) 
                //    < ParseDouble(dgvSegments.Rows[e.RowIndex - 1].Cells[2].Value.ToString()))
                //    dgvSegments.Rows[e.RowIndex - 1].Cells[3].Value = dgvSegments.Rows[e.RowIndex].Cells[2].Value;
                //if (ParseDouble(dgvSegments.Rows[e.RowIndex].Cells[3].Value.ToString())
                //    < ParseDouble(dgvSegments.Rows[e.RowIndex].Cells[2].Value.ToString()))
                //    dgvSegments.Rows[e.RowIndex].Cells[3].Value = dgvSegments.Rows[e.RowIndex].Cells[2].Value;
            }
            else if (e.ColumnIndex == Constants.END_ANGLE && e.RowIndex < dgvSegments.Rows.Count - 1)
            {
                dgvSegments.Rows[e.RowIndex + 1].Cells[Constants.START_ANGLE].Value =
                    dgvSegments.Rows[e.RowIndex].Cells[Constants.END_ANGLE].Value;
                //if (ParseDouble(dgvSegments.Rows[e.RowIndex + 1].Cells[2].Value.ToString())
                //    > ParseDouble(dgvSegments.Rows[e.RowIndex + 1].Cells[3].Value.ToString()))
                //    dgvSegments.Rows[e.RowIndex + 1].Cells[2].Value = dgvSegments.Rows[e.RowIndex].Cells[3].Value;
                //if (ParseDouble(dgvSegments.Rows[e.RowIndex].Cells[2].Value.ToString())
                //    > ParseDouble(dgvSegments.Rows[e.RowIndex].Cells[3].Value.ToString()))
                //    dgvSegments.Rows[e.RowIndex].Cells[2].Value = dgvSegments.Rows[e.RowIndex].Cells[3].Value;
            }
            else if (e.ColumnIndex == Constants.FORMULA
                && dgvSegments.Rows[e.RowIndex].Cells[Constants.FORMULA].Value.ToString() == FormulaType.Linear.ToString())
            {
                dgvSegments.Rows[e.RowIndex].Cells[Constants.END_HEIGHT].Value =
                    dgvSegments.Rows[e.RowIndex].Cells[Constants.START_HEIGHT].Value;
            }

            isFileChanged = true;
        }

        private void dgvSegments_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == Constants.START_HEIGHT
                || e.ColumnIndex == Constants.END_HEIGHT
                || e.ColumnIndex == Constants.START_ANGLE
                || e.ColumnIndex == Constants.END_ANGLE
                || e.ColumnIndex == Constants.PRECISION)
            {
                if (!ParseUtils.CheckFloat(e.FormattedValue.ToString()))
                {
                    dgvSegments.Rows[e.RowIndex].ErrorText =
                        GetResource("must_be_double", dgvSegments.Columns[e.ColumnIndex].HeaderText);
                    e.Cancel = true;
                }
            }
            else if (e.ColumnIndex == Constants.FORMULA)
            {
                if (string.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
                {
                    dgvSegments.Rows[e.RowIndex].ErrorText = GetResource("select_formula");
                    e.Cancel = true;
                }
            }
        }

        private void dgvSegments_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                cmMenu.Show(dgvSegments, new System.Drawing.Point(e.X, e.Y));

            if (dgvSegments.CurrentCell != null)
            {
                dgvSegments.BeginEdit(true);

                var hti = dgvSegments.HitTest(e.X, e.Y);
                dgvSegments.ClearSelection();
                if (hti.RowIndex >= 0)
                    dgvSegments.Rows[hti.RowIndex].Selected = true;
            }
        }

        private void dgvSegments_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow row = dgvSegments.Rows[e.RowIndex];
            e.Cancel = !CheckRowValues(row);
            if (e.Cancel)
                dgvSegments.Rows[e.RowIndex].ErrorText = GetResource("enter_all_values");
        }

        private void cmMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Int32 rowIndex = dgvSegments.Rows.Count;
            if (e.ClickedItem == tsmiInsertRow)
            {
                DataRow dr = segmentDataSet.Tables[Constants.TABLE_SEGMENTS].NewRow();
                if (rowIndex == 0)
                {
                    InitDefaultRow(dr);
                }
                else
                {
                    DataRow prevRow = segmentDataSet.Tables[Constants.TABLE_SEGMENTS].Rows[rowIndex - 1];
                    InitFromRow(dr, prevRow);
                }

                segmentDataSet.Tables[Constants.TABLE_SEGMENTS].Rows.InsertAt(dr, rowIndex);
            }
            else if (e.ClickedItem == tsmiDeleteRow)
            {
                segmentDataSet.Tables[Constants.TABLE_SEGMENTS].Rows.RemoveAt(rowIndex - 1);
            }

            dgvSegments.ClearSelection();
            isFileChanged = true;
        }

        private void InitDefaultRow(DataRow row)
        {
            row[Constants.COLUMN_START_HEIGHT] = Constants.DEFAULT_START_HEIGHT;
            row[Constants.COLUMN_END_HEIGHT] = Constants.DEFAULT_END_HEIGHT;
            row[Constants.COLUMN_START_ANGLE] = Constants.DEFAULT_START_ANGLE;
            row[Constants.COLUMN_END_ANGLE] = Constants.DEFAULT_END_ANGLE;
            row[Constants.COLUMN_PRECISION] = Constants.DEFAULT_PRECISION;
            row[Constants.COLUMN_FORMULA] = Constants.DEFAULT_FORMULA.ToString();
        }

        private void InitFromRow(DataRow row, DataRow fromRow)
        {
            row[Constants.COLUMN_START_HEIGHT] = fromRow[Constants.COLUMN_END_HEIGHT];
            row[Constants.COLUMN_END_HEIGHT] = fromRow[Constants.COLUMN_END_HEIGHT];
            row[Constants.COLUMN_START_ANGLE] = fromRow[Constants.COLUMN_END_ANGLE];
            row[Constants.COLUMN_END_ANGLE] = fromRow[Constants.COLUMN_END_ANGLE];
            row[Constants.COLUMN_PRECISION] = Constants.DEFAULT_PRECISION;
            row[Constants.COLUMN_FORMULA] = Constants.DEFAULT_FORMULA.ToString();
        }

        private bool CheckRowValues(DataGridViewRow row)
        {
            return ParseUtils.CheckFloat(row.Cells[dgvSegments.Columns[Constants.START_HEIGHT].Index].Value.ToString())
                && ParseUtils.CheckFloat(row.Cells[dgvSegments.Columns[Constants.END_HEIGHT].Index].Value.ToString())
                && ParseUtils.CheckFloat(row.Cells[dgvSegments.Columns[Constants.START_ANGLE].Index].Value.ToString())
                && ParseUtils.CheckFloat(row.Cells[dgvSegments.Columns[Constants.END_ANGLE].Index].Value.ToString())
                && ParseUtils.CheckFloat(row.Cells[dgvSegments.Columns[Constants.PRECISION].Index].Value.ToString())
                && ParseUtils.CheckFormula(row.Cells[dgvSegments.Columns[Constants.FORMULA].Index].Value.ToString());
        }

        private bool PromptToSave()
        {
            if (!isFileChanged)
                return true;

            DialogResult promptToSave = MetroMessageBox.Show(this,
                GetResource("save_changes_to_file", FileName),
                Constants.APPLICATION_NAME, MessageBoxButtons.YesNoCancel);
            switch (promptToSave)
            {
                case DialogResult.Yes:
                    SaveSegmentsToFile(FileName);
                    return true;
                case DialogResult.No:
                    return true;
                case DialogResult.Cancel:
                default:
                    return false;
            }
        }

        private void ClearSegments()
        {
            segmentDataSet.Tables[Constants.TABLE_SEGMENTS].Rows.Clear();
            ResultPoints = new List<TCompositePoint>();
            Cleaned(this, null);
            isFileChanged = false;
        }

        private void SetInfo(string fileName)
        {
            FileName = fileName;
            TitleText = string.IsNullOrEmpty(fileName) || fileName == DefaultFileNameExtension
                ? Constants.DEFAULT_TITLE_TEXT
                : string.Format("{0} - {1}", Constants.DEFAULT_TITLE_TEXT, fileName);
        }

        private void SaveSegmentsToFile(string fileName)
        {
            StringBuilder exportSegmentsString = new StringBuilder();
            foreach (DataRow dr in segmentDataSet.Tables[Constants.TABLE_SEGMENTS].Rows)
            {
                exportSegmentsString.AppendLine(
                    string.Format("{0:0.####},{1:0.####},{2:0.####},{3:0.####},{4:0.####},{5}",
                        dr[Constants.COLUMN_START_HEIGHT], dr[Constants.COLUMN_END_HEIGHT],
                        dr[Constants.COLUMN_START_ANGLE], dr[Constants.COLUMN_END_ANGLE],
                        dr[Constants.COLUMN_PRECISION], dr[Constants.COLUMN_FORMULA]));
            }

            File.WriteAllText(fileName, exportSegmentsString.ToString());
        }

        private void ParseSegments()
        {
            using (StreamReader reader = new StreamReader(File.OpenRead(openFileDialog.FileName)))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    if (!ParseUtils.CheckFloat(values[Constants.START_HEIGHT])
                        || !ParseUtils.CheckFloat(values[Constants.END_HEIGHT])
                        || !ParseUtils.CheckFloat(values[Constants.START_ANGLE])
                        || !ParseUtils.CheckFloat(values[Constants.END_ANGLE])
                        || !ParseUtils.CheckFloat(values[Constants.PRECISION])
                        || !ParseUtils.CheckFormula(values[Constants.FORMULA]))
                    {
                        MetroMessageBox.Show(this, GetResource("incorrect_values_in_import_file"), GetResource("error"));
                        return;
                    }

                    DataRow dr = segmentDataSet.Tables[Constants.TABLE_SEGMENTS].NewRow();
                    dr[Constants.COLUMN_START_HEIGHT] = values[Constants.START_HEIGHT];
                    dr[Constants.COLUMN_END_HEIGHT] = values[Constants.END_HEIGHT];
                    dr[Constants.COLUMN_START_ANGLE] = values[Constants.START_ANGLE];
                    dr[Constants.COLUMN_END_ANGLE] = values[Constants.END_ANGLE];
                    dr[Constants.COLUMN_PRECISION] = values[Constants.PRECISION];
                    dr[Constants.COLUMN_FORMULA] = values[Constants.FORMULA];

                    segmentDataSet.Tables[Constants.TABLE_SEGMENTS].Rows.Add(dr);
                }
            }
        }

        public new bool Validate()
        {
            errorProvider.Clear();

            if (!ValidateGridNotEmpty())
                return false;

            if (!ValidateGrid())
                return false;

            return true;
        }

        private bool ValidateGrid()
        {
            foreach (DataGridViewRow row in dgvSegments.Rows)
            {
                if (!CheckRowValues(row))
                {
                    dgvSegments.Rows[dgvSegments.Rows.IndexOf(row)].ErrorText = GetResource("enter_all_values");
                    return false;
                }
            }

            return true;
        }

        private bool ValidateGridNotEmpty()
        {
            if (dgvSegments.Rows.Count != 0)
                return true;

            errorProvider.SetError(dgvSegments, GetResource("enter_at_least_one_segment"));
            return false;
        }

        public override void SetResources()
        {
            gbSegments.Text = GetResource("segments");
            btnClearSegments.Text = GetResource("new_layout");
            btnImportSegments.Text = GetResource("open_layout");
            btnExportSegments.Text = GetResource("save_layout");
            dgvSegments.Columns[Constants.START_HEIGHT].HeaderText = GetResource("start_height");
            dgvSegments.Columns[Constants.END_HEIGHT].HeaderText = GetResource("end_height");
            dgvSegments.Columns[Constants.START_ANGLE].HeaderText = GetResource("start_angle");
            dgvSegments.Columns[Constants.END_ANGLE].HeaderText = GetResource("end_angle");
            dgvSegments.Columns[Constants.PRECISION].HeaderText = GetResource("precision");
            dgvSegments.Columns[Constants.FORMULA].HeaderText = GetResource("formula");

            SetFormulaTypeResources();
        }

        private void SetFormulaTypeResources()
        {
            Array formulaTypes = Enum.GetValues(typeof(FormulaType));
            List<FormulaType> formulaTypesList = new List<FormulaType>();
            foreach (FormulaType ft in formulaTypes)
                formulaTypesList.Add(ft);

            DataGridViewComboBoxColumn dgvcbcFormulaType = dgvSegments.Columns[Constants.FORMULA] as DataGridViewComboBoxColumn;
            dgvcbcFormulaType.DataSource = formulaTypesList.Select(ft => new
            {
                Name = GetResource(Enum.GetName(typeof(FormulaType), ft)),
                Value = ft.ToString()
            }).ToList();
            dgvcbcFormulaType.ValueMember = "Value";
            dgvcbcFormulaType.DisplayMember = "Name";
        }
    }
}
