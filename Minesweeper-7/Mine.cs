namespace Minesweeper
{
    using System;
    using Contracts;

    public class Mine : IGeneratable
    {
        private char symbol;

        /// <summary>
        /// Initilizes a new instance of the <see cref="Mine"/> class.
        /// </summary>
        /// <param name="symbol">The symbol to represent the mine</param>
        public Mine(char symbol)
        {
            this.Symbol = symbol;
        }

        /// <summary>
        /// Gets the symbol that represents this mine instance
        /// </summary>
        public char Symbol
        {
            get { return this.symbol; }
            private set { this.symbol = value; }
        }
    }
}
