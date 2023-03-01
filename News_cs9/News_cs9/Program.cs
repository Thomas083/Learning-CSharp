namespace News_cs9
{
    class Personne
    {
        public string nom { get; init; }
        public int age { get; init; }

        public void Show()
        {
            Console.WriteLine("Nom : " + nom + " Age : " + age + "ans");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstPerson = new Personne { nom ="Thomas", age = 25 };
            var secondPerson = new Personne { nom ="Maxence", age = 22 };

            firstPerson.Show();
            Console.WriteLine("Hello, World!");
            foreach(var arg in args)
            {
                Console.WriteLine(arg);
            }
        }
    }
}