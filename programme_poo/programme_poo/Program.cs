namespace programme_poo
{
    class Personne
    {
        public static int nombreDePersonnes = 0;

        public string nom;
        int age;
        string emploi;
        int numeroPersonne;

        public Personne(string nom, int age, string emploi) 
        {

            nombreDePersonnes++;
            this.numeroPersonne = nombreDePersonnes;
            this.nom = nom;
            this.age = age;
            this.emploi = emploi;
        }

        public void Show()
        {
            Console.WriteLine("PERSONNE N° " + numeroPersonne);
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


            var personnes = new List<Personne>
            {
                new Personne("Pierre", 30, "Développeur"),
                new Personne("Paul", 35, "Professeur"),
                new Personne("Jacque", 20, "Etudiant"),
                new Personne("Julliette", 8, "CP"),
            };
            /*Personne firstPersonne = new Personne("Paul", 30, "Développeur");
            Personne secondPersonne = new Personne("Paul", 35, "Professeur");*/
            /* for(int i = 0; i < personnes.Count; i++)
             {
                 personnes[i].Show();
             }*/

            personnes = personnes.OrderBy(p => p.nom).ToList();

           foreach (var personne in personnes)
            {
                personne.Show();
            }
            Console.WriteLine("Nombre de personne total : " + Personne.nombreDePersonnes);
        }
    }
}