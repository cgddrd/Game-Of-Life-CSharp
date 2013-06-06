using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Engine.Base;

namespace GameOfLife
{
    public interface CellRuleInterface<TC, TG> where TC:CellInterface
                                               where TG:GridInterface<TC>

    {

        void Execute(TC theCell)
        {
            Console.Beep();
        }
    }
}
