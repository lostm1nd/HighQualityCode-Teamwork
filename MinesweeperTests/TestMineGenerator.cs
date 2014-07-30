namespace MinesweeperTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Minesweeper;
    using Minesweeper.Contracts;

    [TestClass]
    public class TestMineGenerator
    {
        private const int Rows = 10;
        private const int Columns = 10;

        private IField field;
        private IGenerator generator;
        private IGeneratable item;

        [TestInitialize()]
        public void InitializeMineFieldTests()
        {
            this.field = new Field(Rows, Columns);
            this.generator = new MineGenerator(this.field);
            this.item = new Mine('$');
        }

        [TestMethod]
        public void TestIfTheMineGeneratorPopulatesTheEntireField()
        {
            this.generator.Generate(this.item, Rows * Columns);

            bool isFieldPopulatedEntirely = true;

            for (int i = 0; i < this.field.Rows; i++)
            {
                for (int j = 0; j < this.field.Columns; j++)
                {
                    if (this.field[i, j] != this.item.Symbol)
                    {
                        isFieldPopulatedEntirely = false;
                        break;
                    }
                }

                if (!isFieldPopulatedEntirely)
                {
                    break;
                }
            }

            Assert.IsTrue(isFieldPopulatedEntirely, "The mine field must be populated with " + (Rows * Columns) + " items.");
        }

        [TestMethod]
        public void TestIfTheMineGeneratorPopulatesHalfOfTheField()
        {
            this.generator.Generate(this.item, (Rows * Columns) / 2);

            int expectedItemCount = (Rows * Columns) / 2;
            int actualItemCount = 0;

            for (int i = 0; i < this.field.Rows; i++)
            {
                for (int j = 0; j < this.field.Columns; j++)
                {
                    if (this.field[i, j] == this.item.Symbol)
                    {
                        actualItemCount++;
                    }
                }
            }

            Assert.AreEqual(expectedItemCount, actualItemCount, "The field must be populated with " + ((Rows * Columns) / 2) + " items.");
        }
    }
}