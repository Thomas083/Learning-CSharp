using System;

namespace firstProgram // Note: actual namespace depends on the project name.
{
    internal class Program
    {

        static int AskAge(string namePerson)
        {
            int age = 0;
            while (age <= 0)
            {
                Console.Write("Quel est l'âge de " + namePerson + " ? ");
                string age_str = Console.ReadLine();
                try
                {
                    age = int.Parse(age_str);
                    if (age <= 0)
                    {
                        Console.WriteLine("erreur, vous devez rentré un age valide");
                    }
                }
                catch
                {
                    Console.WriteLine("erreur, vous devez rentré un age valide");
                }
            }
            return age;
        }

        static string AskName(int numberPerson)
        {
            string name = "";
            while (name.Trim() == "")
            {
                Console.Write("Quel est le nom de la personne numéro " + numberPerson + " ? ");
                name = Console.ReadLine();
                name = name.Trim();
                if (name == "")
                {
                    Console.WriteLine("Veuillez rentré un nom valide");
                }
            }
            return name;
        }

        static void ShowInfoPerson(string name, int age, float height=0)
        {
            Console.WriteLine();
            Console.WriteLine("Bonjour " + name + ",\nVous avez " + age + " an(s)\nbientôt vous aurez " + (age+1) + " ans.");

            if (height != 0) {
                Console.WriteLine("Vous faites " + height + "m de hauteur.");
            }

            if(age == 1 || age == 0)
            {
                Console.WriteLine("gougougaga");
            }
            else if (age < 10)
            {
                Console.WriteLine("Vous êtes un enfant");
            }
            else if (age >=12 && age <18)
            {
                Console.WriteLine("Vous êtes adolescent");
            }
            else if (age < 18)
            {
                Console.WriteLine("Vous êtes mineur (pas le metier)");
            }
            else if (18 <= age && age < 21)
            {
                Console.WriteLine("Vous êtes majeur mais pas partout reviens dans " + (21 - age) + " ans.");
            }
            else if (age >= 60)
            {
                Console.WriteLine("vous êtes sénior");
            }
            else
            {
                Console.WriteLine("Bravo ! Vous êtes majeur partout dans le monde");
            }
            
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            /* string name1 = AskName(1);
             string name2 = AskName(2);
             int age1= AskAge(name1);
             int age2= AskAge(name2);
             ShowInfoPerson(name1, age1);
             ShowInfoPerson(name2, age2);*/
            Console.WriteLine("Combien êtes vous ?");
            string nbPerson_str = Console.ReadLine();
            try
            {
                int nbPerson = int.Parse(nbPerson_str);
                for (int i = 0; i < nbPerson; i++)
                {
                    string name = AskName(i+1);
                    int age = AskAge(name);
                    ShowInfoPerson(name, age);
                    Console.WriteLine();
                    Console.WriteLine("--------------");
                }
            } catch
            {
                Console.WriteLine("Veuillez rentrer un nombre valide!!!!!");
            }
        }
    }
}