namespace Minesweeper
{
    using System;

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

        public char Produce()
        {
            throw new NotImplementedException();
        }
    }
}
