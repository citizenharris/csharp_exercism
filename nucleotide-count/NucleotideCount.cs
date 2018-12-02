using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        
        if (new Regex(@"[^ACGT]").IsMatch(sequence)) 
            throw new ArgumentException("Contains invalid nucleotides");
        
        var output = new Dictionary<char, int>
        {
            ['A'] = 0,
            ['C'] = 0,
            ['G'] = 0,
            ['T'] = 0
        };
        foreach (var c in sequence)
        {
            output[c] += 1;
        }
        return output;
    }
}