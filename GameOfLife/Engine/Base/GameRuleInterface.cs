using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Engine.Base
{
    public interface GameRuleInterface<TC, TG, TCR> where TC:CellInterface
                                                    where TG:GridInterface<TC>
                                                    where TCR:CellRuleInterface<TC, TG>
    {

        TCR LiveCellRule { get; }

        TCR DeadCellRule { get; }

    }
}
