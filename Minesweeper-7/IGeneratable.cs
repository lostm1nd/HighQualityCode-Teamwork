namespace Minesweeper
{
    public interface IGeneratable
    {
        char Symbol { get; }

        char Produce();
    }
}
