using System;


class CopyrightSymbolTriangle
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.UTF8Encoding.Unicode;   //Open Command Prompt ->Properties->Fonts->Lucida Console      
        char a = '\u00A9';


        Console.WriteLine("   {0}\n  {0} {0}\n {0}   {0}\n{0} {0} {0} {0}\n", a);
        
    }
}

 