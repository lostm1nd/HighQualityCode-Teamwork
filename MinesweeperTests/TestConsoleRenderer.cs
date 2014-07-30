namespace MinesweeperTests
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    using Minesweeper;
    using Minesweeper.Contracts;

    [TestClass]
    public class TestConsoleRenderer
    {
        private readonly IRenderer renderer = new ConsoleRenderer();

        [TestMethod]
        public void TestInitialMessage()
        {
            string welcomeMessage = @"Welcome to the game “Minesweeper”." +
                Environment.NewLine +
                "Try to reveal all cells without mines.";

            string commands = @"Use 'top' to view the scoreboard," +
                Environment.NewLine +
                "'restart' to start a new game and 'exit' to quit the game.";

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                renderer.RenderInitialMessage();

                Assert.AreEqual((Environment.NewLine + welcomeMessage + Environment.NewLine + commands + Environment.NewLine), sw.ToString());
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRenderingNullField()
        {
            renderer.RenderGameField(null);
        }

        [TestMethod]
        public void TestRenderingValidField()
        {
            IField field = new Field(5, 10);

            string expected = field.ToString() + Environment.NewLine;

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                renderer.RenderGameField(field);

                Assert.AreEqual(expected, sw.ToString(), "The console renderer must invoke the toString() method of the field.");
            }
        }

        [TestMethod]
        public void TestPrintExplosionMessage()
        {
            int score = 5;
            string expected = String.Format(Environment.NewLine + "Booom! You are killed by a mine!" +
                Environment.NewLine + "You revealed {0} cells without mines.{1}", score, Environment.NewLine);

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                renderer.RenderExplosionMessage(score);

                Assert.IsTrue(sw.ToString().Contains(expected));
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void TestPrintWinnerMessage()
        {
            string expected = Environment.NewLine + "Congratulations! You are the WINNER!" +
                 Environment.NewLine + "Please enter your name for the top scoreboard: " + Environment.NewLine;

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                renderer.RenderWinnerMessage();

                Assert.IsTrue(sw.ToString().Contains(expected));
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestPrintScoreBoardOnNull()
        {
            renderer.RenderScoreBoard(null);
        }

        [TestMethod]
        public void TestPrintInvalidCommandMessage()
        {
            string expected = "Invalid row/col entered! Try again!" + Environment.NewLine;

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                renderer.RenderInvalidCommandMessage();

                Assert.IsTrue(sw.ToString().Contains(expected));
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void TestPrintQuitMessage()
        {
            string expected = Environment.NewLine + "Good bye!" + Environment.NewLine + Environment.NewLine;

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                renderer.RenderQuitMessage();

                Assert.IsTrue(sw.ToString().Contains(expected));
                Assert.AreEqual(expected, sw.ToString());
            }
        }
    }
}

