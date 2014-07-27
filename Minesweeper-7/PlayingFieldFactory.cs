namespace Minesweeper
{
    using System;
    using Contracts;

    public class PlayingFieldFactory : FieldFactory
    {
        private const int FieldRows = 5;
        private const int FieldCols = 10;

        /// <summary>
        /// Creates a new playing field which the player interacts with.
        /// </summary>
        /// <returns>An instance of IField</returns>
        public override IField CreateField()
        {
            IField field = new Field(FieldRows, FieldCols);
            IGenerator fieldPopulator = new GeneralFieldPopulator(field);
            IGeneratable cellRepresentor = new CellRepresentor('?');

            fieldPopulator.Generate(cellRepresentor, field.Rows * field.Columns);

            return field;
        }
    }
}
