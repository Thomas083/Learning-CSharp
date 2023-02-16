using programme_poo;

namespace programme_poo
{
    class Personne
    {
        static int nombreDePersonnes = 0;

        protected string nom;
        protected int age;
        string emploi;
        protected int numeroPersonne;

        public Personne(string nom, int age, string emploi = null) 
        {
            nombreDePersonnes++;
            this.numeroPersonne = nombreDePersonnes;

            this.nom = nom;
            this.age = age;
            this.emploi = emploi;
        }

        protected void ShowNameAndAge()
        {
            Console.WriteLine("PERSONNE N° " + numeroPersonne);
            Console.WriteLine("Nom : " + nom);
            Console.WriteLine(" AGE : " + age + " ans");
        }

        public virtual void Show()
        {
            ShowNameAndAge();
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

    class Etudiant : Personne
    {
        protected string infoEtudes;
        public Personne professeurPrincipal { get; init; }
        public Etudiant(string nom, int age, string infoEtudes) : base(nom, age) 
        { 
            this.infoEtudes = infoEtudes;
        }

        protected void ShowProfesseurPrincipal()
        {
            if (professeurPrincipal != null)
            {
                Console.WriteLine(" Le professeur principal est : ");

                professeurPrincipal.Show();
            }
        }
        public override void Show()
        {
            ShowNameAndAge();
            Console.WriteLine(" Etudiant en " + infoEtudes);
            ShowProfesseurPrincipal();
        }
    }

    class Enfant : Etudiant
    {
        public string classeEcole { get; init; }
        Dictionary<string, float> notes = new Dictionary<string, float>();
        public Enfant(string nom, int age, string classeEcole, Dictionary<string, float> notes): base (nom, age, null)
        {
            this.classeEcole= classeEcole;
            this.notes = notes;
        }

        public override void Show()
        {
            ShowNameAndAge();
            Console.WriteLine(" Enfant en classe de : " + classeEcole);
            if(notes != null && notes.Count > 0)
            {
                Console.WriteLine(" Notes moyenne : ");
                foreach(KeyValuePair<string, float> note in notes)
                {
                    Console.WriteLine("   " + note.Key + " : " + note.Value + " / 10" );
                }
            }
            ShowProfesseurPrincipal();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var personnes = new List<Personne>
            {
                new Personne ("Pierre", 30, "Developpeur"),
                
                new Etudiant("Jacque", 20, "école d'ingénieur en informatique")
                {
                    professeurPrincipal = new Personne("Paul", 35, "Professeur"),
                },
                new Enfant ("Julliette", 8, "CP", new Dictionary<string, float> {
                    {"Math", 2f },
                    {"Geo", 8f },
                    {"Histoire", 6f },
                    {"Français", 7f },
                    {"Anglais", 4f },
                })
                {
                    professeurPrincipal = new Personne("Jean", 42, "Professeur des écoles")
                },
                new Personne ("Thomas", 25, "Developpeur" )
            };


            foreach (var personne in personnes)
            {
                personne.Show();
            }

            Personne.ShowNumberOfPersonnes();
        }
    }
}