using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.UI.Base;
using GameOfLife.Engine;
using GameOfLife.Engine.Base;


namespace GameOfLife.UI
{
    public class GridParser : GridParserInterface<GridInterface<CellInterface>>
    {
        #region Fields

        private readonly char[] _rowColumnPairsSeparator;
        private readonly char[] _rowColumnSeparator;

        #endregion

        #region Constructor

        public GridParser(char rowColumnPairsSeparator = ':', char rowColumnSeparator = ',')
        {
            _rowColumnPairsSeparator = new[] {rowColumnPairsSeparator};
            _rowColumnSeparator = new[] {rowColumnSeparator};
        }

        #endregion

        #region Public

        /// <summary>
        /// Parses a string specifying row and column index of a live 
        /// <see cref="ICell"/> 
        /// The format of the sting is rowIndex,colIndex | rowIndex,colIndex
        /// and returns a <see cref="IGrid{ICell}"/> object containing <paramref name="numberofRows"/>
        /// rows and <paramref name="numberOfcolumns"/>
        /// </summary>
        /// <param name="gridRowColumnString"></param>
        /// <param name="numberofRows"> </param>
        /// <param name="numberOfcolumns"> </param>
        /// <returns></returns>
        public GridInterface<CellInterface> ParseGrid(string gridRowColumnString, int numberofRows, int numberOfcolumns)
        {
            //create a grid and initialize it with dead cells
            var grid = CreateGrid(numberofRows, numberOfcolumns);
            gridRowColumnString = gridRowColumnString.Trim(' ', _rowColumnPairsSeparator[0]);
            if (gridRowColumnString.Length != 0)//no alive cells
            {                
                var rowColumnPairs = gridRowColumnString.Split(_rowColumnPairsSeparator);   
                foreach (var rowColumnPair in rowColumnPairs)
                {
                    var index = ParseAndReturnCellIndex(rowColumnPair, numberofRows, numberOfcolumns);
                    grid.getCellByIndex(index[0], index[1]).isAlive = true;
                }
            }
            return grid;
        }

        #endregion

        #region Private

        private Grid CreateGrid(int numberOfRows, int numberOfColumns)
        {
            var grid = new Grid(numberOfRows, numberOfColumns);
            for (int newRowIndex = 0; newRowIndex < numberOfRows; newRowIndex++)
            {
                for (int newColIndex = 0; newColIndex < numberOfColumns; newColIndex++)
                {
                    grid.addCell(new Cell{rowIndex = newRowIndex, columnIndex = newColIndex});
                }
            }
            return grid;
        }

        private int[] ParseAndReturnCellIndex(string rowColumnPair, int numberofRows, int numberOfcolumns)
        {
            if (!rowColumnPair.Contains(_rowColumnSeparator[0]))//no valid row,col index pair
            {
                throw new ArgumentException(string.Format("The row column pair {0} has no rowColumn separator", rowColumnPair));
            }

            var cellIndex = rowColumnPair.Split(_rowColumnSeparator);
            if (!cellIndex.Any())//no valid row,col index
            {
                throw new ArgumentException(string.Format("The row column pair {0} is not valid", rowColumnPair));
            }

            int rowIndex;
            if (!Int32.TryParse(cellIndex[0], out rowIndex) || rowIndex < 0 || rowIndex >= numberofRows)
            {
                throw new ArgumentException(string.Format("The row column pair {0} is not valid", rowColumnPair));
            }

            int colIndex;
            if (!Int32.TryParse(cellIndex[1], out colIndex) || colIndex < 0 || colIndex >= numberOfcolumns)
            {
                throw new ArgumentException(string.Format("The row column pair {0} is not valid", rowColumnPair));
            }

            return new[] {rowIndex, colIndex};
        }

        #endregion
    }
}
