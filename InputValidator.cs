namespace KrestikiNoliki;

public static class InputValidator
{
    public static bool TryReadPosition(string? input, out int position)
    {
        return int.TryParse(input, out position) && position is >= 1 and <= 9;
    }
}
