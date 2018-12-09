using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class WordCount
{
    public static IDictionary<string, int> CountWords(string phrase)
    {
        string[] words = FormatPhrase(phrase);

        Dictionary<string, int> wordCount = new Dictionary<string, int>();
        foreach (var word in words)
        {
            if (String.IsNullOrWhiteSpace(word)) continue;
            if (!wordCount.ContainsKey(word))
            {
                wordCount.Add(word, 1);
            }
            else
            {
                wordCount[word]++;
            }
        }

        return wordCount;
    }

    private static string[] FormatPhrase(string phrase)
    {
        var words = Regex.Split(phrase.ToLower(), @"[^(\w'\w)]");

        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];
            if (Regex.IsMatch(word, @"'.+'")) words[i] = word.Replace("'", "");
        }

        return words;
    }
}