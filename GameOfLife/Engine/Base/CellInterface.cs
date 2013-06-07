using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Engine.Base
{
    public interface CellInterface
    {

        int rowIndex { get; set; }

        int columnIndex { get; set; }

        bool isAlive { get; set; }

    }
}
