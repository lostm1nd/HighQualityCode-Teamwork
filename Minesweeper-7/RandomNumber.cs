namespace Minesweeper
{
    using System;

    public static class RandomNumber
    {
        static readonly Random Generator = new Random();
        
        public static int Get(int maxNumber)
        {
            int number = Generator.Next(maxNumber);
            return number;
        }

        public static int Get(int minNumber, int maxNumber)
        {
            int number = Generator.Next(minNumber, maxNumber);
            return number;
        }
    }
}
