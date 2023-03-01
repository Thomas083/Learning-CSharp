using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Text;

namespace pizza_project
{
    public class Pizza
    {
        public string nom { get; set; }
        public float prix { get; protected set; }
        public List<string> ingredients { get; protected set; }
        public bool vegetarienne { get; private set; }

        public Pizza(string nom, float prix, bool vegetarienne, List<string> ingredients)
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
            var ingredientsAfficher = ingredients.Select(i => FormatPremiereLettreMajuscules(i)).ToList();


            Console.WriteLine(nomAfficher + badgeVegetarienne + " - " + prix + "€");
            Console.WriteLine(string.Join(", ", ingredientsAfficher));
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

        public bool ContientIngredient(string ingredient)
        {
            return ingredients.Where(i => i.ToLower().Contains(ingredient)).ToList().Count() > 0;
        }

    }

    class PizzaPersonnalisee : Pizza
    {
        static int nbPizzasPersonnalisee;
        public PizzaPersonnalisee() : base("Personnalisee", 5, false, null)
        {
            nbPizzasPersonnalisee++;
            nom = "Personnalisee" + nbPizzasPersonnalisee;
            ingredients = new List<string>();
            while(true)
            {
                Console.Write("Rentrez un ingrédient pour la pizza personnalisée " + nbPizzasPersonnalisee + " (ENTER pour terminer) : ");
                var ingredient = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(ingredient))
                {
                    break;
                }
                if(ingredients.Contains(ingredient))
                {
                    Console.WriteLine("ERREUR, cet ingrédiens est déjà dans la pizza");
                }
                else
                {
                    ingredients.Add(ingredient);
                    Console.WriteLine(string.Join(", ", ingredients));
                }
                    Console.WriteLine();
            }
            prix = 5 + ingredients.Count * 1.5f; 
        }
    }

    internal class Program
    {
        static List<Pizza> GetPizzasFromCode()
        {
            var pizzas = new List<Pizza>()
            {
                new Pizza("4 frommage", 11.5f, true,new List<string>() {"bleu", "Mozzarella", "Cheddar", "Compté", "Coulis de tomates"}),
                new Pizza("carnivore", 13.5f, false, new List<string>() {"Emmental", "piment", "Steack haché", "Concentré de tomates"}),
                new Pizza("HawAienne", 10.5f, true, new List < string >() {"Curry", "Escalope dE poulet", "Maïs", "ananas", "Patrika", "parmesan", "Huile de pépin de raisin", "Tomate"}),
                new Pizza("Indienne", 10.5f, false, new List<string>(){"Poivron", "curry", "Fromage râpé", "Huile d'olive", "Lait de coco", "cheddar", "Escalopes de poulet", "Crème fraîche"}),
                new Pizza("MeXicaine", 13f, false, new List<string>() {"Maïs", "Piment vert", "échalote", "Mozzarella", "Piment de cayenne", "Chair à saucisse", "coulis de tomates"}),
                new Pizza("Margherita", 8f, true, new List<string>() {"Mozzarella", "Parmesan", "Huile d'olive", "Thym", "Laurier", "Concentré de tomate"}),
                new Pizza("calzone", 12f, false, new List<string>() {"Mozzarela", "Parmesan", "Jambon", "Huile d'Olive", "SAuce tomate"}),
                new Pizza("Reine", 9.5f, false, new List<string>() {"Gruyère","Champignon de paris", "Jambon", "Sauce tomate"}),
            };
            return pizzas;
        }

        static List<Pizza> GetPizzasFromFile(string filename)
        {
            string json = null;
            List<Pizza> pizzas = null;
            try
            {
                json = File.ReadAllText(filename);
            }
            catch
            {
                Console.WriteLine("ERREUR De lecture du fichier : " + filename);
                return null;
            }

            try
            {
                pizzas = JsonConvert.DeserializeObject<List<Pizza>>(json);
            }
            catch
            {
                Console.WriteLine("ERREUR : les données json ne sont pas valdies");
                return null;
            }
            return pizzas;
        }

        static void GenerateJsonFile(List<Pizza> pizzas, string filename)
        {
            var json = JsonConvert.SerializeObject(pizzas);
            File.WriteAllText("Pizzas.json", json);
        }

        static List<Pizza> GetPizzaFromUrl(string url)
        {
            var webClient = new WebClient();
            List<Pizza> pizzas = null;
            string json = null;
            try
            {
                json = webClient.DownloadString(url);
            }
            catch
            {
                Console.WriteLine("ERREUR : l'url n'est pas bonne");
            }
            

            try
            {
                pizzas = JsonConvert.DeserializeObject<List<Pizza>>(json);
            }
            catch
            {
                Console.WriteLine("ERREUR : les données json ne sont pas valdies");
                return null;
            }
            return pizzas;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string filename = "Pizzas.json";
            string url = "https://codeavecjonathan.com/res/pizzas2.json";
            //var pizzas = GetPizzasFromCode();
            //GenerateJsonFile(pizzas, filename)
            // https://codeavecjonathan.com/res/pizzas2.json
            //var pizzas = GetPizzasFromFile(filename);
            var pizzas = GetPizzaFromUrl(url);
            if (pizzas != null)
            {
                foreach (var pizza in pizzas)
                {
                    pizza.Afficher();
                }
            }
        }
    }
}