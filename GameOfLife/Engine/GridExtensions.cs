using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Engine.Base;

namespace GameOfLife.Engine
{
    /*
     * Static class which cannot be instantiated, but used 
     * to provide additional functionality.
     */
    public static class GridExtensions
    {

        /*
         * Static method that can be utilised with 'Grid'/'GridInterface' objects to provide a 
         * deep copy of a 'GridInterface' object. 
         */
        public static GridInterface<CellInterface> getDeepCopy(this GridInterface<CellInterface> grid)
        {
            var gridCopy = new Grid(grid.noOfRows, grid.noOfColumns);

            foreach (var cell in grid.Cells)
            {
                var cellCopy = new Cell { rowIndex = cell.rowIndex, columnIndex = cell.columnIndex, isAlive = cell.isAlive };
                gridCopy.addCell(cellCopy);
            }

            return gridCopy;
        }
    }
}
