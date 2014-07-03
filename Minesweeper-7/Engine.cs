namespace Minesweeper
{
    using System.Linq;
    using System;

    /// <summary>
    /// Represents the engine that executes the main logic of the game. 
    /// </summary>
    public class Engine: IEngine
    {
        private IInputOutputManager renderer;
        private IScoreBoard scoreBoard;
        private Field field;
        private bool playing;
        private string currentUserInput;
        public Engine()
        {
            this.renderer = new ConsoleInputOtputManager();
            this.scoreBoard = new ScoreBoard();
            this.field = new Field(5, 10);
            this.playing = true;
        }
        public void Play()
        {
            //TODO: Implement the main playing logic of the game.
            renderer.PrintInitialMessage();
            renderer.PrintGameField(this.field, false);

            while (playing)
            {
                currentUserInput = renderer.GetUserInput();
            }
            
            throw new NotImplementedException();
        }

        private static void CheckCurrentCommand(string command)
        {
            //TODO: Implement this method
            if (command.Length == 2)
            {
                throw new NotImplementedException();
            }
            else
            {
                switch (command)
                {
                    case "exit": Environment.Exit(1); break;
                    case "restart": throw new NotImplementedException();
                    case "top": throw new NotImplementedException();
                    default:
                        break;
                }
            }
            
        }
    }
}

