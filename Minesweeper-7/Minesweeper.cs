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
            IEngine engine = new Engine();
            engine.Play();
        }
    }
}
