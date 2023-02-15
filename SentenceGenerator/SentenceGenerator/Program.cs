namespace SentenceGenerator
{
    internal class Program
    {

        static string GetRandomElement(string[] t)
        {
            var rnd = new Random();
            int randomIndex = rnd.Next(t.Length);
            string element = t[randomIndex];
            return element;
        }

        static void Main(string[] args)
        {
            var sujets = new string[]
            {
                "Un lapin",
                "Un chat",
                "Un chien",
                "Une grand-mère",
                "Un bonhomme de neige",
                "Une limace",
                "Un magicien",
                "Une sorcière",
                "Une tortue",
                "Une femme",
                "Une fée",
                "Un homme",

            };

            var verbes = new string[]
            {
                "mange",
                "prend",
                "écris",
                "vol",
                "sort",
                "cours",
                "saute",
                "écrase",
                "téléphone à",
                "tape",
                "tombe",
                "détruit",
                "observe",
                "attrape",
                "regarde",
                "avale",
                "néttoie",
                "se bat avec",
                "s'accroche à",
            };

            var complements = new string[]
            {
                "un arbre",
                "un livre",
                "un ordinnateur",
                "la lune",
                "le soleil",
                "un serpent",
                "une carte",
                "une girafe",
                "le ciel",
                "une piscine",
                "un gateau",
                "une souris",
                "un crapaud",
                "une feuille",
                "un tapis",
                "une canette",
                "du scotch",
                "une bouteille",
                "une chaise",
                "une gourde",
                "un chargeur",
                "une prise",
                "un cable",
                "une poubelle",
                "un sac",
                "un écean",
                "une table",
                "un téléphone",
                "du sel",
                "du poivre",
                "de l'oignon",
            };
            int nbSentence = 200;
            var uniqueSentence = new List<string>();
            int doublonsEvites = 0;
            for(int i = 0;i < nbSentence; i++)
            {
                var sujet = GetRandomElement(sujets);
                var verbe = GetRandomElement(verbes);
                var complement = GetRandomElement(complements);
                string sentence = sujet + " " + verbe + " " + complement;

                sentence = sentence.Replace("à le", "au");
                if(!uniqueSentence.Contains(sentence))
                {
                    uniqueSentence.Add(sentence);
                } else
                {
                    doublonsEvites++;
                    i--;
                }


            }
            foreach(var sentence in uniqueSentence)
            {
                Console.WriteLine(sentence);
            }

            Console.WriteLine();
            Console.WriteLine("Nombre de phrases unique : " + uniqueSentence.Count);
            Console.WriteLine("Nombre de doublon évités : " + doublonsEvites);
        }
    }
}