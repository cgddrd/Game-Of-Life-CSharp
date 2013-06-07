using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Engine.Base;

namespace GameOfLife.Engine
{
    public class NeighbourCalculator : NeighbourCalculatorInterface<CellInterface, GridInterface<CellInterface>>
    {
        #region Fields

        private GridInterface<CellInterface> _grid;

        #endregion

        #region Public

        public IEnumerable<CellInterface> retrieveNeighbours(int rowIndex, int columnIndex)
        {
            var neighbours = new List<CellInterface>();

            if (_grid == null)
            {
                throw new Exception("Grid needs to be initialized before calling this method");
            }

            CellInterface neighbour = CalculateDiagonalTopLeftNeighbour(rowIndex, columnIndex);
            if (neighbour != null)
            {
                neighbours.Add(neighbour);
            }

            neighbour = CalculateDiagonalTopRightNeighbour(rowIndex, columnIndex);
            if (neighbour != null)
            {
                neighbours.Add(neighbour);
            }

            neighbour = CalculateDiagonalBottomLeftNeighbour(rowIndex, columnIndex);
            if (neighbour != null)
            {
                neighbours.Add(neighbour);
            }

            neighbour = CalculateDiagonalBottomRightNeighbour(rowIndex, columnIndex);
            if (neighbour != null)
            {
                neighbours.Add(neighbour);
            }

            neighbour = CalculateTopNeighbour(rowIndex, columnIndex);
            if (neighbour != null)
            {
                neighbours.Add(neighbour);
            }

            neighbour = CalculateBottomNeighbour(rowIndex, columnIndex);
            if (neighbour != null)
            {
                neighbours.Add(neighbour);
            }

            neighbour = CalculateLeftNeighbour(rowIndex, columnIndex);
            if (neighbour != null)
            {
                neighbours.Add(neighbour);
            }

            neighbour = CalculateRightNeighbour(rowIndex, columnIndex);
            if (neighbour != null)
            {
                neighbours.Add(neighbour);
            }

            return neighbours;
        }

        /// <summary>
        /// gets/sets the grid which will be 
        /// used by <see cref="retrieveNeighbours"/>
        /// to calculate the neighbors of a cell
        /// </summary>
        public GridInterface<CellInterface> Grid
        {
            get { return _grid; }
            set { _grid = value; }
        }

        #endregion

        #region Private

        private CellInterface CalculateDiagonalTopLeftNeighbour(int rowIndex, int columnIndex)
        {
            return CalculateNeighbour(rowIndex - 1, columnIndex - 1);
        }

        private CellInterface CalculateDiagonalTopRightNeighbour(int rowIndex, int columnIndex)
        {
            return CalculateNeighbour(rowIndex - 1, columnIndex + 1);
        }

        private CellInterface CalculateDiagonalBottomLeftNeighbour(int rowIndex, int columnIndex)
        {
            return CalculateNeighbour(rowIndex + 1, columnIndex - 1);
        }

        private CellInterface CalculateDiagonalBottomRightNeighbour(int rowIndex, int columnIndex)
        {
            return CalculateNeighbour(rowIndex + 1, columnIndex + 1);
        }

        private CellInterface CalculateTopNeighbour(int rowIndex, int columnIndex)
        {
            return CalculateNeighbour(rowIndex - 1, columnIndex);
        }

        private CellInterface CalculateBottomNeighbour(int rowIndex, int columnIndex)
        {
            return CalculateNeighbour(rowIndex + 1, columnIndex);
        }

        private CellInterface CalculateLeftNeighbour(int rowIndex, int columnIndex)
        {
            return CalculateNeighbour(rowIndex, columnIndex - 1);
        }

        private CellInterface CalculateRightNeighbour(int rowIndex, int columnIndex)
        {
            return CalculateNeighbour(rowIndex, columnIndex + 1);
        }

        private CellInterface CalculateNeighbour(int neighbourRowIndex, int neighbourColIndex)
        {
            if (NeighbourIndexIsValid(neighbourRowIndex, neighbourColIndex))
            {
                return _grid.getCellByIndex(neighbourRowIndex, neighbourColIndex);
            }

            return null;
        }

        private bool NeighbourIndexIsValid(int rowIndex, int colIndex)
        {
            int rowUpperBound = _grid.noOfRows - 1;
            int colUpperBound = _grid.noOfColumns - 1;

            if (rowIndex > rowUpperBound || rowIndex < 0)
            {
                return false;
            }

            if (colIndex > colUpperBound || colIndex < 0)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}
