using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Engine.Base;

namespace GameOfLife.Engine
{
    public abstract class CellRule<TC, TG> : CellRuleInterface<TC, TG> where TC:CellInterface
                                                                       where TG:GridInterface<TC>
    {

        public abstract void Execute(TC cell);

        public NeighbourCalculatorInterface<TC, TG> NeighbourCalculator { get; set; }

        public TG Grid { get; set; }

        protected virtual void ValidateCell(TC cell)
        {
            if (Grid == null)
            {
                throw new Exception("Grid needs to be set before calling this method");
            }

            if (NeighbourCalculator == null)
            {
                throw new Exception("NeighbourCalculator needs to be set before calling this method");
            }

            if (cell == null)
            {
                throw new ArgumentNullException("cell", "Cannot be null");
            }
        }
    }
}
