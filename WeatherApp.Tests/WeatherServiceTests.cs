using Moq;

namespace WeatherApp.Tests
{
    public class WeatherServiceTests
    {
        private Mock<IWeatherService> _weatherServiceMock;

        [SetUp]
        public void Setup()
        {
            _weatherServiceMock = new Mock<IWeatherService>();
        }


        // Test ověřuje správné fungování, že vrácená data odpovídají ..
        [Test]
        public async Task GetWeatherDataAsync_ValidData_ReturnsWeatherData()
        {
            var expectedData = new WeatherData
            {
                Mesto = "Praha",
                Teplota = 20.5,
                StavPocasi = "Slunečno",
                RychlostVetru = 15.5,
                Vlhkost = 45,
                Aktualizace = "2024-01-20 14:30"
            };

            _weatherServiceMock
                .Setup(x => x.GetWeatherDataAsync("Praha"))
                .ReturnsAsync(expectedData);
            
            var result = await _weatherServiceMock.Object.GetWeatherDataAsync("Praha");
            
            Assert.That(result.Mesto, Is.EqualTo("Praha"), "Město by měloi být Praha");
            Assert.That(result.Teplota, Is.EqualTo(20.5), "Teplota by měla být 20.5");
            Assert.That(result.StavPocasi, Is.EqualTo("Slunečno"), "Stav počasí by měl být Slunečno");
        }
        //Tento test ověřuje situaci, kdy se služba pokusí získat data o počasí pro neexistující město.
        [Test]
        public void GetWeatherDataAsync_InvalidCity_ThrowsException()
        {
            // Arrange
            _weatherServiceMock
                .Setup(x => x.GetWeatherDataAsync("NeexistujiciMesto"))
                .ThrowsAsync(new HttpRequestException());

            // Act & Assert
            Assert.That(async () => await _weatherServiceMock.Object.GetWeatherDataAsync("NeexistujiciMesto"),
            Throws.TypeOf<HttpRequestException>());
        }
    }
}