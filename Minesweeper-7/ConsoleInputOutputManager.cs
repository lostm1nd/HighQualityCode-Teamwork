﻿namespace Minesweeper
{
    using System;
    using System.Linq;

    using Contracts;

    /// <summary>
    /// Manages the input and output operations of the game.
    /// </summary>
    public class ConsoleInputOutputManager : IInputOutputManager
    {
        /// <summary>
        /// Prints the initial message - welcome message and commands list
        /// </summary>
        public string PrintInitialMessage()
        {
            string welcomeMessage = @"Welcome to the game “Minesweeper”. Try to reveal all cells without mines.";
            string commands = "Use 'top' to view the scoreboard, 'restart' to start a new game and 'exit' to quit  the game.";

            Console.WriteLine(welcomeMessage + " " + commands);

            return welcomeMessage + " " + commands;

        }

        /// <summary>
        /// Prints the game field.
        /// </summary>
        /// <param name="gameField">The field to be printed.</param>
        /// <param name="hasBoomed">check if player has explode</param>
        public void PrintGameField(IField gameField, bool hasBoomed)
        {
            if (gameField == null)
            {
                throw new ArgumentNullException("Game field is null!");
            }

            Console.WriteLine(gameField.ToString());

            //char[,] fieldMatrix = gameField.field;

            //Console.WriteLine();
            //Console.WriteLine("     0 1 2 3 4 5 6 7 8 9");
            //Console.WriteLine("   ---------------------");

            //for (int row = 0; row < gameField.Rows; row++)
            //{
            //    Console.Write("{0} | ", row);
            //    for (int col = 0; col < gameField.Columns; col++)
            //    {
            //        char currentSymbol = fieldMatrix[row, col];
            //        PrintCurrentSymbol(currentSymbol, hasBoomed);
            //    }

            //    Console.WriteLine("|");
            //}

            //Console.WriteLine("   ---------------------");
        }

        /// <summary>
        /// Prints an explosion message when the user step on a mine.
        /// </summary>
        public void PrintExplosionMessage(int score)
        {
            Console.WriteLine("\nBooom! You are killed by a mine!" +
                "You revealed {0} cells without mines.", score);
        }

        /// <summary>
        /// Prints a winner message when the user complete the whole game.
        /// </summary>
        public void PrintWinnerMessage()
        {
            Console.WriteLine("Congratulations! You are the WINNER!\n" +
                 "Please enter your name for the top scoreboard: ");
        }

        /// <summary>
        /// Prints a scoreboard.
        /// </summary>
        /// <param name="scoreBoard"></param>
        public void PrintScoreBoard(IScoreBoard scoreBoard)
        {
            if (scoreBoard == null)
            {
                throw new ArgumentNullException("Scoreboard is null!");
            }

            string generatedList = scoreBoard.Generate();

            Console.WriteLine(generatedList);
        }

        /// <summary>
        /// Prints a message on invalid user input.
        /// </summary>
        public void PrintInvalidCommandMessage()
        {
            Console.WriteLine("Invalid row/col entered! Try again!");

        }

        /// <summary>
        /// Prints the end message when the user want to quit the game
        /// </summary>
        public void PrintQuitMessage()
        {
            Console.WriteLine("\nGood bye!\n");
        }

        /// <summary>
        /// Gets the user input - command or coordinates (row and column).
        /// </summary>
        /// <returns>Returns the user input.</returns>
        public string GetUserInput()
        {
            Console.Write("Enter row and column: ");

            string input = Console.ReadLine();
            input = input.Trim();
            if (input.Length < 2)
            {
                throw new ArgumentException("Enter two numbers - one for row, one for col");
            }

            return input;
        }

        /// <summary>
        /// Gets the user nickname.
        /// </summary>
        /// <returns>Returns the user's nickname.</returns>
        public string GetUserNickname()
        {
            Console.Write("Please enter your name: ");
            string playerNickname = Console.ReadLine();
            Console.WriteLine();

            return playerNickname;
        }

        private static void PrintCurrentSymbol(char currentSymbol, bool hasExploded)
        {
            if (!(hasExploded) && ((currentSymbol == char.MinValue) || (currentSymbol == '*')))
            {
                Console.Write(" ?");
            }
            else if (!(hasExploded) && (currentSymbol != char.MinValue) && (currentSymbol != '*'))
            {
                Console.Write(" {0}", currentSymbol);
            }
            else if ((hasExploded) && (currentSymbol == char.MinValue))
            {
                Console.Write(" -");
            }
            else if ((hasExploded) && (currentSymbol != char.MinValue))
            {
                Console.Write(" {0}", currentSymbol);
            }
        }
    }
}