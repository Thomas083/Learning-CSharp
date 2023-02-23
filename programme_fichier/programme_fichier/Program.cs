namespace programme_fichier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //File.WriteAllText("monFichier.txt", "Voici un super contenue pour mon super fichier texte");
            string resultat = File.ReadAllText("monFichier.txt");
            Console.WriteLine(resultat);
        }
    }
}