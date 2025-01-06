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
                HttpResponseMessage odpoved = await client.GetAsync(url);
                odpoved.EnsureSuccessStatusCode();

                string odpovedTelo = await odpoved.Content.ReadAsStringAsync();

                WeatherData pocasi = ZpracujOdpoved(odpovedTelo);
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
                JsonElement apiData = dokument.RootElement;

                return new WeatherData
                {
                    Mesto = apiData.GetProperty("location").GetProperty("name").GetString(),
                    Teplota = apiData.GetProperty("current").GetProperty("temp_c").GetDouble(),
                    StavPocasi = apiData.GetProperty("current").GetProperty("condition").GetProperty("text").GetString(),
                    RychlostVetru = apiData.GetProperty("current").GetProperty("wind_kph").GetDouble(),
                    Vlhkost = apiData.GetProperty("current").GetProperty("humidity").GetInt32(),
                    Aktualizace = apiData.GetProperty("current").GetProperty("last_updated").GetString()
                };
            }
        }

              


        private static void ZobrazPocasi(WeatherData pocasi)
        {
            Console.WriteLine("Aktualni pocasi pro mesto: " + pocasi.Mesto);
            Console.WriteLine("Teplota: " + pocasi.Teplota + " °C");
            Console.WriteLine("Stav pocasi: " + pocasi.StavPocasi);
            Console.WriteLine("Rychlost vetru: " + pocasi.RychlostVetru + " km/h");
            Console.WriteLine("Vlhkost: " + pocasi.Vlhkost + " %");
            Console.WriteLine("Posledni aktualizace: " + pocasi.Aktualizace);
        }
    }
}