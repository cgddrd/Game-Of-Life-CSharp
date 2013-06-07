using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Engine;
using GameOfLife.UI;
using GameOfLife.UI.Base;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            //fetch the dependencies - here we just create them
            var neighbourCalculator = new NeighbourCalculator();
            var gameRules = new GameRules(new LiveCellRule(), new DeadCellRule());
            var evolution = new Evolution(neighbourCalculator, gameRules);
            var gridRowColumnParser = new GridParser();
            //typically we would create such an object and inject its dependencies
            //using an IoC container

            //Have to reference to via the namespace as the class and namespace are called the same thing.
            GameOfLifeInterface gameOfLife = new GameOfLife.UI.GameOfLife(evolution, gridRowColumnParser);
            gameOfLife.start();

        }
    }
}
