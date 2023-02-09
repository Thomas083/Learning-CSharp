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

        static void Main(string[] args)
        {
            Array();
        }
    }
}