using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        var abbreviation = "";
        Regex.Replace(phrase, @"[^a-zA-Z']+", " ")
             .Split(" ").ToList().ForEach(x => abbreviation += (Char.ToUpper(x.First())));
        return abbreviation;
    }
}