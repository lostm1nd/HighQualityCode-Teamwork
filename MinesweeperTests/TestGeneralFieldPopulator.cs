namespace MinesweeperTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Minesweeper;
    using Minesweeper.Contracts;

    [TestClass]
    public class TestGeneralFieldPopulator
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
            this.generator = new GeneralFieldPopulator(field);
            this.item = new CellRepresentor('#');
        }

        [TestMethod]
        public void TestIfTheGeneratorPopulatesTheEntireField()
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

            Assert.IsTrue(isFieldPopulatedEntirely, "The field must be populated with " + (Rows * Columns) + " items.");
        }

        [TestMethod]
        public void TestIfTheGeneratorPopulatesHalfOfTheField()
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