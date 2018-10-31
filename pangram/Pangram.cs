using System.Linq;

public static class Pangram
{
    const string alphabet = "abcdefghijklmnopqrstuvwxyz";
    public static bool IsPangram(string input)
    {
        return alphabet.All(input.ToLower().Contains);
    }
}