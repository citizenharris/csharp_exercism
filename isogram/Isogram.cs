using System.Linq;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        if (string.IsNullOrEmpty(word))
            return true;
            
        word = word.ToLower().Replace(" ", "").Replace("-", "");
        return word.Distinct().Count() == word.Count();
    }
}
