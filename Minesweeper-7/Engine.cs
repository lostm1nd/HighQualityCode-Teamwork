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
        private IField emptyField;
        private bool playing;
        private string currentUserInput;
        private int currentUserScore;
        private int openedCells;
        private string currentUserName;
        private int currentRow;
        private int currentCol;
        public Engine(IField mineField, IField playingField)
        {
            this.renderer = new ConsoleInputOutputManager();
            this.scoreBoard = new ScoreBoard();
            this.emptyField = playingField;
            this.field = mineField;
            this.playing = true;
            this.currentUserName = "Player";
            this.currentUserScore = 0;
            this.openedCells = 0;
        }
        public void Play()
        {
            //TODO: Implement the main playing logic of the game.
            renderer.PrintInitialMessage();
            renderer.PrintGameField(this.emptyField, false);

            while (playing)
            {
                currentUserInput = renderer.GetUserInput();
                CheckCurrentCommand(currentUserInput);
            }
            
        }

        private void CheckCurrentCommand(string command)
        {
            string clearedCommand = command.Replace(" ", String.Empty);

            //TODO: Implement this method
            if (clearedCommand.Length == 2)
            {
                 currentRow = int.Parse(clearedCommand[0].ToString());
                 currentCol = int.Parse(clearedCommand[1].ToString());

                if (this.field[currentRow, currentCol] == '*')
                {
                    EndGame();
                }
                else
                {
                    OpenNewCell();
                }           
            }
            else
            {
                switch (clearedCommand)
                {
                    case "exit": 
                        this.renderer.PrintQuitMessage();
                        Environment.Exit(1); break;
                    case "restart": 
                        RestartGame(); break;
                    case "top": 
                        throw new NotImplementedException();
                    default:
                        break;
                }
            }
            
        }

        private void EndGame()
        {
            this.emptyField[currentRow, currentCol] = this.field[currentRow, currentCol];
            this.renderer.PrintGameField(this.emptyField, true);
            this.playing = false;
            this.renderer.PrintExplosionMessage(this.openedCells);
            this.currentUserName = this.renderer.GetUserNickname();
            this.scoreBoard.AddPlayer(this.currentUserName, this.currentUserScore);
        }

        private void OpenNewCell()
        {
            this.emptyField[currentRow, currentCol] = this.field[currentRow, currentCol];
            currentUserScore += int.Parse(this.field[currentRow, currentCol].ToString());
            openedCells++;
            this.renderer.PrintGameField(this.emptyField, false);
        }

        private void RestartGame()
        {
            FieldFactory istanceOfFactory = new MinesweeperField();
            this.field = istanceOfFactory.CreateField();
            this.emptyField = new Field(5, 10);
            this.playing = true;
            Play();
        }
    }
}

