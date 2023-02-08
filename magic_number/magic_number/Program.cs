using System;


namespace magic_number
{
    class Program
    {
        static int AskNumber(int Max, int Min)
        {
            int Number = Min - 1;
            while (Number < Min || Number > Max)
            {
                Console.Write("Veuillez rentrer un nombre entre " + Min + " et " + Max + " : ");
                string Number_str = Console.ReadLine();
                try
                {
                    Number = int.Parse(Number_str);
                    if (Number < Min || Number > Max)
                    {
                        Console.WriteLine("ERREUR : ENTREZ UN NOMBRE ENTRE " + Min + " ET " + Max);
                    }
                }
                catch
                {
                    Console.WriteLine("Veuillez rentrer un nombre valide"); 
                }
            }
            return Number;
        }
        static void Main(string[] args)
        {
            Random random= new Random();
            const int NUMBER_MIN = 1;
            const int NUMBER_MAX = 10;
            int MagicNumber = random.Next(NUMBER_MIN, NUMBER_MAX+1);
            int Number = MagicNumber + 1;
           for (int i = 4; i > 0; i--)
            {
                Console.WriteLine("Tu as " + i + "pv");
                Number = AskNumber(NUMBER_MAX, NUMBER_MIN);
                if (MagicNumber < Number)
                {
                    Console.WriteLine("Le nombre magique est plus petit");
                }
                else if (MagicNumber > Number)
                {
                    Console.WriteLine("Le nombre magique est plus grand");
                } else
                {
                    Console.WriteLine("Bravo ! Tu as trouvé le nombre magique");
                    break;
                }
            }
            if (Number!=MagicNumber)
            {
                Console.WriteLine("PERDU\nLe nombre magique était : " + MagicNumber);
            }
            
        }
    }
}