namespace Minesweeper
{
    using System;
    using Contracts;

    public class MinesweeperFieldFactory : FieldFactory
    {
        private const int FieldRows = 5;
        private const int FieldCols = 10;

        /// <summary>
        /// Creates a new minesweeper field and populates it with mines.
        /// </summary>
        /// <returns>An instance of IField</returns>
        public override IField CreateField()
        {
            IField field = new Field(FieldRows, FieldCols);
            IGenerator mineGenerator = new MineGenerator(field);
            IGeneratable mine = new Mine('*');
            IAdjacencyMap mineMap = new MinesweeperAdjacencyMap(field, mine);

            mineGenerator.Generate(mine, FieldRows + FieldCols);
            mineMap.CreateNeighboursMap();

            return field;
        }
    }
}