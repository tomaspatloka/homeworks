namespace WeatherApp
{
    public interface IWeatherService
    {
        Task<WeatherData> GetWeatherDataAsync(string mesto);
    }
}