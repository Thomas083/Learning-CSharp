﻿using System.Net;

namespace programme_reseau
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string url = "https://codeavecjonathan.com/res/exempsle.html";

            var webClient = new WebClient();
            try
            {
                string reponse = webClient.DownloadString(url);
                Console.WriteLine(reponse);
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