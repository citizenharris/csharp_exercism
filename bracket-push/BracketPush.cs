using System;
using System.Collections.Generic;
// using System.Linq;
using System.Text.RegularExpressions;

public static class BracketPush
{
    public static bool IsPaired(string input)
    {

        input = input.Replace(@"[^\{\}\[\]\(\)]", "");
        if (input == "") return true;

        var bracketCount = new Dictionary<char, int>();
        foreach (var bracket in input)
        {
            if (!bracketCount.ContainsKey(bracket)) bracketCount.Add(bracket, 0);
            bracketCount[bracket]++;
        }

        foreach (var item in bracketCount)
        {
            switch (item.Key)
            {
                case '{':
                    if (!bracketCount.ContainsKey('}')) return false;
                    if (item.Value != bracketCount['}']) return false;
                    break;
                case '[':
                    if (!bracketCount.ContainsKey(']')) return false;
                    if (item.Value != bracketCount[']']) return false;
                    break;
                case '(':
                    if (!bracketCount.ContainsKey(')')) return false;
                    if (item.Value != bracketCount[')']) return false;
                    break;
                default:
                    continue;
            }
        }

        var left = new List<char>() { '{', '[', '(' };
        var right = new List<char>() { '}', ']', ')' };
        var indices = new List<int>();

        for (int k = 0; k < 3; k++)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == left[k])
                {
                    var index = input.IndexOf(right[k], i);
                    if (index == -1) return false;
                    if (indices.Contains(index))
                    {
                        for (int j = i; j < input.Length - i; j++)
                        {
                            if (input.IndexOf(right[k], j) == -1) return false;
                            continue;
                        }
                    }
                    indices.Add(input[i]);
                }
            }
        }

        return NextIndexOf(input) != -1;
    }

    public static int NextIndexOf(string input, int startIndex = 0)
    {
        for (int i = startIndex; i < input.Length; i++)
        {
            switch (input[i])
            {
                case '{':
                    if (input.Contains('}')) return input.IndexOf('}', i);
                    continue;
                case '[':
                    if (input.Contains(']')) return input.IndexOf(']', i);
                    continue;
                case '(':
                    if (input.Contains(')')) return input.IndexOf(')', i);
                    continue;
                default:
                    break;
            }
        }
        return -1;
    }
}
