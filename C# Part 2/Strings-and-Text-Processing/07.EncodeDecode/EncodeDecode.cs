using System;
using System.Text;

class EncodeDecode
{
    static string Encrypt(string message, string key)
    {
        StringBuilder encryptedMessage = new StringBuilder(message.Length);

        for (int i = 0; i < message.Length; i++)
            encryptedMessage.Append((char)(message[i] ^ key[i % key.Length]));

        return encryptedMessage.ToString();
    }

    static string Decrypt(string message, string key)
    {
        return Encrypt(message, key);
    }

    static void Main()
    {
        Console.Write("Message: ");
        string message = Console.ReadLine();
        Console.Write("key: ");
        string key = Console.ReadLine();

        Console.WriteLine(Encrypt(message, key));
        Console.WriteLine(Decrypt(Encrypt(message,key),key));
    }
}