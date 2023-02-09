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

        static void ShowList(List<string> list)
        {
            for(int i = 0; i<list.Count; i++ )
            {
                Console.WriteLine(list[i]);
            }
        }

        static void List()
        {
           /* List<int> ints= new List<int>();

            ints.Add(0);
            ints.Add(1);
            ints.Add(2);*/

            List<string> list = new List<string>();
            while(true)
            {
                Console.Write("Rentrez un nom (ENTER pour finir) : ");
                string name = Console.ReadLine();


                if (name == "")
                {
                    break;
                }

                if(list.Contains(name))
                {
                    Console.WriteLine("Erreur, ce nom est déjà dans la liste");
                    Console.WriteLine();
                } else
                {
                    list.Add(name);
                }

            }

            ShowList(list);
        }

        static void Main(string[] args)
        {
            /*Array();*/
            List();
        }
    }
}