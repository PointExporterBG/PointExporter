using PE.Common;
using PE.Common.Exceptions;
using PE.Common.Utils;
using PE.Entities;
using PE.Language;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PE.Services.Default
{
    public class SegmentManager<TSegment> : ISegmentManager<TSegment>
        where TSegment : ISegment, new()
    {
        private ISegmentFactory<TSegment> segmentFactory;
        private IResourceManager resourceManager;

        public SegmentManager(ISegmentFactory<TSegment> segmentFactory, IResourceManager resourceManager)
        {
            this.segmentFactory = segmentFactory;
            this.resourceManager = resourceManager;
        }

        public IEnumerable<TSegment> ParseSegments(DataGridViewRowCollection rows)
        {
            ICollection<TSegment> segments = new List<TSegment>();
            foreach (DataGridViewRow row in rows)
            {
                double precision = ParseUtils.ParseDouble(row.Cells[Constants.PRECISION].Value.ToString());
                FormulaType formulaType = FormulaType.Linear;
                bool isFormula = Enum.TryParse<FormulaType>(row.Cells[Constants.FORMULA].Value.ToString(), out formulaType);
                if (!isFormula)
                    throw new PEException(resourceManager,"not_supported_formula");

                segments.Add(
                    segmentFactory.Create(
                             ParseUtils.ParseDouble(row.Cells[Constants.START_HEIGHT].Value.ToString()),
                             ParseUtils.ParseDouble(row.Cells[Constants.END_HEIGHT].Value.ToString()),
                             ParseUtils.ParseDouble(row.Cells[Constants.START_ANGLE].Value.ToString()),
                             ParseUtils.ParseDouble(row.Cells[Constants.END_ANGLE].Value.ToString()),
                             precision,
                             formulaType));
            }

            return segments;
        }
    }
}
