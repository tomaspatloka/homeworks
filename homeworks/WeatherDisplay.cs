namespace WeatherApp
{
    public class WeatherDisplay
    {
        public void ZobrazPocasi(WeatherData pocasi)
        {
            if(pocasi == null)
            throw new ArgumentNullException(nameof(pocasi));

            Console.WriteLine($"Aktualni počasí pro město: {pocasi.Mesto}");
            Console.WriteLine($"Teplota: {pocasi.Teplota} °C");
            Console.WriteLine($"Stav počasi: {pocasi.StavPocasi}");
            Console.WriteLine($"Rychlost větru: {pocasi.RychlostVetru} km/h");
            Console.WriteLine($"Vlhkost: {pocasi.Vlhkost} %");
            Console.WriteLine($"Posledni aktualizace: {pocasi.Aktualizace}");
        }
    }
}