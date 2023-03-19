using Microsoft.Extensions.Configuration;
using NuGet.Frameworks;

namespace LostinOK.Mastodon_Weather_Bot.Infrastructure.IntegrationTest
{
    public class NWSWeatherAPI_Tests
    {
        [Fact]
        public void Constructor_MissingConfig_Failure()
        {
            var inMemorySettings = new Dictionary<string, string?> {

            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings.ToList())
                .Build();

            Assert.Throws<ArgumentNullException>(() => new NWSWeatherAPI(configuration));
        }

        [Fact]
        public async Task GetPointAsync_Success()
        {
            var api = new NWSWeatherAPI(GetValidConfig());
            var result = await api.GetPointAsync(35.8789, -97.4253);
            Assert.NotNull(result);
            Assert.NotNull(result.ExpirationDate);
            Assert.NotNull(result.Value);
            Assert.NotNull(result.Value.Properties);

        }

        [Fact]
        public async Task GetZone_Success()
        {
            var api = new NWSWeatherAPI(GetValidConfig());
            var result = await api.GetZones(35.8789, -97.4253, "forecast");
            Assert.NotNull(result);
            Assert.NotNull(result.ExpirationDate);
            Assert.NotNull(result.Value);
            Assert.NotNull(result.Value.Zones);
            Assert.Single(result.Value.Zones);
            Assert.NotNull(result.Value.Zones[0].ZoneDetail);
        }

        [Fact]
        public async Task GetObervationStationsbyGridPoint_Success()
        {
            var api = new NWSWeatherAPI(GetValidConfig());
            var result = await api.GetObservationStationsByGridPoint("OUN", 100, 111);
            Assert.NotNull(result);
            Assert.NotNull(result.ExpirationDate);
            Assert.NotNull(result.Value);
            Assert.NotNull(result.Value.ObservationStations);
            Assert.True(result.Value.ObservationStations.Count() > 0);
            Assert.NotNull(result.Value.ObservationStations[0].StationDetail);
            
        }

        private IConfiguration GetValidConfig()
        {
            var inMemorySettings = new Dictionary<string, string?>
            {
                {"UserAgent", "TestBot, http://testbot.com"}
            };

            return new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings.ToList())
                .Build();
        }
    }
}