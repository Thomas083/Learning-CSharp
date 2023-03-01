using System.Net;

namespace AsyncDelegate
{
    class Program
    {
       static bool downloading = false;
        static void Main(string[] args)
        {
            Console.Write("Téléchargement...");
            var webClient = new WebClient();
            string url = "https://codeavecjonathan.com/res/bateau.jpg";
            //webClient.DownloadFile(url, "bateau.jpg");
            downloading = true;
            webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
            webClient.DownloadFileAsync(new Uri(url), "bateau.jpg");
            while(downloading)
            {
                Console.Write(".");
                Thread.Sleep(500);
            }
            Console.WriteLine("Fin du programme");
        }

        private static void WebClient_DownloadFileCompleted(object? sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Téléchargement terminé");
            downloading = false;
        }
    }
}