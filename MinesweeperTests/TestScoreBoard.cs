namespace MinesweeperTests
{
    using System;
    using Minesweeper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestScoreBoard
    {
        [TestMethod]
        public void TestAddPlayerInScoreBoard_ValidInput()
        {
            string playerName = "Pesho";
            int playerScore = 7;
            int currentPlayer = 1;
            string output = Environment.NewLine + "Scoreboard:" + Environment.NewLine +
                currentPlayer + ". " + playerName + " --> " + playerScore + " cells" + Environment.NewLine;

            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.AddPlayer(playerName, playerScore);
            Assert.AreEqual(output, scoreBoard.Generate());

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddPlayerInScoreBoard_NameIsNull()
        {
            int score = 7;

            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.AddPlayer(null, score);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddPlayerInScoreBoard_NameIsEmpty()
        {
            int score = 7;
            string name = string.Empty;

            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.AddPlayer(name, score);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddPlayerInScoreBoard_NameIsOnlyWhiteSpaces()
        {
            int score = 7;
            string name = "  ";

            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.AddPlayer(name, score);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestAddPlayerInScoreBoard_ScoreIsNegative()
        {
            int score = -2;
            string name = "Sasho";

            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.AddPlayer(name, score);
        }

        [TestMethod]
        public void TestGenerateScoreBoard()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.AddPlayer("Sasho", 10);
            scoreBoard.AddPlayer("Pesho", 7);
            scoreBoard.AddPlayer("Tosho", 7);
            scoreBoard.AddPlayer("Gosho", 3);

            string output = Environment.NewLine +
                "Scoreboard:" + Environment.NewLine +
                "1. Sasho --> 10 cells" + Environment.NewLine + 
                "2. Pesho --> 7 cells" + Environment.NewLine +
                "3. Tosho --> 7 cells" + Environment.NewLine +
                "4. Gosho --> 3 cells" + Environment.NewLine;

            Assert.AreEqual(output, scoreBoard.Generate());
        }
    }
}
