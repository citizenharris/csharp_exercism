using System;

public static class ErrorHandling
{
    public static void HandleErrorByThrowingException() => throw new Exception("An error occurred");

    public static int? HandleErrorByReturningNullableType(string input)
    {
        if (!int.TryParse(input, out int result))
        {
            return null;
        }
        else
        {
            return result;
        }
    }

    public static bool HandleErrorWithOutParam(string input, out int result) => int.TryParse(input, out result);

    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject)
    {
        using(disposableObject)
        {
            throw new Exception("Something went wrong.");
        }
    }
}
