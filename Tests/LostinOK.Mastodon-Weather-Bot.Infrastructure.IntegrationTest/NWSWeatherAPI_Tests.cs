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
            var inMemorySettings = new Dictionary<string, string?>
            {
                {"UserAgent", "TestBot, http://testbot.com"}
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings.ToList())
                .Build();

            var api = new NWSWeatherAPI(configuration);
            var result = await api.GetPointAsync(35.8789, -97.4253);
            Assert.NotNull(result);
            Assert.NotNull(result.ExpirationDate);
            Assert.NotNull(result.Value);
            Assert.NotNull(result.Value.Properties);

        }
    }
}