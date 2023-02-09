using System.Runtime.Serialization;

namespace programCollections
{
    internal class Program
    {

        static int SumArray(int[] arraySum)
        {
            int sum = 0;

            for(int i= 0; i < arraySum.Length; i++) { 
                sum += arraySum[i]; 
            }

            return sum;
        }

        static void ShowArray(int[] array)
        {
            for(int i = 0; i < array.Length; i++ )
            {
                Console.WriteLine("[" + i + "] = " + array[i]);
            }
        }

        static void ShowMaxValue(int[] array)
        {
            int maxValue = array[0];
            for(int i = 0;i < array.Length; i++ )
            {
                if(array[i] > maxValue )
                maxValue = array[i];
            }

            Console.WriteLine("La valeur max est : " + maxValue);
        }

        static void ShowMinValue(int[] array)
        { 
            int minValue = array[0];

            for(int i = 0; i < array.Length; i++ )
            {
                if (array[i] < minValue)
                minValue= array[i];
            }
            Console.WriteLine("La valeur min est : " + minValue);
        
        }

        static void Array()
        {
            Random random = new Random();
            /*int[] firstArray = {200, 40, 15, 8, 12};*/
            const int ARRAY_LENGTH = 20;
            int[] firstArray = new int[ARRAY_LENGTH];

            for(int i = 0;i < ARRAY_LENGTH; i++) {
                firstArray[i] = random.Next(101);
            }
            ShowArray(firstArray);
            ShowMaxValue(firstArray);
            ShowMinValue(firstArray);
        }

        static void ShowList(List<string> list, bool orderDesc = false)
        {
            if(orderDesc)
            {
                for (int i = list.Count-1; i >= 0; i--)
                {
                    Console.WriteLine(list[i]);
                }
            }
            else
            {
                for(int i = 0; i<list.Count; i++ )
                {
                    Console.WriteLine(list[i]);
                }
            }
            string nameMax = list[0];
            for(int i = 0; i < list.Count; i++)
            {
                if (list[i].Length > nameMax.Length)
                {
                    nameMax= list[i];
                }
            }
            Console.WriteLine("Le nom le plus grand est : " + nameMax);
        }
        static void ShowCommonElement(List<string> firstList, List<string> secondList)
        {
            for(int i = 0; firstList.Count > i; i++)
            {
                string nameFirstList = firstList[i];
                if(secondList.Contains(nameFirstList))
                {
                    Console.WriteLine(nameFirstList);
                }
            }
        }

        static void ListOfList()
        {
            var country = new List<List<string>>();
            country.Add(new List<string>() { "France", "Paris", "Toulouse", "Bordeaux", "Lille" });
            country.Add(new List<string>() { "USA", "New-York", "Chicago", "Los Angeles", "San Francisco" });
            country.Add(new List<string>() { "Italie", "Venise", "Florence", "Milan", "Pise" });

            for (int i = 0; i < country.Count; i++)
            {
                var numberCity = country[i];
                Console.WriteLine(numberCity[0] + " - " + (numberCity.Count - 1) + " villes");
                for (int j = 1; j < numberCity.Count; j++)
                {
                    Console.WriteLine("  " + numberCity[j]);
                }
            }
        }

        static void List()
        {
            List<int> ints = new List<int>();

            ints.Add(0);
            ints.Add(1);
            ints.Add(2);

            List<string> list = new List<string>();
            while (true)
            {
                Console.Write("Rentrez un nom (ENTER pour finir) : ");
                string names = Console.ReadLine();


                if (names == "")
                {
                    break;
                }

                if (list.Contains(names))
                {
                    Console.WriteLine("Erreur, ce nom est déjà dans la liste");
                    Console.WriteLine();
                }
                else
                {
                    list.Add(names);
                }

            }

            for (int i = list.Count - 1; i >= 0; i--)
            {
                string name = list[i];
                if (name[name.Length - 1] == 'e')
                {
                    list.RemoveAt(i);
                }
            }





            var firstList = new List<string>() { "Paul", "jean", "pierre", "emilie", "martin" };
            var secondList = new List<string>() { "Sophie", "jean", "martin", "toto" };

            ShowCommonElement(firstList, secondList);

            ShowList(list, true);
        }

        static void DictionaryLearn()
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("Jean", "0630549630");
            dictionary.Add("Marie", "0760489530");
            dictionary["Martin"] = "0684230157";
            dictionary["Toto"] = "0756301694";
            string searchingSomeone = Console.ReadLine();

            if(dictionary.ContainsKey(searchingSomeone))
            {
                Console.WriteLine(dictionary[searchingSomeone]);
            }
            else
            {
                Console.WriteLine("Cette personne n'a pas été trouvée");
            }


            /*var listArray = new List<string[]>();
            listArray.Add(new string[] { "Jean", "0630549630" });
            listArray.Add(new string[] { "Marie", "0760489530" });
            listArray.Add(new string[] { "Martin", "0684230157" });
            listArray.Add(new string[] { "toto", "0756301694" });

            for(int i = 0; i < listArray.Count; i++)
            {
                if (listArray[i][0] == searchingSomeone)
                {
                    Console.WriteLine(listArray[i][1]);
                }
            }*/

        }

        static void Main(string[] args)
        {
            /*Array();
            List();
            ListOfList();*/
            DictionaryLearn();
        }
    }
}