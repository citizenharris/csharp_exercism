using System;
using System.Collections.Generic;
using System.Linq;

public static class ProteinTranslation
{
    private static readonly Dictionary<string, string> _proteins = new Dictionary<string, string>
    {
        {"AUG", "Methionine" },
        {"UUU", "Phenylalanine" },
        {"UUC", "Phenylalanine" },
        {"UUA", "Leucine" },
        {"UUG", "Leucine" },
        {"UCU", "Serine" },
        {"UCC", "Serine" },
        {"UCA", "Serine" },
        {"UCG", "Serine" },
        {"UAU", "Tyrosine" },
        {"UAC", "Tyrosine" },
        {"UGU", "Cysteine" },
        {"UGC", "Cysteine" },
        {"UGG", "Tryptophan" },
        {"UAA", "STOP" },
        {"UAG", "STOP" },
        {"UGA", "STOP" },
    };
    public static string[] Proteins(string strand)
    {
        var proteins = new List<string>();
        for (int i = 0; i < strand.Length; i+= 3)
        {
            var protein = _proteins[strand.Substring(i, 3)];
            if (protein == "STOP")
                break;
            proteins.Add(protein);
        }
        return proteins.ToArray();
    }
}
