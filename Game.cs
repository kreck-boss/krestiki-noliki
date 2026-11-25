namespace KrestikiNoliki;

public sealed class Game
{
    private readonly Board board = new();
    private char currentPlayer = 'X';

    public void Run()
    {
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
            break;
        }
    }
}
