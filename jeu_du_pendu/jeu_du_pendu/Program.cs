using AsciiArt;
namespace jeu_du_pendu
{
    internal class Program
    {
        static void ShowWord(string word, List<char> lettres)
        {
            // _ _ _ _ _ _ _ _
            for(int i = 0; i < word.Length; i++)
            {         
                char lettre = word[i];
                if (lettres.Contains(lettre))
                {
                    Console.Write(word[i] + " ");
                } 
                else
                {
                    Console.Write("_ ");
                }
            }
            Console.WriteLine();
        }

        static bool CheckAllLetterInWord(string word, List<char> lettres)
        {
            foreach(char lettre in lettres)
            {
                word = word.Replace(lettre.ToString(), "");
            }
            if(word.Length == 0)
            {
                return true;
            }
            return false;
        }

        static char AskLetter(string message = "écrivez une lettre : ")
        {
            while (true)
            {
                Console.Write(message);
                string lettre = Console.ReadLine();
                if(lettre.Length==1)
                {
                    lettre = lettre.ToUpper();
                    return lettre[0];
                }
                Console.WriteLine("ERREUR : Vous devez rentrer une lettre");

            }
        }

        static void FindWord(string word)
        {
            //loop
            //ShowWord(word);
            //AskLetter()
            //  -> show if the letter is on the word or not
            var lettresDevinees = new List<char>();
            var lettresNotInWord = new List<char>();
            const int HP = 6;
            int hp = HP;
            while(hp > 0)
            {
                Console.WriteLine("hp restant : " + hp);

                if(lettresNotInWord.Count > 0)
                {
                    Console.WriteLine("Le mot ne contient pas les lettres : " + String.Join(", ", lettresNotInWord));
                }

                Console.WriteLine();
                Console.WriteLine(Ascii.PENDU[HP -hp]);                 
                Console.WriteLine();
                ShowWord(word, lettresDevinees);
                var lettre = AskLetter();
                Console.Clear();
                if(word.Contains(lettre))
                {
                    Console.WriteLine("Cette lettre est dans le mot");
                    lettresDevinees.Add(lettre);
                    Console.WriteLine();
                    if(CheckAllLetterInWord(word, lettresDevinees))
                    {
                        ShowWord(word, lettresDevinees);
                        Console.WriteLine();
                        Console.WriteLine("GAGNE !");
                        return;
                    }
                }
                else
                {
                    if(!lettresNotInWord.Contains(lettre))
                    {
                        lettresNotInWord.Add(lettre);
                        hp--;
                    }
                }
            }
            Console.WriteLine(Ascii.PENDU[HP - hp]);

            if (hp == 0)
            {
                Console.WriteLine("PERDU ! le mot était : " + word);
            }
        }

        static string[] LoadWord(string nameFile)
        {
            try
            {
                return File.ReadAllLines(nameFile);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Erreur de lecture du fichier : " + nameFile + " (" + ex.Message + ") ");
            }
            return null;
        }


        static bool AskPlayAgain()
        {
            char reponse = AskLetter("Voulez-vous rejouer (o/n)");
            if(reponse == 'o' || reponse == 'O')
            {
                return true;
            }
            else if (reponse == 'n' || reponse == 'N')
            {
                return false;
            } else
            {
                Console.WriteLine("Erreur : Vous devez répondre avec o ou n");
                return AskPlayAgain();
            }
        }

        static void Main(string[] args)
        {
            Random random= new Random();

            var words = LoadWord("mots.txt");
            if(words == null || words.Length == 0)
            {
                Console.WriteLine("la liste de mots est vide");
            } else
            {
                while(true)
                {
                    string word = words[random.Next(words.Length)].Trim().ToUpper();
                    FindWord(word);
                    if(!AskPlayAgain())
                    {
                        break;
                    }
                    Console.Clear();
                }
                Console.WriteLine("Merci et à bientôt");
                
            }
            


        }
    }
}