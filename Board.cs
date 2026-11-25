namespace KrestikiNoliki;

public sealed class Board
{
    public const int Size = 3;
    private readonly char[,] cells = new char[Size, Size];

    public Board()
    {
        Reset();
    }

    public bool TryPlace(int position, char symbol)
    {
        if (position < 1 || position > Size * Size)
        {
            return false;
        }

        var row = (position - 1) / Size;
        var column = (position - 1) % Size;
        if (cells[row, column] != ' ')
        {
            return false;
        }

        cells[row, column] = symbol;
        return true;
    }

    public bool IsFull => cells.Cast<char>().All(cell => cell != ' ');

    public bool HasWinner(char symbol)
    {
        var lines = new[]
        {
            new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 7, 8, 9 },
            new[] { 1, 4, 7 }, new[] { 2, 5, 8 }, new[] { 3, 6, 9 },
            new[] { 1, 5, 9 }, new[] { 3, 5, 7 }
        };
        return lines.Any(line => line.All(position => GetCell(position) == symbol));
    }

    public char GetCell(int position)
    {
        if (position < 1 || position > Size * Size)
        {
            throw new ArgumentOutOfRangeException(nameof(position));
        }

        var row = (position - 1) / Size;
        var column = (position - 1) % Size;
        return cells[row, column];
    }

    public void Reset()
    {
        for (var row = 0; row < Size; row++)
        {
            for (var column = 0; column < Size; column++)
            {
                cells[row, column] = ' ';
            }
        }
    }

    public void Render()
    {
        Console.WriteLine();
        for (var row = 0; row < Size; row++)
        {
            var values = new string[Size];
            for (var column = 0; column < Size; column++)
            {
                var position = row * Size + column + 1;
                values[column] = cells[row, column] == ' '
                    ? position.ToString()
                    : cells[row, column].ToString();
            }

            Console.WriteLine($" {values[0]} | {values[1]} | {values[2]} ");
            if (row < Size - 1)
            {
                Console.WriteLine("---+---+---");
            }
        }
        Console.WriteLine();
    }
}
