namespace MinesweeperTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Minesweeper;
    using Minesweeper.Contracts;

    [TestClass]
    public class TestMineField
    {
        private FieldFactory mineFieldFactory;
        private IField mineField;

        [TestInitialize()]
        public void InitializeMineFieldTests()
        {
            this.mineFieldFactory = new MinesweeperFieldFactory();
            this.mineField = mineFieldFactory.CreateField();
        }

        [TestMethod]
        public void TestIfMineFieldIsCreatedWithProperAmoutOfRows()
        {
            int expectedRows = 5;

            Assert.AreEqual(expectedRows, mineField.Rows, "Rows should be 5");
        }

        [TestMethod]
        public void TestIfMineFieldIsCreatedWithProperAmoutOfColumns()
        {
            int expectedCols = 10;

            Assert.AreEqual(expectedCols, mineField.Columns, "Columns should be 10");
        }

        [TestMethod]
        public void TestIfMineFieldIsCreatedWithProperAmoutOfMines()
        {
            int expectedMinesCount = 15;
            int actualMinesCount = 0;

            for (int i = 0; i < mineField.Rows; i++)
            {
                for (int j = 0; j < mineField.Columns; j++)
                {
                    if (mineField[i, j] == '*')
                    {
                        actualMinesCount++;
                    }
                }
            }

            Assert.AreEqual(expectedMinesCount, actualMinesCount, "Mines should be 15");
        }
    }
}