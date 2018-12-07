using System;
using System.Text.RegularExpressions;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        const string alphabet = "abcdefghijklmnopqrstuvwxyz";
        var output = string.Empty;
        
        foreach (var letter in text)
        {
            if (new Regex(@"[^a-zA-Z]").IsMatch(letter.ToString())) 
            {
                output += letter;
                continue;
            }
            var index = shiftKey != 26 ? 
                alphabet.IndexOf(Char.ToLower(letter)) + shiftKey : 
                0;
            if (index >= 26) index -= 26;
            output += Char.IsUpper(letter) ? Char.ToUpper(alphabet[index]) : alphabet[index];
        }
        
        return output;
    }
}