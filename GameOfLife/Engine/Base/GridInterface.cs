using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Engine.Base
{
    public interface GridInterface<ICell> where ICell : CellInterface
    {

        IEnumerable<ICell> Cells { get; }

        int noOfRows { get; }

        int noOfColumns { get; }

        ICell getCellByIndex (int rowIndex, int columnIndex);

        void addCell(ICell newCell);

    }
}
