namespace News_cs9
{
    struct PersonneStruct
    {
        public string nom { get; init; }
        public int age { get; init; }

        public void Show()
        {
            Console.WriteLine("Nom : " + nom + " Age : " + age + "ans");
        }
    }
    record PersonneRecord
    {
        public string nom { get; init; }
        public int age { get; init; }

        public void Show()
        {
            Console.WriteLine("Nom : " + nom + " Age : " + age + "ans");
        }
    }
    class PersonneClass
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
            var firstPerson = new PersonneRecord { nom ="Thomas", age = 25 };
            var secondPerson = firstPerson;

            Console.WriteLine(firstPerson.Equals(secondPerson));
        }
    }
}