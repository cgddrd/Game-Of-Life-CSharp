using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Engine.Base
{
    public interface NeighbourCalculatorInterface<TC, TG> where TC:CellInterface
                                                          where TG:GridInterface<TC>

    {

        IEnumerable<TC> retrieveNeighbours(int rowIndex, int columnIndex);

        TG Grid { get; set; }
    }
}
