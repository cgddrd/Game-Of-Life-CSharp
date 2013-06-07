﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.UI.Base;
using GameOfLife.Engine.Base;

namespace GameOfLife.UI
{
   public class GameOfLife : GameOfLifeInterface
    {

        #region Fields

        private int _numberOfRows;
        private int _numberOfColumns;
        private int _numberOfEvolutions;
        private GridInterface<CellInterface> _userGrid;
        private readonly GridParserInterface<GridInterface<CellInterface>> _gridRowColumnParser;
        private readonly EvolutionInterface<CellInterface, GridInterface<CellInterface>> _evolution;

        #endregion

        #region Constructor

        public GameOfLife(EvolutionInterface<CellInterface, GridInterface<CellInterface>> evolution, GridParserInterface<GridInterface<CellInterface>> gridRowColumnParser)
        {
            _evolution = evolution;
            _gridRowColumnParser = gridRowColumnParser;
        }

        #endregion

        #region Public

        public void start()
        {
            do
            {
                PrintInstructionsToScreen();
                while (!TakeNumberOfRowsFromUser())
                {
                    PrintInvalidInputMessage();
                }
                while (!TakeNumberOfColumnsFromUser())
                {
                    PrintInvalidInputMessage();
                }
                while (!TakeLiveCellsFromUser())
                {
                    PrintInvalidInputMessage();
                }
                while (!TakeNumberOfEvolutionsFromUser())
                {
                    PrintInvalidInputMessage();
                }
                Console.WriteLine("Following grid will be used:");
                Console.WriteLine(_userGrid.toConsoleFormattedString());
                Console.WriteLine("Press Enter key to continue.");
                Console.ReadLine();
                StartEvolution();
            } while (GetUserConfirmation());
        }

        #endregion

        #region Private

        private void StartEvolution()
        {
            for (int count = 0; count < _numberOfEvolutions; count++)
            {
                _evolution.Execute(_userGrid);
                Console.WriteLine("Grid after {0} evolution(s).\nPress enter to continue", count + 1);
                Console.WriteLine(_userGrid.toConsoleFormattedString());
                Console.ReadLine();            }
        }

        private bool GetUserConfirmation()
        {
            Console.WriteLine("Press Y followed by the Enter key to continue.");
            var userInput = Console.ReadLine();
            if (string.Equals(userInput.Trim(), "Y", StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        }

        private void PrintInvalidInputMessage()
        {
            Console.WriteLine("Invalid input. Please enter again");
        }

        private void PrintInstructionsToScreen()
        {
            Console.WriteLine("-----------------------------The Game Of Life-----------------------------\n");
            Console.WriteLine(
                "To start you will have to specify the size of the grid,\nthe initial live cells in the grid and\nthe number of times you want the grid to evolve.\n\n");
            Console.WriteLine("Specify the live cells in the format : rowIndex,colIndex | rowIndex,colIndex\n\n");
            Console.WriteLine("A live cell is represented by X and ");
            Console.WriteLine("a dead cell is represented by .\n\n");
            Console.WriteLine("Messages on the screen will now prompt for an input .\n\n");
            Console.WriteLine("--------------------------------------------------------------------------\n");
        }

        private bool TakeNumberOfRowsFromUser()
        {
            Console.WriteLine("Enter number of rows followed by Enter key.");
            var userInput = Console.ReadLine();
            return Int32.TryParse(userInput, out _numberOfRows);
        }

        private bool TakeNumberOfColumnsFromUser()
        {
            Console.WriteLine("Enter number of columns followed by Enter key.");
            var userInput = Console.ReadLine();
            return Int32.TryParse(userInput, out _numberOfColumns);
        }

        private bool TakeNumberOfEvolutionsFromUser()
        {
            Console.WriteLine("Enter number of evolutions followed by Enter key.");
            var userInput = Console.ReadLine();
            return Int32.TryParse(userInput, out _numberOfEvolutions);
        }

        private bool TakeLiveCellsFromUser()
        {
            Console.WriteLine(
                "Enter live cells in the format: rowIndex,colIndex : rowIndex,colIndex.\nfollowed by Enter key");
            var userInput = Console.ReadLine();
            var result = false;
            try
            {
                _userGrid = _gridRowColumnParser.ParseGrid(userInput, _numberOfRows, _numberOfColumns);
                result = true;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine("Following error occurred : " + exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Unknown error occurred : " + exception.Message);
            }
            return result;
        }

        #endregion
    }
}
