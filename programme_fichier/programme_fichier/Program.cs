namespace programme_fichier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = "monFichier.txt";

            var names = new List<string>()
            {
                "Jean",
                "Pierre",
                "Paul",
                "Jacque",
            };
            //File.WriteAllText("monFichier.txt", "Voici un super contenue pour mon super fichier texte");
            File.AppendAllText(fileName, "\nje rajoute un super text");
            File.WriteAllLines(fileName, names);
            try
            {
                string resultat = File.ReadAllText(fileName);
                Console.WriteLine(resultat);
                Console.WriteLine();
                var allLine = File.ReadAllLines(fileName);
                for(int i = 0;i < allLine.Length; i++)
                {
                    Console.WriteLine(allLine[i]);
                }
            } 
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("ERREUR : ce fichier n'existe pas \n" + ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("ERREUR : " + ex.Message);
            }
        }
    }
}