using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Engine.Base
{
    /* '<ICell>' is just a name for the class parameter type. It could have been called anything.
     * Therefore, the class is basically using a generic type, but by using the 'where' keyword, 
     * it specifies that any types used as parameters for the generic class 'GridInterface' MUST in some
     * implement the 'CellInterface' interface. 
     * 
     * Basically, only classes that implement 'CellInterface' (e.g. a cell) can
     * be used with this generic class. 
     */
    public interface GridInterface<ICell> where ICell : CellInterface
    {

        IEnumerable<ICell> Cells { get; }

        int noOfRows { get; }

        int noOfColumns { get; }

        ICell getCellByIndex (int rowIndex, int columnIndex);

        void addCell(ICell newCell);

    }
}
