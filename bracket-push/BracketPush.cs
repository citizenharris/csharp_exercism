using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class BracketPush
{
    public static bool IsPaired(string input)
    {
        input = Regex.Replace(input, @"[^\{\}\[\]\(\)]", "");
        if (input == "") return true;
        if (input.Length % 2 != 0) return false;

        var matches = new List<Bracket>();
        foreach (var c in input)
        {
            if (IsLeftBracket(c)) 
                matches.Add(new Bracket(c, true));
            else 
            {
                for (int i = matches.Count - 1; i >= 0; i--)
                {
                    if (matches[i].IsOpen)
                    {
                        if (IsSameBracket(matches[i].BracketType, c))
                        {
                            matches[i].IsOpen = false;
                            break;
                        } else 
                            return false;
                    } else
                        continue;
                }
            }
        }
        return IsLeftBracket(input[0]) && (input.Length / 2 == matches.Count);
    }

    public static bool IsLeftBracket(char bracket) => bracket == '[' || bracket == '{' || bracket == '(';

    public static bool IsSameBracket(char leftBracket, char rightBracket) {
        switch (rightBracket)
        {
            case ']':
                return leftBracket == '[';
            case '}':
                return leftBracket == '{';
            case ')':
                return leftBracket == '(';
            default:
                return false;
        }
    }
}

public class Bracket
{
    public char BracketType { get; set; }
    public bool IsOpen { get; set; }
    
    public Bracket(char bracketType, bool isOpen)
    {
        BracketType = bracketType;
        IsOpen = isOpen;
    }
}