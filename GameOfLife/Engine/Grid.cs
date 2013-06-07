using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Engine.Base;

namespace GameOfLife.Engine
{
   public class Grid : GridInterface<CellInterface>
   {

       /*
        * Declare multi-dimensional array. "[,]" 
        * and as it is a private member function the underscore
        * is used.
        */
       private readonly CellInterface[,] _grid;

       public int noOfRows { get; set; }
       public int noOfColumns{ get; set; }

       //Regions simply "categorise" visually code to make it easier for the developer.  
       #region Constuctor

       public Grid(int numberOfRows, int numberOfColumns)
       {
           ValidateParams(numberOfRows, numberOfColumns);

           this.noOfRows = numberOfRows;
           this.noOfColumns = numberOfColumns;
           this._grid = new CellInterface[noOfRows, noOfColumns];
       }

       #endregion

       public IEnumerable<CellInterface> Cells
       {
           get { return _grid.Cast<CellInterface>().AsEnumerable(); }
       }

       public CellInterface getCellByIndex(int rowIndex, int columnIndex)
       {
           ValidateCellIndexes(rowIndex, columnIndex);

           return _grid[rowIndex, columnIndex];
       }

       public void addCell(CellInterface newCell)
       {
           ValidateCell(newCell);
           _grid[newCell.rowIndex, newCell.columnIndex] = newCell;
       }

       private static void ValidateParams(int numberOfRows, int numberOfColumns)
       {
           if (numberOfRows < 2)
           {
               throw new ArgumentOutOfRangeException("numberOfRows", "Cannot be less than 2");
           }

           if (numberOfColumns < 2)
           {
               throw new ArgumentOutOfRangeException("numberOfColumns", "Cannot be less than 2");
           }
       }

       private void ValidateCell(CellInterface cell)
       {
           if (cell == null)
           {
               throw new ArgumentNullException("cell", "cannot be null");
           }

           ValidateCellIndexes(cell.rowIndex, cell.columnIndex);
       }

       private void ValidateCellIndexes(int rowIndex, int columnIndex)
       {
           if (rowIndex > noOfRows - 1)
           {
               throw new ArgumentOutOfRangeException("rowIndex", "Cannot have RowIndex greater than NumberOfRows");
           }

           if (columnIndex > noOfColumns - 1)
           {
               throw new ArgumentOutOfRangeException("columnIndex", "Cannot have ColIndex greater than NumberOfColumns");
           }
       }

    }
}
