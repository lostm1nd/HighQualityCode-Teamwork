namespace Minesweeper
{
    using System;
    using Contracts;

    public class Mine : IGeneratable
    {
        private char symbol;

        public Mine(char symbol)
        {
            this.Symbol = symbol;
        }

        public char Symbol
        {
            get { return this.symbol; }
            private set { this.symbol = value; }
        }
    }
}
