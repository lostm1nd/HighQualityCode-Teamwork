namespace Minesweeper.Contracts
{
    /// <summary>
    /// Defines the basic functionality ot each field.
    /// </summary>
    public interface IField
    {
        int Rows { get; }

        int Columns { get; }

        char this[int row, int col] { get; set; }

        string ToString();
    }
}
