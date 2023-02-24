using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace pizza_project
{
    internal class Program
    {
        public class Pizza
        {
            protected string nom { get; set; }
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

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
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
                new PizzaPersonnalisee(),
                new PizzaPersonnalisee(),
            };

            //pizzas = pizzas.OrderByDescending(p => p.prix).ToList();
            Pizza pizzaPrixMin = pizzas[0];
            Pizza pizzaPrixMax = pizzas[0];

            Console.WriteLine("Les différente pizza pas Végétarienne : ");
            var pizzasNoVege = pizzas.Where(p => !p.vegetarienne).ToList();
            foreach(var pizza in pizzasNoVege)
            {
                pizza.Afficher();
            }
            Console.WriteLine();
            Console.WriteLine("Les différente pizza Végétarienne : ");

            var pizzasVege = pizzas.Where(p => p.vegetarienne).ToList();
            foreach (var pizza in pizzasVege)
            {
                pizza.Afficher();
            }

            Console.WriteLine();
            Console.WriteLine("Les différente pizza base tomate");
            var pizzasTomato = pizzas.Where(p => p.ContientIngredient("tomate")).ToList();
            foreach(var pizza in pizzasTomato)
            {
                pizza.Afficher();
            }

            Console.WriteLine();
            Console.WriteLine("Les différente pizza base crème");
            var pizzasCreme = pizzas.Where(p => p.ContientIngredient("crème")).ToList();
            foreach(var pizza in pizzasCreme)
            {
                pizza.Afficher();
            }


            foreach (var pizza in pizzas)
            {
                if (pizzaPrixMin.prix > pizza.prix)
                {
                    pizzaPrixMin = pizza;
                }
                if (pizzaPrixMax.prix < pizza.prix)
                {
                    pizzaPrixMax = pizza;
                }
            }
            Console.WriteLine();
            Console.WriteLine("La pizza la moins cher est : ");
            pizzaPrixMin?.Afficher();
            Console.WriteLine("La pizza la plus cher est : ");
            pizzaPrixMax?.Afficher();
            Console.WriteLine();

        }
    }
}