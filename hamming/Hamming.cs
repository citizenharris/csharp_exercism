using System;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {

    	if(firstStrand == "" || secondStrand == "")
    	{
    		return 0;
    	}

        if(firstStrand.Equals(secondStrand))
        {
        	return 0;
        }

        if(firstStrand.Length != secondStrand.Length)
        {
        	throw new ArgumentException();
        }

        int distance = 0;

        for(var i = 0; i < firstStrand.Length; i++)
        {
        	if(firstStrand[i] != secondStrand[i])
        	{
        		distance += 1;
        	}
        }

        return distance;
    }
}