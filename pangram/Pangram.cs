﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        if(input == "" || input.Length < 26)
        {
        	return false;
        }

        Dictionary<string, int> letterUsage = new Dictionary<string, int>();
        
        foreach(var letter in input.ToLower())
        {
        	string letterStr = letter.ToString();
        	if(Regex.IsMatch(letterStr, @"[a-z]+"))
        	{
        		if(letterUsage.ContainsKey(letterStr))
        		{
        			letterUsage[letterStr]++;	
        		}
        		else
        		{
	        		letterUsage.Add(letterStr, 1);
        		}
        	}
        }

        return letterUsage.Count < 26 ? false : true;
    }
}