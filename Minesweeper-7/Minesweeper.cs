namespace Minesweeper
{
    using System;
    using System.Linq;
    using Contracts;

    /// <summary>
    /// Represents the main application from which will start the game.
    /// </summary>
    public class Minesweeper
    {
        internal static void Main()
        {
            FieldFactory minesweeperFactory = new MinesweeperField();
            IField minesweeperField = minesweeperFactory.CreateField();

            Console.WriteLine(minesweeperField.ToString());

            //IEngine engine = new Engine();
            //engine.Play();
        }
    }
}
