using System;

public static class ClsTools
{
    public static string DecryptText(string text, short encryptionKey = (short)(3 * 12 - 17))
    {
        char[] chars = text.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            chars[i] = (char)(chars[i] - encryptionKey);
        }
        return new string(chars);
    }
    public static string EncryptText(string text, short encryptionKey = (short)(3 * 12 - 17))
    {
        char[] chars = text.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            chars[i] = (char)(chars[i] + encryptionKey);
        }
        return new string(chars);
    }

}

