namespace Minesweeper
{
    using System;
    using System.Text;
    using Contracts;

    public class Field : IField
    {
        private char[,] field;

        /// <summary>
        /// Create a minefield with a specific size.
        /// </summary>
        /// <param name="rows">The row count of the minefield</param>
        /// <param name="columns">The column count of the minefield</param>
        public Field(int rows, int columns)
        {
            ValidateAndInitializeField(rows, columns);
        }

        /// <summary>
        /// Get the row count of the minefield
        /// </summary>
        public int Rows
        {
            get { return this.field.GetLength(0); }
        }

        /// <summary>
        /// Get the column count of the minefield
        /// </summary>
        public int Columns
        {
            get { return this.field.GetLength(1); }
        }

        /// <summary>
        /// Gets or sets the character in the specified cell
        /// </summary>
        /// <param name="row">The number of the rows</param>
        /// <param name="col">The number of the columns</param>
        /// <returns>The character that is in the specified cell</returns>
        public char this[int row, int col]
        {
            get
            {
                ValidateIndexes(row, col);

                return this.field[row, col];
            }

            set
            {
                ValidateIndexes(row, col);

                this.field[row, col] = value;
            }
        }

        /// <summary>
        /// String representation of the field
        /// </summary>
        /// <returns>The field as a string</returns>
        public override string ToString()
        {
            StringBuilder stringifyField = new StringBuilder();

            Console.WriteLine();
            Console.WriteLine();
            
            stringifyField.AppendLine("    0 1 2 3 4 5 6 7 8 9");
            stringifyField.AppendLine("   ----------------------");

            for (int row = 0; row < this.Rows; row++)
            {
                stringifyField.Append(row + " | ");
                for (int col = 0; col < this.Columns; col++)
                {
                    stringifyField.Append(this.field[row, col] + " ");
                }
                stringifyField.AppendLine("|");
            }

            stringifyField.AppendLine("   ----------------------");

            return stringifyField.ToString();
        }

        private void ValidateIndexes(int row, int col)
        {
            if (row < 0 || row >= this.Rows)
            {
                // Console.WriteLine("No such row ");
                throw new IndexOutOfRangeException("Rows are in range [0, " + this.Rows + ")");
            }

            if (col < 0 || col >= this.Columns)
            {
                // Console.WriteLine("No such column.");
                throw new IndexOutOfRangeException("Columns are in range [0, " + this.Columns + ")");
            }
            
        }

        private void ValidateAndInitializeField(int rows, int cols)
        {
            if (rows < 5)
            {
                throw new ArgumentException("The rows must be at least 5.");
            }

            if (cols < 5)
            {
                throw new ArgumentException("The columns must be at least 5.");
            }

            this.field = new char[rows, cols];
        }
    }
}
