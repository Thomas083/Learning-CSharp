namespace programme_fichier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //File.WriteAllText("monFichier.txt", "Voici un super contenue pour mon super fichier texte");
            try
            {
                string resultat = File.ReadAllText("monFichiers.txt");
                Console.WriteLine(resultat);
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