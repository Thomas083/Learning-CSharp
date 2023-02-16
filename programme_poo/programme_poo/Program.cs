namespace programme_poo
{
    class Personne
    {
        static int nombreDePersonnes = 0;

        public string nom { get; init; }
        public int age { get; init; }
        public string emploi { get; init; }
        int numeroPersonne;

        public Personne()
        {
            nombreDePersonnes++;
            this.numeroPersonne = nombreDePersonnes;
        }
        public Personne(string nom, int age, string emploi = null) : this()
        {

            this.nom = nom;
            this.age = age;
            this.emploi = emploi;
        }


        /*public string GetNom()
        { 
            return nom; 
        }

        public void SetNom(string value)
        {
            nom = value; 
        }*/

        public void Show()
        {
            Console.WriteLine("PERSONNE N° " + numeroPersonne);
            Console.WriteLine("Nom : " + nom);
            Console.WriteLine(" AGE : " + age + " ans");
            if(emploi!=null)
            {
                Console.WriteLine(" EMPLOI : " + emploi);
            } else
            {
                Console.WriteLine(" Aucun emploi spécifié");
            }
        }

        public static void ShowNumberOfPersonnes()
        {
            Console.WriteLine("Nombre de personne total : " + nombreDePersonnes);
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
                new Personne { nom = "Pierre", age = 30, emploi = "Developpeur"},
                new Personne { nom = "Paul", age = 35, emploi = "Professeur"},
                new Personne { nom = "Jacque", age = 20, emploi = "Etudiant"},
                new Personne { nom = "Julliette", age = 8},
                new Personne {nom = "Thomas", age= 25, emploi= "Developpeur" }
            };
            /* Personne secondPersonne = new Personne("Paul", 35, "Professeur");*/
            /* for(int i = 0; i < personnes.Count; i++)
             {
                 personnes[i].Show();
             }*/


            personnes = personnes.OrderBy(p => p.nom).ToList();

            foreach (var personne in personnes)
            {
                personne.Show();
            }

            Personne.ShowNumberOfPersonnes();
        }
    }
}