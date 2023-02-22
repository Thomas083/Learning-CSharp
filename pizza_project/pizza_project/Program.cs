using System.Text;

namespace pizza_project
{
    internal class Program
    {
        public class Pizza
        {
            string nom;
            float prix;
            List<string> ingredients;
            bool vegetarienne;

            public Pizza(string nom, float prix, List<string> ingredients, bool vegetarienne = false)
            {
                this.nom = nom ?? throw new ArgumentNullException(nameof(nom));
                this.prix = prix;
                this.ingredients = ingredients ?? throw new ArgumentNullException(nameof(ingredients));
                this.vegetarienne = vegetarienne;
            }

            public void Afficher()
            {
                string badgeVegetarienne = vegetarienne ? " (V)" : "";
                string nomAfficher = FormatPremiereLettreMajuscules(nom);
                Console.WriteLine(nomAfficher + badgeVegetarienne + " - " + prix + "€");
                Console.WriteLine(string.Join(", ", ingredients));
                Console.WriteLine();
            }

            private static string FormatPremiereLettreMajuscules( string s)
            {

                if(string.IsNullOrEmpty(s))
                    return s;

                string minuscules = s.ToLower();
                string majuscules = s.ToUpper();

                string resultat = majuscules[0] + minuscules[1..];

                return resultat;
            }

        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var pizzas = new List<Pizza>()
            {
                new Pizza("4 frommage", 11.5f,new List<string>() {"bleu", "Mozzarella", "Cheddar", "Compté", "Coulis de tomates"} , true),
                new Pizza("carnivore", 13.5f, new List<string>() {"Emmental", "piment", "Steack haché", "Concentré de tomates"}) ,
                new Pizza("HawAienne", 10.5f, new List < string >() {"Curry", "Escalope de poulet", "Maïs", "Ananas", "Patrika", "Parmesan", "Huile de pépin de raisin", "Tomate"}, true),
                new Pizza("Indienne", 10.5f, new List<string>(){"Poivron", "Curry", "Fromage râpé", "Huile d'olive", "Lait de coco", "Cheddar", "Escalopes de poulet", "Crème fraîche"}),
                new Pizza("MeXicaine", 13f, new List<string>() {"Mâïs", "Piment vert", "échalote", "Mozzarella", "Piment de cayenne", "Chair à saucisse", "Coulis de tomates"}),
                new Pizza("Margherita", 8f,new List<string>() {"Mozzarella", "Parmesan", "Huile d'olive", "Thym", "Laurier", "Concentré de tomate"}, true),
                new Pizza("calzone", 12f, new List<string>() {"Mozzarela", "Parmesan", "Jambon", "Huile d'olive", "Sauce tomate"}),
                new Pizza("Reine", 9.5f, new List<string>() {"Gruyère","Champignon de paris", "Jambon", "Sauce tomate"}),

            };

            foreach(var pizza in pizzas)
            {
                pizza.Afficher();
            }
        }
    }
}