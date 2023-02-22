using System.Text;

namespace pizza_project
{
    internal class Program
    {
        public class Pizza
        {
            string nom;
            float prix;
            bool vegetarienne;

            public Pizza(string nom, float prix, bool vegetarienne = false)
            {
                this.nom = nom;
                this.prix = prix;
                this.vegetarienne = vegetarienne;
            }

            public void Afficher()
            {
                string badgeVegetarienne = vegetarienne ? " (V)" : "";
                Console.WriteLine(nom + badgeVegetarienne + " - " + prix + "€");
            }

        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var pizzas = new List<Pizza>()
            {
                new Pizza("4 frommage", 11.5f, true),
                new Pizza("Carnivore", 13.5f),
                new Pizza("Hawaienne", 10.5f, true),
                new Pizza("Indienne", 10.5f),
                new Pizza("Mexicaine", 13f),
                new Pizza("Margherita", 8f, true),
                new Pizza("Calzone", 12f),
                new Pizza("Reine", 9.5f),

            };

            foreach(var pizza in pizzas)
            {
                pizza.Afficher();
            }
        }
    }
}