using System;

public static class IsbnVerifier
{
    public static bool IsValid(string number)
    {
        var isbn = number.Replace("-", "");
        
        int[] isbnNums = new int[isbn.Length];
        for (int i = 0; i <= isbn.Length; i++)
        {
            if (!int.TryParse(isbn[i].ToString(), out int digit))
            {
                if (isbn[i] == 'X')
                {
                    isbnNums[i] = 10;
                    continue;
                }
                return false;
            }
            isbnNums[i] = digit;
        }
        return ValidateIsbn(isbnNums);
        
    }

    public static bool ValidateIsbn(int[] isbn)
    {
        int result = 0;
        for (int i = 0; i < isbn.Length; i++)
        {
            result += isbn[i] * (isbn.Length - i);
        }
        return (result) % 11 == 0;
    }

}