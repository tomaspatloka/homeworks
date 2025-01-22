namespace WeatherApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                using var client = new HttpClient();
                var weatherService = new WeatherService(client);
                var display = new WeatherDisplay();

                Console.WriteLine("Zadejte nazev mesta:");
                string mesto = Console.ReadLine();

                Console.WriteLine("Stahuji data o pocasi...");
                var pocasi = await weatherService.GetWeatherDataAsync(mesto);
                display.ZobrazPocasi(pocasi);
            }
            catch (Exception e)
            {
                Console.WriteLine("Nastala chyba: " + e.Message);
            }

            Console.WriteLine("Stisknete libovolnou klavesu pro ukonceni...");
            Console.ReadKey();
        }
    }
}