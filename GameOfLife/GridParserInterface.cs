using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Engine.Base;

namespace GameOfLife.UI.Base
{
   public interface GridParserInterface<TG> where TG : GridInterface<CellInterface>
    {

       //Declaring a ParseGrid method that returns a GridInterface object (A.K.A: TG)
       TG ParseGrid(string gridRowColumnString, int numberofRows, int numberOfcolumns);

    }
}
