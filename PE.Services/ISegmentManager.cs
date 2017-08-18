using PE.Entities;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PE.Services
{
    public interface ISegmentManager<TSegment>
        where TSegment : ISegment, new()
    {
        IEnumerable<TSegment> ParseSegments(DataGridViewRowCollection rows);
    }
}
