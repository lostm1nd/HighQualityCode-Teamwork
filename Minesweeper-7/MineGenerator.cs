namespace Minesweeper
{
    public class MineGenerator : IGenerator
    {
        private IGeneratable mine;

        public MineGenerator(IGeneratable mine)
        {
            this.mine = mine;
        }

        public void Generate(IField field, int minesToGenerateCount)
        {
            int generatedMines = 0;

            while (generatedMines < minesToGenerateCount)
            {
                int rowToPutMine = RandomNumber.Get(field.Rows);
                int colToPutMine = RandomNumber.Get(field.Columns);

                if (field[rowToPutMine, colToPutMine] != this.mine.Symbol)
                {
                    field[rowToPutMine, colToPutMine] = this.mine.Symbol;
                    generatedMines++;
                }
            }
        }
    }
}
