using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationCS
{
    static class Tools
    {
        public static int CheckNumberPositive(string question)
        {
            int number = AskNumber(question);
            if (number > 0)
            {
                return number;
            }
            Console.WriteLine("ERREUR : Le nombre doit être strictement positif");
            Console.WriteLine();

            return CheckNumberPositive(question);
        }

        public static int CheckNumberBetween(string question, int min, int max)
        {
            int number = AskNumber(question);
            if (number >= min && number <= max)
            {
                return number;
            }
            Console.WriteLine("ERREUR : Le nombre doit être entre" + min + "et" + max);
            Console.WriteLine();

            return CheckNumberBetween(question, min, max);
        }

        public static int AskNumber(string question)
        {
            while (true)
            {
                Console.Write(question);
                string response_str = Console.ReadLine();
                try
                {
                    int response = int.Parse(response_str);
                    return response;
                }
                catch
                {
                    Console.WriteLine("ERREUR UNIQUEMENT DES NOMBRES");
                    Console.WriteLine();
                }
            }
        }
    }
}
