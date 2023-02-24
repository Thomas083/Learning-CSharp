using System.Net;

namespace programme_reseau
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string url = "https://codeavecjonathan.com/res/exemple.html";

            var webClient = new WebClient();

            string reponse = webClient.DownloadString(url);

            Console.WriteLine(reponse);
        }
    }
}