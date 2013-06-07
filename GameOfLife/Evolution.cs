using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Engine.Base;

namespace GameOfLife.Engine
{
    public class Evolution : EvolutionInterface<CellInterface, GridInterface<CellInterface>>
    {

        //Underscore '_' used to indicate the variables are private. 
        private NeighbourCalculatorInterface<CellInterface, GridInterface<CellInterface>> _neighbourCalculator;
        private GameRuleInterface<CellInterface, GridInterface<CellInterface>, CellRuleInterface<CellInterface, GridInterface<CellInterface>>> _gameRules;

        public Evolution(NeighbourCalculatorInterface<CellInterface, GridInterface<CellInterface>> neighbourCalculator,
                         GameRuleInterface<CellInterface, GridInterface<CellInterface>, CellRuleInterface<CellInterface, GridInterface<CellInterface>>> gameRules)
        {
            _neighbourCalculator = neighbourCalculator;
            _gameRules = gameRules;
            _gameRules.LiveCellRule.NeighbourCalculator = neighbourCalculator;
            _gameRules.DeadCellRule.NeighbourCalculator = neighbourCalculator;
        }

        public void Execute(GridInterface<CellInterface> currentGrid)
        {
            var gridCopy = currentGrid.getDeepCopy();
            _neighbourCalculator.Grid = gridCopy;
            _gameRules.LiveCellRule.Grid = gridCopy;
            _gameRules.DeadCellRule.Grid = gridCopy;

            foreach (var cell in currentGrid.Cells)
            {
                if (cell.isAlive)
                {
                    _gameRules.LiveCellRule.Execute(cell);
                }
                else
                {
                    _gameRules.DeadCellRule.Execute(cell);
                }
            }
        }
    }
}
