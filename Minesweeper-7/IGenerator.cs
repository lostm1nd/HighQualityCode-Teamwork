namespace Minesweeper
{
    public interface IGenerator
    {
        void Generate(IField field, int itemsToGenerateCount);
    }
}
