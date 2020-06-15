using System;
using System.Linq;

public class SimpleCipher
{
    const string alphabet = "abcdefghijklmnopqrstuvwxyz";

    public SimpleCipher()
    {
        var rand = new Random();
        var randomKey = "";
        for (int i = 0; i < 100; i++)
            randomKey += alphabet[rand.Next(0, 25)];
        Key = randomKey;
    }

    public SimpleCipher(string key)
    {
        Key = key;
    }
    
    public string Key { get; private set; }

    public string Encode(string plaintext)
    {
        var encoded = "";
        for (int i = 0; i < plaintext.Length; i++)
        {
            var cipherIndex = alphabet.IndexOf(Key[i % Key.Length]);
            var index = alphabet.IndexOf(plaintext[i]) + cipherIndex;
            var encodedIndex = index > 25 ? index % 25 - 1 : index;
            encoded += alphabet[encodedIndex];
        }
        return encoded;
    }

    public string Decode(string ciphertext)
    {
        var decoded = "";
        for (int i = 0; i < ciphertext.Length; i++)
        {
            var cipherIndex = alphabet.IndexOf(Key[i % Key.Length]);
            var index = alphabet.IndexOf(ciphertext[i]) - cipherIndex;
            var encodedIndex = index < 0 ? 26 + index : index;
            decoded += alphabet[encodedIndex];
        }
        return decoded;
    }
}