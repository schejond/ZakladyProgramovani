using Lekce11.OrderStructure;
using System.Text.Json;
using System.Xml.Serialization;
//using Newtonsoft.Json;

namespace Lekce11
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // ukazka nainstalovani nugetu Newtonsoft.Json
            //      pomoci UI - Manage NuGet Packages
            //      a pomoci prikazove radky -> Install-Package Newtonsoft.Json -Source nuget.org
            //      Newtonsoft.Json je starsi knihovna na serializaci a deserializaci JSONu
            //          JsonConvert.SerializeObject()

            // serializace a deserializace objektu pomoci System.Text.Json
            SerializeJsonDemo();

            DeserializeJsonDemo();

            // serializace a deserializace objektu pomoci System.Xml.Serialization
            SerializeXmlDemo();

            DeserializeXmlDemo();

            // u deserializace je potreba pohlidat vyjimky pri nevalidnim vstupu
            try
            {
                DeserializeJsonDemo("chybnyJson");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Deserializace selhala: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Finally blok se vzdy provede");
            }

            // muze byt vice catch bloku
            // ukazat si i vytvoreni vlastniho typu vyjimky
            //CheckJsonLength("shortJson");

            // ukazka zavolani webove aplikace (weboveho API)
            await GetPublicApiDataAsync();
        }

        public static void SerializeJsonDemo()
        {
            Order order = CreateOrderForSerialization();

            string json = JsonSerializer.Serialize(order);
            Console.WriteLine("Serializovany komplexni objekt:");
            Console.WriteLine(json);
        }

        public static void DeserializeJsonDemo(string inputJson = null)
        {
            const string jsonString = "{\"Header\":{\"Name\":\"Testing\",\"Description\":\"Test\",\"To\":\"Students\",\"From\":\"Ondra\",\"OrderedAt\":\"2024-12-16T20:53:44.717595+01:00\"},\"Lines\":[{\"Amount\":2,\"Price\":15.1,\"Item\":{\"Name\":\"Candy\",\"Description\":\"Delicious\",\"DataOfMaking\":\"2024-12-16T20:53:44.7439209+01:00\"}},{\"Amount\":1,\"Price\":1000,\"Item\":{\"Name\":\"Sofa\",\"Description\":\"Luxurious Sofa\",\"DataOfMaking\":\"2014-12-16T20:53:44.7439553+01:00\"}}]}"; ;
            var order = JsonSerializer.Deserialize<Order>(inputJson ?? jsonString);

            Console.WriteLine($"Deserialized:");
            Console.WriteLine(order);
        }

        public static void SerializeXmlDemo()
        {
            Order order = CreateOrderForSerialization();
            var serializer = new XmlSerializer(typeof(Order));
            using var xmlWriter = new StringWriter();
            serializer.Serialize(xmlWriter, order);
            Console.WriteLine(xmlWriter.ToString());
        }

        public static void DeserializeXmlDemo()
        {
            const string xmlString = "<?xml version=\"1.0\" encoding=\"utf-16\"?><Order xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><Header><Name>Testing</Name><Description>Test</Description><To>Students</To><From>Ondra</From><OrderedAt>2024-12-16T20:53:44.717595+01:00</OrderedAt></Header><Lines><OrderLine><Amount>2</Amount><Price>15.1</Price><Item><Name>Candy</Name><Description>Delicious</Description><DataOfMaking>2024-12-16T20:53:44.7439209+01:00</DataOfMaking></Item></OrderLine><OrderLine><Amount>1</Amount><Price>1000</Price><Item><Name>Sofa</Name><Description>Luxurious Sofa</Description><DataOfMaking>2014-12-16T20:53:44.7439553+01:00</DataOfMaking></Item></OrderLine></Lines></Order>";
            var serializer = new XmlSerializer(typeof(Order));
            using var xmlReader = new StringReader(xmlString);
            var order = (Order)serializer.Deserialize(xmlReader);
            Console.WriteLine($"Deserialized:");
            Console.WriteLine(order);
        }

        // ukazka metody, kdy by se mohlo hodit vyhozeni vlastni vyjimky
        public static void CheckJsonLength(string json)
        {
            if (json.Length < 10)
            {
                throw new ShortJsonException();
            }

            // dalsi logika
        }

        private static Order CreateOrderForSerialization()
        {
            return new Order
            {
                Header = new OrderHeader
                {
                    Description = "Test",
                    Name = "Testing",
                    From = "Ondra",
                    To = "Students",
                    OrderedAt = DateTime.Now
                },
                Lines = new[]
                {
                    new OrderLine
                    {
                        Amount = 2,
                        Price = 15.1f,
                        Item = new Item
                        {
                            Name = "Candy",
                            Description = "Delicious",
                            DataOfMaking = DateTime.Now
                        }
                    },
                    new OrderLine
                    {
                        Amount = 1,
                        Price = 1000f,
                        Item = new Item
                        {
                            Name = "Sofa",
                            Description = "Luxurious Sofa",
                            DataOfMaking = DateTime.Now.AddYears(-10)
                        }
                    }
                }
            };
        }

        // Ukazka volani https://www.weatherapi.com/api-explorer.aspx#current API
        // pro vyzkouseni musime mit vlastni validni apiKey. Ten ziskate po bezplatne registraci
        private static async Task GetPublicApiDataAsync()
        {
            try
            {
                using HttpClient client = new HttpClient();

                // url adresa api vcetne parametru
                const string apiKey = "API_KEY";
                const string city = "Prague";
                string url = $"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={city}&aqi=no";

                // zavolani GET meotdy API a získání odpovědi
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
