namespace KrestikiNoliki;

public sealed class Game
{
    private readonly Board board = new();
    private char currentPlayer = 'X';

    public void Run()
    {
        do
        {
            PlayRound();
            Console.Write("Начать новую игру? (д/н): ");
        }
        while ((Console.ReadLine() ?? "").Trim().ToLowerInvariant() == "д");
    }

    private void PlayRound()
    {
        board.Reset();
        currentPlayer = 'X';
        Console.WriteLine("Игра началась. Введите номер клетки от 1 до 9.");
        board.Render();

        while (true)
        {
            Console.Write($"Ход игрока {currentPlayer}: ");
            var input = Console.ReadLine();
            if (!InputValidator.TryReadPosition(input, out var position))
            {
                Console.WriteLine("Ошибка: введите число от 1 до 9.");
                continue;
            }

            if (!board.TryPlace(position, currentPlayer))
            {
                Console.WriteLine("Ошибка: клетка уже занята.");
                continue;
            }

            board.Render();
            if (WinChecker.HasWinner(board, currentPlayer))
            {
                Console.WriteLine($"Игрок {currentPlayer} победил!");
                break;
            }

            if (board.IsFull)
            {
                Console.WriteLine("Ничья!");
                break;
            }

            currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
        }
    }
}
