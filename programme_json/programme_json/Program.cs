using Newtonsoft.Json;

namespace programme_json
{

    class Personne
    {
        public string nom;
        public int age;

        public void Afficher ()
        {
            Console.WriteLine("Nom: " + nom + " - age: " + age + " ans");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Personne person = new Personne();
            person.nom = "Thomas";
            person.age = 25;
            person.Afficher();

            string json = JsonConvert.SerializeObject(person);
            Console.WriteLine(json);
            string jsonMichel = "{ \"nom\":\"Michel\",\"age\":45}";

            Personne michel = JsonConvert.DeserializeObject<Personne>(jsonMichel);
            michel.Afficher();
        }
    }
}