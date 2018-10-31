using System;
using System.Text.RegularExpressions;

public static class Bob
{
    public static string Response(string statement)
    {
        statement.Trim();
        switch(statement)
        {
            case var val when new Regex(@"^[\s]*$").IsMatch(val):
                return "Fine. Be that way!";
            case var val when new Regex(@"^[A-Z\s]+\?$").IsMatch(val):
                return "Calm down, I know what I'm doing!";
            case var val when new Regex(@"\?[\s]*$").IsMatch(val):
                return "Sure.";
            case var val when new Regex(@"^[A-Z]{1,}[^a-z]+$").IsMatch(val):
                return "Whoa, chill out!";
            default:
                return "Whatever.";
        } 
    }
}
