using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Engine.Base;

namespace GameOfLife.Engine
{
    public class DeadCellRule : CellRule<CellInterface, GridInterface<CellInterface>>
    {

        /*
         * Overrides the 'abstract' method in CellRule.cs
         */
        public override void Execute(CellInterface cell)
        {
            this.ValidateCell(cell);

            //'var' is an implicit type declaration that is chosen by the compiler, not the developer.
            var neighbours = NeighbourCalculator.retrieveNeighbours(cell.rowIndex, cell.columnIndex);
            
            //'Where' is used to "filter" an IEnumerable collection. 
            var aliveNeighbours = neighbours.Where(n => n.isAlive);

            //If a cell has three neighbours exactly, make it alive. 
            if (aliveNeighbours.Count() == 3)
            {
                cell.isAlive = true;
            }

        }

        protected override void ValidateCell(CellInterface cell)
        {
            //Explicit call to base class (CellRule.ValidateCell).
            base.ValidateCell(cell);

            if (cell.isAlive)
            {

                throw new ArgumentException("This rule can only be applied to dead cells");
            }

        }
    }
}
