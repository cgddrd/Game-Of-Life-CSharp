using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Engine.Base
{
    public interface EvolutionInterface<TC, TG> where TC:CellInterface
                                                where TG:GridInterface<TC>
    {

        void Execute(TG currentGrid);

    }
}
