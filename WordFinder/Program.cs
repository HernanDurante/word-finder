using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordFinder
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("WORD FINDER");
            Console.WriteLine();
            Console.WriteLine("Press Enter to start or Esc to exit");
            Console.WriteLine();

            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                IEnumerable<string> rndMatrix = GetRandomListOfStrings();
                List<string> matrix = rndMatrix.ToList();
                foreach (string s in matrix)
                {
                    Console.WriteLine(s);
                }         

                Console.WriteLine();
                Console.WriteLine("Please enter a list of words separated by comma and press enter to search");
                string line = Console.ReadLine(); 

                WordFinder finder = new WordFinder(matrix);
                IEnumerable<string> res = finder.Find(line.Split(','));

                Console.WriteLine();

                if (res.Count() > 0)
                {
                    Console.WriteLine("Found:");
                    foreach (string  val in res)
                    {
                        Console.WriteLine(val);
                    }
                }
                else
                {
                    Console.WriteLine("No matches found");
                }

                Console.WriteLine();
                Console.WriteLine("Press Enter to start again or Esc to exit");
                Console.WriteLine();

            }

            Environment.Exit(0);
        }

        public static IEnumerable<string> GetRandomListOfStrings()
        {
            for (int i = 0; i < 9; i++)
            {
                string path = Path.GetRandomFileName();
                path = path.Replace(".", "");
                yield return path;
            }
        }
    }
}
