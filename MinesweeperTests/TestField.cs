namespace MinesweeperTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Minesweeper;
    using Minesweeper.Contracts;

    [TestClass]
    public class TestField
    {
        private IField field;

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIfFieldCanBeCreatedWithLessThanFiveRows()
        {
            this.field = new Field(4, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIfFieldCanBeCreatedWithLessThanFiveColumns()
        {
            this.field = new Field(5, 4);
        }

        [TestMethod]
        public void TestIfFieldIsCreatedWithProperAmoutRowsAndColumns()
        {
            int rows = 255;
            int cols = 255;

            this.field = new Field(rows, cols);

            Assert.AreEqual(rows, this.field.Rows, "Rows must be 255");
            Assert.AreEqual(cols, this.field.Columns, "Columns must be 255");
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestIfAnErrorIsThrownWhenAccessingInvalidRowIndex()
        {
            this.field = new Field(10, 10);

            this.field[11, 10] = 'A';
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestIfAnErrorIsThrownWhenAccessingInvalidColumnIndex()
        {
            this.field = new Field(10, 10);

            this.field[8, 11] = 'A';
        }
    }
}