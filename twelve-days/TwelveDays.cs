using System;
using System.Collections.Generic;

public static class TwelveDays
{
    private static string verse = "On the __Number__ day of Christmas my true love gave to me: ";
    private static List<Verse> things = new List<Verse>() 
    {
        new Verse("first", "a Partridge in a Pear Tree"),
        new Verse("second", "two Turtle Doves, "),
        new Verse("third", "three French Hens, "),
        new Verse("fourth", "four Calling Birds, "),
        new Verse("fifth", "five Gold Rings, "),
        new Verse("sixth", "six Geese-a-Laying, "),
        new Verse("seventh", "seven Swans-a-Swimming, "),
        new Verse("eighth", "eight Maids-a-Milking, "),
        new Verse("ninth", "nine Ladies Dancing, "),
        new Verse("tenth", "ten Lords-a-Leaping, "),
        new Verse("eleventh", "eleven Pipers Piping, "),
        new Verse("twelfth", "twelve Drummers Drumming, ")
    };
    public static string Recite(int verseNumber)
    {
        string firstHalf = verse.Replace("__Number__", things[verseNumber - 1].Number);
        string secondHalf = "";
        for (int i = verseNumber - 1; i >= 0; i--)
        {
            secondHalf += i == 0 && verseNumber > 1 ? $"and {things[i].Present}" : things[i].Present;
        }
        return $"{firstHalf}{secondHalf}.";
    }

    public static string Recite(int startVerse, int endVerse)
    {
        string verses = "";
        for (int i = startVerse; i <= endVerse; i++)
        {
            verses += i == endVerse ? $"{Recite(i)}" : $"{Recite(i)}\n";
        }
        return verses;

    }

    public class Verse
    {
        public Verse(string number, string present)
        {
            Number = number;
            Present = present;
        }

        public string Number { get; set; }
        public string Present { get; set; }
    }
}