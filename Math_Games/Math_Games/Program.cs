namespace Math_Games
{
    internal class Program
    {
        enum e_Operateur
        {
            ADDITION = 1,
            MULTIPLICATION = 2,
            DIVISION = 3,
            SUBSTRACTION = 4,
        }
        static bool AskQuestion(int Min, int Max)
        {
            Random random = new Random();
            while (true)
            {
                int firstValue = random.Next(Min, Max);
                int secondValue = random.Next(Min, Max);
                e_Operateur operatorValue = (e_Operateur)random.Next(1, 5);
                int expectResult;
                switch(operatorValue)
                {
                    case e_Operateur.ADDITION:
                        Console.Write("Calculer le résultat du calcul suivant :\n"+ firstValue + " + " + secondValue + " = ? ");
                        expectResult= firstValue + secondValue;
                    break;
                    case e_Operateur.MULTIPLICATION:
                        Console.Write("Calculer le résultat du calcul suivant :\n" + firstValue + " x " + secondValue + " = ? ");
                        expectResult = firstValue * secondValue;
                    break;
                    case e_Operateur.SUBSTRACTION:
                        Console.Write("Calculer le résultat du calcul suivant :\n" + firstValue + " - " + secondValue + " = ? ");
                        expectResult = firstValue - secondValue;
                    break;
                    case e_Operateur.DIVISION:
                        Console.Write("Calculer le résultat du calcul suivant :\n" + firstValue + " / " + secondValue + " = ? ");
                        expectResult = firstValue / secondValue;
                    break;
                    default:
                        Console.WriteLine("Opérateur non prévue");
                        return false;
                    break;
                }
                string response_str = Console.ReadLine();
                try
                {
                    int response = int.Parse(response_str);
                    if (response == expectResult)
                    {
                        return true;
                    }
                    return false;
                }
                catch
                {
                    Console.WriteLine("ERREUR UNIQUEMENT DES NOMBRES");
                }
            }
        }
        static void Main(string[] args)
        {
            const int MIN_VALUE = 1;
            const int MAX_VALUE = 10;
            int NbQuestion = 10;
            int NbPoint = 0;

            for (int i = 1 ; i <= NbQuestion; i++)
            {
                Console.WriteLine("Question n°" + i + "/" + NbQuestion);

                bool response = AskQuestion(MIN_VALUE, MAX_VALUE);
                if (response)
                {
                    Console.WriteLine("Bonne réponse");
                    NbPoint++;
                }
                else
                {
                    Console.WriteLine("Mauvaise réponse");
                }
                Console.WriteLine("Vous avez "+NbPoint+ "/" + NbQuestion+" points");
            }
            if (NbPoint == NbQuestion)
            {
                Console.WriteLine("Excellent");
            } 
            else if(NbPoint == 0) 
            {
                Console.WriteLine("Révisez vos maths");
            } 
            else if(NbPoint > NbQuestion/2) 
            {
                Console.WriteLine("Pas mal");
            } 
            else
            {
                Console.WriteLine("Peut mieux faire");
            }
            
        }
    }
}
