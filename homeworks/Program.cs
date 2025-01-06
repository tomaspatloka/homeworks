using System.Text.Json;

namespace WeatherApp
{
    public class WeatherData
    {
        public string Mesto { get; set; }
        public double Teplota { get; set; }
        public string StavPocasi { get; set; }
        public double RychlostVetru { get; set; }
        public int Vlhkost { get; set; }
        public string Aktualizace { get; set; }
    }

    internal class Program
    {
        static async Task Main(string[] args)
        {
            await GetWeatherDataAsync();

            Console.WriteLine("Stisknete libovolnou klavesu pro ukonceni...");
            Console.ReadKey();
        }

        private static async Task GetWeatherDataAsync()
        {
            try
            {
                using HttpClient client = new HttpClient();

                Console.WriteLine("Zadejte nazev mesta:");
                string mesto = Console.ReadLine();

                const string apiKey = "41d2e2c85b1840a0b3d95844250501";
                string url = "http://api.weatherapi.com/v1/current.json?key=" + apiKey + "&q=" + mesto + "&aqi=no" + "&lang=cs ";

                Console.WriteLine("Stahuji data o pocasi...");
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                WeatherData pocasi = ZpracujOdpoved(responseBody);
                ZobrazPocasi(pocasi);
            }
            catch (Exception e)
            {
                Console.WriteLine("Nastala chyba: " + e.Message);
            }
        }

        private static WeatherData ZpracujOdpoved(string jsonOdpoved)
        {
            using (JsonDocument dokument = JsonDocument.Parse(jsonOdpoved))
            {
                JsonElement root = dokument.RootElement;

                return new WeatherData
                {
                    Mesto = root.GetProperty("location").GetProperty("name").GetString(),
                    Teplota = root.GetProperty("current").GetProperty("temp_c").GetDouble(),
                    StavPocasi = root.GetProperty("current").GetProperty("condition").GetProperty("text").GetString(),
                    RychlostVetru = root.GetProperty("current").GetProperty("wind_kph").GetDouble(),
                    Vlhkost = root.GetProperty("current").GetProperty("humidity").GetInt32(),
                    Aktualizace = root.GetProperty("current").GetProperty("last_updated").GetString()
                };
            }
        }

              


        
    }
}