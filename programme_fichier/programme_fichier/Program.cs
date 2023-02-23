namespace programme_fichier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string fileName = "monFichier.txt";
            string pathAndFile = Path.Combine(path, fileName);
            
            var names = new List<string>()
            {
                "Jean",
                "Pierre",
                "Paul",
                "Jacque",
            };
            File.WriteAllLines(pathAndFile, names);
            File.AppendAllText(pathAndFile, "\nje rajoute un super text");
            try
            {
                string resultat = File.ReadAllText(pathAndFile);
                Console.WriteLine(resultat);
                Console.WriteLine();
                var allLine = File.ReadAllLines(pathAndFile);
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