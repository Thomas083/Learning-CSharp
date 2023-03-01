using System.Globalization;

namespace ProgrammeDateTime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime date = DateTime.Now;
            CultureInfo culture = CultureInfo.GetCultureInfo("fr-FR");

            Console.WriteLine(date.ToString("dddd dd MMMM yyyy", culture));

            DateTime dateDemain = date.AddDays(1);
            Console.WriteLine("Demain on sera le : " + dateDemain.ToString("dddd dd MMMM yyyy", culture));

            var diff = dateDemain - date;
            
            Console.WriteLine("Différence jours : " + diff.TotalDays);
        }

    }
}