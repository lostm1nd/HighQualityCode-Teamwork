namespace MinesweeperTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Minesweeper;
    using Minesweeper.Contracts;

    [TestClass]
    public class TestPlayingField
    {
        private FieldFactory playingFieldFactory;
        private IField playingField;

        [TestInitialize()]
        public void InitializeMineFieldTests()
        {
            this.playingFieldFactory = new PlayingFieldFactory();
            this.playingField = playingFieldFactory.CreateField();
        }

        [TestMethod]
        public void TestIfPlayingFieldIsCreatedWithProperAmoutOfRows()
        {
            int expectedRows = 5;

            Assert.AreEqual(expectedRows, playingField.Rows, "Rows should be 5");
        }

        [TestMethod]
        public void TestIfPlayingFieldIsCreatedWithProperAmoutOfColumns()
        {
            int expectedCols = 10;

            Assert.AreEqual(expectedCols, playingField.Columns, "Columns should be 10");
        }

        [TestMethod]
        public void TestIfThePlayingFieldIfFilledWithQuestionMarks()
        {
            bool isEntireFieldObscured = true;

            for (int i = 0; i < playingField.Rows; i++)
            {
                for (int j = 0; j < playingField.Columns; j++)
                {
                    if (playingField[i, j] != '?')
                    {
                        isEntireFieldObscured = false;
                        break;
                    }
                }

                if (!isEntireFieldObscured)
                {
                    break;
                }
            }

            Assert.IsTrue(isEntireFieldObscured, "The entire field should be displayed with question marks (?)");
        }
    }
}