namespace AsyncAwait
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string url1 = "https://codeavecjonathan.com/res/dummy.txt";
            string url2 = "https://codeavecjonathan.com/res/pizzas1.json";
            Console.Write("Téléchargement...");
            var displayTask = DisplayProgress();
            var downloadTask1 = DownloadData(url1);
            var downloadTask2 = DownloadData(url2);
            /*await downloadTask1;
            await downloadTask2;*/
            await Task.WhenAll(downloadTask1, downloadTask2);
            Console.WriteLine("Fin du programme");
        }

        static async Task DownloadData(string url)
        {
            var httpClient = new HttpClient();
            var resultat = await httpClient.GetStringAsync(url);

            Console.WriteLine("OK!" + url);
        }

        static async Task DisplayProgress()
        {
            while(true)
            {
                await Task.Delay(500);
                Console.Write(".");
            }
        }
    }
}