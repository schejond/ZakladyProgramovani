namespace Lekce12
{
    internal class Program
    {
        // zmena signatury metody Main, abysme mohli pouzit async
        static async Task Main(string[] args)
        {
            // synchronni zpracovani
            Console.WriteLine("Pred zavolanim sync");
            DoSomething();
            Console.WriteLine("Po zavolanim sync");

            // asynchronni zpracovani - zkuste bez await a s nim a porovnejte vystup
            Console.WriteLine("Pred zavolanim async");
            await DoSomethingAsync();
            Console.WriteLine("Po zavolanim async");

            // ukazka prace s Task
            List<Task> tasks = new List<Task>
            {
                SleepAsync(1),
                SleepAsync(2),
                SleepAsync(3),
                SleepAsync(4),
                SleepAsync(5),
            };

            await Task.WhenAll(tasks); // vytvari novy task, ktery se resolvne az kdyz vsechny tasky v kolekci skonci
            // Task.WhenAny() vytvari novy task, ktery se resolvne az kdyz nejaky task v kolekci skonci
            await Task.WhenAny(tasks); // pokud uz tasky skoncily, tak se tato taska resolvne okamzite

            // ukazka volani webove sluzby
            await GetPublicApiDataAsync();
        }

        private static void DoSomething()
        {
            Console.WriteLine("Synchronni zpracovani");
        }

        private static async Task DoSomethingAsync()
        {
            Console.WriteLine("Asynchronni zpracovani");
            // nejprve zkuste zavolat SleepAsync bez await
            // potom s await a pozorujte rozdil
            Task<int> x = SleepAsync(); // navratovy typ bude Task<int> pokud nedate await, jinak int
            // vyzkousetejte si chovani s await a bez. Kdyz zde bude await a v Main ne + ruzne kombinace a pochopne chovani
        }


        // vyzkousejte si ruzne navratove hodnoty. void ~= Task, int ~= Task<int>
        private static async Task<int> SleepAsync(int attemptNumber = 0)
        {
            Console.WriteLine(attemptNumber + " Prvni zprava");
            await Task.Run(() => Thread.Sleep(2000)); // task run "zabali" anonymni metodu do tasku, vypocet anonymni metody se provede v jinem vlakne
            Console.WriteLine(attemptNumber + " Druha zprava");
            await Task.Delay(2000); // identicke chovani jako Thread.Sleep(2000) Task.Run prikaz vyse
            Console.WriteLine(attemptNumber + " Treti zprava");
            Task.Delay(2000).Wait(); // .Wait() provadi synchronni (blokujici) cekani na dokonceni tasku. Rozdilne oproti await, ktere sice ceka na dokonceni tasku, ale behem cekani neblokuje
            Console.WriteLine(attemptNumber + " Ctvrta, posledni zprava");
            return 5;
        }

        // Ukazka volani https://www.weatherapi.com/api-explorer.aspx#current API
        // pro vyzkouseni musime mit vlastni validni apiKey. Ten ziskate po bezplatne registraci
        private static async Task GetPublicApiDataAsync()
        {
            try
            {
                using HttpClient client = new HttpClient();

                // url adresa api vcetne potrebnych url parametru
                const string apiKey = "API_KEY";
                const string city = "Prague";
                string url = $"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={city}&aqi=no";

                // zavolani GET metody API a získání odpovědi
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                // precteni body z odpovedi (json objekt)
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured: " + e.Message);
            }
        }
    }
}
