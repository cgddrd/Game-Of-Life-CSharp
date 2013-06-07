using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Engine.Base;

namespace GameOfLife.UI
{
    public static class GridUIExtensions
    {

        private const char LiveCell = 'X';
        private const char DeadCell = '.';
        private const char Separator = ' ';

        /// <summary>
        /// Takes individual cells and returns a formatted
        /// string representing the grid.
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static string toConsoleFormattedString(this GridInterface<CellInterface> grid)
        {
            var builder = new StringBuilder();
            for (var rowIndex = 0; rowIndex < grid.noOfRows; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < grid.noOfColumns; columnIndex++)
                {
                    builder.Append(grid.getCellByIndex(rowIndex, columnIndex).isAlive ? LiveCell : DeadCell);
                    builder.Append(Separator);
                }
                builder.Append(Environment.NewLine);
            }

            return builder.ToString();
        }        
    }
}
