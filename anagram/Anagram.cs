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
            if (item.ToLower() != _anagram && item.Length == _anagram.Length && _anagram.All(item.ToLower().Contains))                output.Add(item);
        }
        return output.ToArray();
    }
}