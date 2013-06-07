using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Engine.Base;
using GameOfLife;

namespace GameOfLife.Engine
{
    public class GameRules : GameRuleInterface<CellInterface, GridInterface<CellInterface>, CellRuleInterface<CellInterface, GridInterface<CellInterface>>>
    {
        public GameRules(CellRuleInterface<CellInterface, GridInterface<CellInterface>> liveCellRule, CellRuleInterface<CellInterface, GridInterface<CellInterface>> deadCellRule)
        {

            this.LiveCellRule = liveCellRule;
            this.DeadCellRule = deadCellRule;

        }

        public CellRuleInterface<CellInterface, GridInterface<CellInterface>> LiveCellRule { get; set; }

        public CellRuleInterface<CellInterface, GridInterface<CellInterface>> DeadCellRule { get; set; }

    }
}
