using System.Text.Json;

namespace WeatherApp
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _client;
        private const string ApiKey = "41d2e2c85b1840a0b3d95844250501";

        public WeatherService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<WeatherData> GetWeatherDataAsync(string mesto)
        {
            string url = $"http://api.weatherapi.com/v1/current.json?key={ApiKey}&q={mesto}&aqi=no&lang=cs";

            HttpResponseMessage odpoved = await _client.GetAsync(url);
            odpoved.EnsureSuccessStatusCode();
            string odpovedTelo = await odpoved.Content.ReadAsStringAsync();

            return ZpracujOdpoved(odpovedTelo);
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
    }
}