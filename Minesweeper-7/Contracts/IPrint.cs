namespace Minesweeper.Contracts
{
    using System;

    /// <summary>
    /// Manages the output operations of the game.
    /// </summary>
    public interface IPrint
    {
        /// <summary>
        /// Prints the initial message - welcome message and commands list
        /// </summary>
        string PrintInitialMessage();

        /// <summary>
        /// Prints the game field.
        /// </summary>
        /// <param name="gameField">The field to be printed.</param>
        /// <param name="hasBoomed">check if player has explode</param>
        void PrintGameField(Field gameField, bool hasBoomed);

        /// <summary>
        /// Prints an explosion message when the user step on a mine.
        /// </summary>
        void PrintExplosionMessage(int score);


        /// <summary>
        /// Prints a winner message when the user complete the whole game.
        /// </summary>
        void PrintWinnerMessage();

        /// <summary>
        /// Prints a scoreboard.
        /// </summary>
        /// <param name="scoreBoard"></param>
        void PrintScoreBoard(IScoreBoard scoreBoard);

        /// <summary>
        /// Prints a message on invalid user input.
        /// </summary>
        void PrintInvalidCommandMessage();

        /// <summary>
        /// Prints the end message when the user want to quit the game
        /// </summary>
        void PrintQuitMessage();

    }
}
