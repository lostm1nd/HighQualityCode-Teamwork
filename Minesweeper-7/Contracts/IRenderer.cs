﻿namespace Minesweeper.Contracts
{
    using System;

    /// <summary>
    /// Manages the output operations of the game.
    /// </summary>
    public interface IRenderer
    {
        /// <summary>
        /// Renders the initial message - welcome message and commands list
        /// </summary>
        void RenderInitialMessage();

        /// <summary>
        /// Renders the game field.
        /// </summary>
        /// <param name="gameField">The field to be Rendered.</param>
        void RenderGameField(IField gameField);

        /// <summary>
        /// Renders an explosion message when the user step on a mine.
        /// </summary>
        void RenderExplosionMessage(int score);

        /// <summary>
        /// Renders a winner message when the user complete the whole game.
        /// </summary>
        void RenderWinnerMessage();

        /// <summary>
        /// Renders a scoreboard.
        /// </summary>
        /// <param name="scoreBoard">Concrete implementation of the IScoreBoard interface.</param>
        void RenderScoreBoard(IScoreBoard scoreBoard);

        /// <summary>
        /// Renders a message on invalid user input.
        /// </summary>
        void RenderInvalidCommandMessage();

        /// <summary>
        /// Renders the end message when the user want to quit the game
        /// </summary>
        void RenderQuitMessage();

        /// <summary>
        /// Renders all possible command when the game ends 
        /// </summary>
        void RenderCommandsMessage();
    }
}
