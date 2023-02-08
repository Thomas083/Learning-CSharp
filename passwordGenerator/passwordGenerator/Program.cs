using FormationCS;

namespace passwordGenerator
{
    internal class Program
    {

        
        static void Main(string[] args)
        {
            Random random= new Random();
            int numberPassword = 10;
            string lowercase = "abcdefghijklmnopqrstuvwxyz";
            string uppercase = lowercase.ToUpper();
            string number = "0123456789";
            string specialChar = "&ù%:;,?!§#-_@/*-+";
            string alphabet;

            int lengthPassword = Tools.CheckNumberPositive("Longueur du mot de passe : ");

            int passwordType = Tools.CheckNumberBetween("Vous voulez un mot de passe avec : \n" +
                "1 - Uniquement des caractères en minuscule\n" +
                "2 - Des caractères minuscules et majuscules\n" +
                "3 - Des caractères et des chiffres\n" +
                "4 - Caractères, chiffres, et caractères spéciaux\n" +
                "Votre choix : ", 1, 4);

            switch(passwordType)
            {
                case 1:
                    alphabet = lowercase;
                break;
                case 2:
                    alphabet = lowercase + uppercase;
                break;
                case 3:
                    alphabet = lowercase + uppercase + number;
                break;
                default:
                    alphabet = lowercase + uppercase + number + specialChar;
                break;
            }

            for (int j = 0; j < numberPassword; j++)
            {
                string password = "";
                for (int i = 0; i < lengthPassword; i++)
                {
                    int randomLetter = random.Next(alphabet.Length);
                    password += alphabet[randomLetter];
                }
                Console.WriteLine("Mot de passe = " + password);
            }
        }
    }
}