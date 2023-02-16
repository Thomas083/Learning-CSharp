namespace programme_poo
{
    class Personne
    {
        string nom;
        int age;
        string emploi;
    }
    internal class Program
    {
        static void ShowInfoPeople(string nom, int age, string emploi)
        {
            Console.WriteLine("Nom : " + nom);
            Console.WriteLine(" AGE : " + age + " ans");
            Console.WriteLine("EMPLOI : " + emploi);
        }
        static void Main(string[] args)
        {
            var noms = new List<string> { "Pierre", "Paul", "Jacque"};
            var ages = new List<int> { 30, 35, 20};
            var emplois = new List<string> { "Développeur", "Professeur", "Etudiant"};

            for(int i = 0; i < noms.Count; i++)
            {
                ShowInfoPeople(noms[i], ages[i], emplois[i]);
            }
        }
    }
}