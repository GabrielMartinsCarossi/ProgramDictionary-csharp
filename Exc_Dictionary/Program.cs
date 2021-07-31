using System;
using System.Collections.Generic;
using System.IO;

namespace Exc_Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            //Reads File (in.csv) Path
            Console.WriteLine("Enter file full path: ");
            string path = Console.ReadLine();

            Dictionary<string, int> candidates = new Dictionary<string, int>();

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');
                        string name = line[0];
                        int votes = int.Parse(line[1]);
                        if (candidates.ContainsKey(name))
                        {
                            candidates[name] += votes;
                        }
                        else
                        {
                            candidates[name] = votes;
                        }
                        
                    }

                    //Prints votes
                    foreach (KeyValuePair<string, int> candidate in candidates)
                    {
                        Console.WriteLine(candidate.Key + ": " + candidate.Value);

                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(e.Message);
            }
        }
    }
}
