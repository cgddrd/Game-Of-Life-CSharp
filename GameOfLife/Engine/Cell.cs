using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Engine.Base;

namespace GameOfLife.Engine
{
    public class Cell : CellInterface
    {

        public int rowIndex { get; set; }

        public int columnIndex { get; set; }

        public bool isAlive { get; set; }


    }
}