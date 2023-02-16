namespace programme_poo
{
    class Personne
    {
        string nom;
        int age;
        string emploi;

        public Personne(string nom, int age, string emploi) 
        {
            this.nom = nom;
            this.age = age;
            this.emploi = emploi;
        }

        public void Show()
        {
            Console.WriteLine("Nom : " + nom);
            Console.WriteLine(" AGE : " + age + " ans");
            Console.WriteLine(" EMPLOI : " + emploi);
        }
    }

    internal class Program
    {
        /*static void ShowInfoPeople(string nom, int age, string emploi)
        {
            Console.WriteLine("Nom : " + nom);
            Console.WriteLine(" AGE : " + age + " ans");
            Console.WriteLine("EMPLOI : " + emploi);
        }*/
        static void Main(string[] args)
        {
           /* var noms = new List<string> { "Pierre", "Paul", "Jacque"};
            var ages = new List<int> { 30, 35, 20};
            var emplois = new List<string> { "Développeur", "Professeur", "Etudiant"};

            for(int i = 0; i < noms.Count; i++)
            {
                ShowInfoPeople(noms[i], ages[i], emplois[i]);
            }*/

            Personne firstPersonne = new Personne("Paul", 30, "Développeur");
            Personne secondPersonne = new Personne("Paul", 35, "Professeur");
            firstPersonne.Show();
            secondPersonne.Show();
        }
    }
}