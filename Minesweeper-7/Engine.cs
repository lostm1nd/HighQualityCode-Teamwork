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
        private readonly IRenderer renderer;
        private readonly IReadInput inputReader;
        private readonly IScoreBoard scoreBoard;
        private IField mineField;
        private IField playingField;

        private bool playing;

        private string currentUserName;
        private string currentUserInput;

        private int currentUserScore;
        private int openedCells;
        private int currentRow;
        private int currentCol;

        public Engine(IField mineField, IField playingField, IRenderer renderer, IReadInput inputReader)
        {
            this.renderer = renderer;
            this.inputReader = inputReader;
            this.scoreBoard = new ScoreBoard();

            this.playingField = playingField;
            this.mineField = mineField;

            this.playing = true;
            this.currentUserName = "Player";
            this.currentUserScore = 0;
            this.openedCells = 0;
        }

        public void Play()
        {
            //TODO: Implement the main playing logic of the game.
            this.renderer.RenderInitialMessage();
            this.renderer.RenderGameField(this.playingField, false);

            while (playing)
            {
                currentUserInput = this.inputReader.GetUserInput();
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

                if (this.mineField[currentRow, currentCol] == '*')
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
                        this.renderer.RenderQuitMessage();
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
            this.playingField[currentRow, currentCol] = this.mineField[currentRow, currentCol];
            this.renderer.RenderGameField(this.playingField, true);
            this.playing = false;
            this.renderer.RenderExplosionMessage(this.openedCells);
            this.currentUserName = this.inputReader.GetUserNickname();
            this.scoreBoard.AddPlayer(this.currentUserName, this.currentUserScore);
        }

        private void OpenNewCell()
        {
            this.playingField[currentRow, currentCol] = this.mineField[currentRow, currentCol];
            currentUserScore += int.Parse(this.mineField[currentRow, currentCol].ToString());
            openedCells++;
            this.renderer.RenderGameField(this.playingField, false);
        }

        private void RestartGame()
        {
            FieldFactory istanceOfFactory = new MinesweeperField();
            this.mineField = istanceOfFactory.CreateField();
            this.playingField = new Field(5, 10);
            this.playing = true;
            Play();
        }
    }
}

