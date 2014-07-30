namespace MinesweeperTests
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Minesweeper;
    using Minesweeper.Contracts;

    [TestClass]
    public class TestConsoleReader
    {
        private readonly IReadInput reader = new ConsoleReader();

        [TestMethod]
        public void TestGetUserNickname()
        {
            string expected = "Please enter your name: " + Environment.NewLine;
            string input = "ThePlayer";

            using (StringWriter sw = new StringWriter())
            using (StringReader sr = new StringReader(input))
            {
                Console.SetOut(sw);

                Console.SetIn(sr);

                reader.GetUserNickname();

                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void TestGetUserInputWithValidInput()
        {
            string expected = "Enter row and column: ";
            string input = "12";

            using (StringWriter sw = new StringWriter())
            using (StringReader sr = new StringReader(input))
            {
                Console.SetOut(sw);

                Console.SetIn(sr);

                reader.GetUserInput();

                sr.ReadLine();

                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void TestGetUserInputWithLessThanExpectedCharacters()
        {
            string expected = "Enter row and column: " + "Numbers should be two - one for row and one for column." + Environment.NewLine;
            string input = "1";

            using (StringWriter sw = new StringWriter())
            using (StringReader sr = new StringReader(input))
            {
                Console.SetOut(sw);

                Console.SetIn(sr);

                reader.GetUserInput();

                sr.ReadLine();

                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void TestGetUserInputWithMoreThanExpectedCharacters()
        {
            string expected = "Enter row and column: " + "Numbers should be two - one for row and one for column." + Environment.NewLine;
            string input = "1";

            using (StringWriter sw = new StringWriter())
            using (StringReader sr = new StringReader(input))
            {
                Console.SetOut(sw);

                Console.SetIn(sr);

                reader.GetUserInput();

                sr.ReadLine();

                Assert.AreEqual(expected, sw.ToString());
            }
        }
    }
}
