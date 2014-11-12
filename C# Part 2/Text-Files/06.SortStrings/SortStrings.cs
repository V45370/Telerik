using System;
using System.IO;
using System.Collections.Generic;

class SortStrings
{
    /*
     * Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file. 
     * Example:
	 * Ivan		    	George
	 * Peter			Ivan
	 * Maria			Maria
	 * George	        Peter
     */

    static void Main()
    {
        using (StreamReader reader = new StreamReader("names.txt"))
        {
            List<string> names = new List<string>();

            for (string currentName = reader.ReadLine(); currentName != null; currentName = reader.ReadLine())
            {
                names.Add(currentName);
            }

            names.Sort();

            using (StreamWriter writer = new StreamWriter("sorted_names.txt"))
            {
                foreach (string name in names) writer.WriteLine(name);
            }
        }
    }
}