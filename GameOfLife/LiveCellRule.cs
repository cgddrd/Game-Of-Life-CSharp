using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Engine.Base;


namespace GameOfLife.Engine
{
    public class LiveCellRule : CellRule<CellInterface, GridInterface<CellInterface>>
    {

        public override void Execute(CellInterface cell)
        {
            ValidateCell(cell);

            var neighbours = NeighbourCalculator.retrieveNeighbours(cell.rowIndex, cell.columnIndex);
            var aliveNeighbours = neighbours.Where(n => n.isAlive).ToList();

            if (aliveNeighbours.Count() < 2 || aliveNeighbours.Count() > 3)
            {
                cell.isAlive = false;
            }
        }

        protected override void ValidateCell(CellInterface cell)
        {
            base.ValidateCell(cell);

            if (!cell.isAlive)
            {
                throw new ArgumentException("This rule can only be applied to alive cells");
            }
        }
    }

}
