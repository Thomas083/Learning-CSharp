using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace programme_fichier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path = path+"/nouveauDossier/";

            string fileName = "monFichier.txt";
            string fileName2 = "monFichier2.txt";
            string pathAndFile = Path.Combine(path, fileName);
            string pathAndFile2 = Path.Combine(path, fileName2);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (File.Exists(pathAndFile))
            {
                Console.WriteLine("Le fichier existe déjà, on va écraser son contenue");
            } 
            else
            {
                Console.WriteLine("Le fichier n'existe pas, on va le crée");
            }
            /*//---------------------------------------------
            StringBuilder text = new();
            int nbLignes = 50000000;

            DateTime t1 = DateTime.Now;

            Console.WriteLine("Préparation des données...");
            for(int i = 0;i < nbLignes; i++)
            {
                text.Append("Ligne " + i + " \n");
            }
            Console.WriteLine("OK");
            Console.WriteLine("Ecriture des données...");           
            File.WriteAllText(pathAndFile, text.ToString());
            Console.WriteLine("OK");
            DateTime t2 = DateTime.Now;

            var diff = (int)((t2 - t1).TotalMilliseconds);
            Console.WriteLine(diff);
            //------------------------------------------------*/
            DateTime t1 = DateTime.Now;

            using (var writeStream = File.CreateText(pathAndFile))
            {
                int nbLignes = 50000000;
                for (int i = 0; i < nbLignes; i++)
                {
                    writeStream.Write("Ligne " + i + " \n");
                }
            }
            DateTime t2 = DateTime.Now;
            var diff = (int)((t2 - t1).TotalMilliseconds);
            Console.WriteLine(diff);


            using (var readStream = File.OpenText(pathAndFile))
            {
                while (true)
                {
                    var line = readStream.ReadLine();
                    if (line == null) break;
                    Console.WriteLine(line);

                }
            }

            /*try
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
            *//*File.Copy(pathAndFile, pathAndFile2);
            File.Delete(pathAndFile);*//*
            File.Move(pathAndFile, pathAndFile2);*/
        }
    }
}