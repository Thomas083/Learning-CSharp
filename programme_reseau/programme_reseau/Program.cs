using System.Net;

namespace programme_reseau
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string url = "https://codeavecjonathan.com/res/papillon.jpg";

            var webClient = new WebClient();
            try
            {
                webClient.DownloadFile(url,"papillon.jpg");
                
                Console.WriteLine("téléchargement terminé");
            }
            catch (WebException ex)
            {
                if (ex.Response !=null)
                {
                    var statusCode = ((HttpWebResponse)ex.Response).StatusCode;
                    Console.WriteLine("ERREUR RESEAU : " + statusCode);
                }
                else
                {
                    Console.WriteLine("ERREUR RESEAU : "+ ex.Message);
                }

            }

        }
    }
}