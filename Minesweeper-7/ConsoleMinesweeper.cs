namespace Minesweeper
{
    using System;
    using System.Linq;
    using Contracts;

    /// <summary>
    /// Represents the main application from which will start the game.
    /// </summary>
    public class ConsoleMinesweeper
    {
        public void Start()
        {
            FieldFactory minesweeperFactory = new MinesweeperFieldFactory();
            IField minesweeperField = minesweeperFactory.CreateField();

            FieldFactory playingFieldFactory = new PlayingFieldFactory();
            IField playingField = playingFieldFactory.CreateField();

            IRenderer consoleRenderer = new ConsoleRenderer();
            IReadInput inputReader = new ConsoleReader();
            IScoreBoard scoreboard = new ScoreBoard();

            IEngine engine = new Engine(minesweeperField, playingField, consoleRenderer, inputReader, scoreboard);
            engine.Play();
        }
    }
}
