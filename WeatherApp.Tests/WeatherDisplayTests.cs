namespace WeatherApp.Tests
{
    public class WeatherDisplayTests
    {
        private WeatherDisplay _weatherDisplay;
        private StringWriter _stringWriter;

        [SetUp]
        public void Setup()
        {
            _weatherDisplay = new WeatherDisplay();
            _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);
        }

        [TestCase("Praha", 20.5, "Slunečno")]
        [TestCase("Brno", 18.5, "Oblačno")]
        [TestCase("Ostrava", 15.0, "Déšť")]
        public void ZobrazPocasi_ValidData_DisplaysCorrectly(string mesto, double teplota, string pocasi)
        {
            // Arrange
            var weatherData = new WeatherData
            {
                Mesto = mesto,
                Teplota = teplota,
                StavPocasi = pocasi,
                RychlostVetru = 15.5,
                Vlhkost = 45,
                Aktualizace = "2024-01-20 14:30"
            };

            // Act
            _weatherDisplay.ZobrazPocasi(weatherData);
            string output = _stringWriter.ToString();

            // Assert - using NUnit assertion syntax
            Assert.That(output.Contains(mesto));
            Assert.That(output.Contains(teplota.ToString()));
            Assert.That(output.Contains(pocasi));
        }

        [Test]
        public void ZobrazPocasi_NullData_ThrowsException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() =>
                _weatherDisplay.ZobrazPocasi(null));
            Assert.That(ex.ParamName, Is.EqualTo("pocasi"));
        }

        [TearDown]
        public void Cleanup()
        {
            _stringWriter?.Dispose();
        }
    }
}