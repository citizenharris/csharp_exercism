using System;
using System.Collections.Generic;
using System.Linq;

public class Anagram
{
    private string _anagram { get; set; }
    public Anagram(string baseWord) => _anagram = baseWord.ToLower();

    public string[] FindAnagrams(string[] potentialMatches)
    {
        List<string> output = new List<string>();
        foreach (var item in potentialMatches)
        {
            if (ValidateMatch(item)) output.Add(item);
        }
        return output.ToArray();
    }

    public bool ValidateMatch(string potentialMatch)
    {
        if (potentialMatch.ToLower() == _anagram || potentialMatch.Length != _anagram.Length)
            return false;
        return BreakWord(potentialMatch) == BreakWord(_anagram);
    }

    public string BreakWord(string word) => 
        String.Join("", word.ToLower()
                            .OrderBy(a => a)
                            .ToArray());
}