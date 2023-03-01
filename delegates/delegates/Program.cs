namespace delegates
{
    internal class Program
    {
        public delegate string ValidString(string s);
        static void Main(string[] args)
        {
            string nom = AskStringUser("Quel est votre nom ?", CheckValidName);
            string tel = AskStringUser("Quel est votre numéro de téléphone ?", CheckValidTel);

            Console.WriteLine();
            Console.WriteLine("Bonjour " + nom + ", vous êtes joignable au " + tel);
        }

        static string AskStringUser(string message, ValidString functionValidation)
        {
            Console.Write(message + " ");
            string reponse = Console.ReadLine();
            if(functionValidation!= null)
            {
                string erreur = functionValidation(reponse);
                if(erreur!= null)
                {
                    Console.WriteLine("ERREUR : " + erreur);
                    return AskStringUser(message, functionValidation);
                }
            }
            return reponse;
        }

        static string CheckValidName(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) {
                return "Le nom ne doit pas être vide";
            }
            if(s.Any(char.IsDigit))
            {
                return "Le nom ne doit pas contenir de chiffre";
            }
            return null;
        }
        static string CheckValidTel(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) {
                return "Le numéro de téléphone ne doit pas être vide";
            }
            if(!s.All(char.IsDigit))
            {
                return "Le numéro de téléphone doit contenir uniquement des chiffre";
            }
            if(s.Length !=10)
            {
                return "Le numéro de téléphone doit être composé de 10 chiffre";
            }
            return null;
        }
    }
}