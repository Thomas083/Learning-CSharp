using Newtonsoft.Json;

namespace programme_json
{

    class Personne
    {
        public string nom { get; private set; }
        public int age { get; private set; }
        public bool majeur { get; private set; }

        public Personne(string nom, int age, bool majeur)
        {
            this.nom = nom;
            this.age = age;
            this.majeur = majeur;
        }

        public void Afficher ()
        {
            Console.WriteLine("Nom: " + nom + " - age: " + age + " ans");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            /*var personnes = new List<Personne>()
            {
                new Personne("Pierre", 20, true),
                new Personne("Paul", 17, false),
                new Personne("Jacque", 45, true),
                new Personne("Claire", 18, true),
                new Personne("Sophie", 12, false),
                new Personne("Anne", 62, true),
            };

            var json = JsonConvert.SerializeObject(personnes);
            Console.WriteLine(json);

            File.WriteAllText("Personnes.txt", json);*/

            string json = File.ReadAllText("Personnes.txt");
            var personnes = JsonConvert.DeserializeObject<List<Personne>>(json);

            foreach(var personne in personnes)
            {
                personne.Afficher();
            }
        }
    }
}