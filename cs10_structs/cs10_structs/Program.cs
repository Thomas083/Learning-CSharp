namespace cs10_structs
{
    struct PersonneStruct
    {
        public string name { get; set; }
        public int age { get; set; }


        public PersonneStruct()
        {
            name = "Inconnue";
            age = -1;
        }
    }
    record struct PersonneRecord(string name, int age);
    internal class Program
    {
        static void Main(string[] args)
        {
            //var ps1 = new PersonneStruct();

            var pr1 = new PersonneRecord("Paul", 20);
            var pr2 = new PersonneRecord("Paul", 20);


            Console.WriteLine(pr1);
            Console.WriteLine(pr2);
            Console.WriteLine(pr1 == pr2);
        }
    }
}