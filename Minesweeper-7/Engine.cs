namespace Minesweeper
{
    using System;
    using System.Linq;
    using Contracts;

    /// <summary>
    /// Represents the engine that executes the main logic of the game. 
    /// </summary>
    public class Engine: IEngine
    {
        private IInputOutputManager renderer;
        private IScoreBoard scoreBoard;
        private IField field;
        private bool playing;
        private string currentUserInput;
        public Engine(IField field)
        {
            this.renderer = new ConsoleInputOutputManager();
            this.scoreBoard = new ScoreBoard();
            this.field = field;
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
                CheckCurrentCommand(currentUserInput);

            }
            
            throw new NotImplementedException();
        }

        private void CheckCurrentCommand(string command)
        {
            string clearedCommand = command.Replace(" ", String.Empty);

            //TODO: Implement this method
            if (clearedCommand.Length == 2)
            {
                int currentRow = int.Parse(clearedCommand[0].ToString());
                int currentCol = int.Parse(clearedCommand[1].ToString());

                
                this.renderer.PrintGameField(this.field, false);
                throw new NotImplementedException();
            }
            else
            {
                switch (clearedCommand)
                {
                    case "exit": Environment.Exit(1); break;
                    case "restart": throw new NotImplementedException();
                    case "top": throw new NotImplementedException();
                    default:
                        break;
                }
            }
            
        }

        private static bool CheckIsValidNumbers(string command)
        {
            return true;
        }
    }
}

