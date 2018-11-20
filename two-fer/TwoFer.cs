using System;

  public static class TwoFer
  {
      public static string Name(string input = null)
      {
          return string.IsNullOrEmpty(input) ? "One for you, one for me." : $"One for {input}, one for me.";
      }
  }
