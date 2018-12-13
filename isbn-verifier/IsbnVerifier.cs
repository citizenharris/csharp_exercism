using System;

public static class IsbnVerifier
{
    public static bool IsValid(string number)
    {
        var isbn = number.Replace("-", "");
        var length = isbn.Length;
        if (length != 10) return false;

        int[] isbnNums = new int[length];
        for (int i = 0; i < length; i++)
        {
            if (!int.TryParse(isbn[i].ToString(), out int digit))
            {
                if (i != length - 1 || isbn[i] != 'X' && i == length - 1) 
                    return false;
                digit = 10;
            }
            isbnNums[i] = digit;
        }
        return ValidateIsbn(isbnNums);
        
    }

    public static bool ValidateIsbn(int[] isbn)
    {
        int result = 0;
        for (var i = 0; i < isbn.Length; i++)
        {
            result += isbn[i] * (isbn.Length - i);
        }
        return (result) % 11 == 0;
    }

}