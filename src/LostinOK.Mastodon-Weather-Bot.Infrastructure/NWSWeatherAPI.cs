using LostinOK.Mastodon_Weather_Bot.Kernel.Entities.WeatherAPI;
using LostinOK.Mastodon_Weather_Bot.Kernel.Interfaces;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace LostinOK.Mastodon_Weather_Bot.Infrastructure
{
    public class NWSWeatherAPI : INWSWeatherAPI, IDisposable
    {
        private readonly IConfiguration _configuration;
        private readonly RestClient _restClient;
        public NWSWeatherAPI(IConfiguration configuration)
        {
            _configuration = configuration;
            var userAgent = _configuration["UserAgent"];
            if(string.IsNullOrWhiteSpace(userAgent))
            {
                throw new ArgumentNullException("UserAgent", "User Agent is required to be configured.");
            }
            _restClient = new RestClient("https://api.weather.gov/")
                .AddDefaultHeader("UserAgent", userAgent);
        }



        public async Task<WeatherAPIResult<GeoPointDetail>> GetPointAsync(double latitude, double longitude)
        {
            var request = new RestRequest("/points/{point}")
                .AddUrlSegment("point", latitude.ToString() + "," + longitude.ToString());

            return await ExecuteAPIRequest<GeoPointDetail>(request);
        }

        public async Task<WeatherAPIResult<ZoneResult>> GetZones(double latitude, double longitude, string zoneType)
        {
            var request = new RestRequest("/zones")
                .AddQueryParameter("type", zoneType)
                .AddQueryParameter("point", latitude.ToString() + "," + longitude.ToString())
                .AddQueryParameter("include_geometry", "false");

            return await ExecuteAPIRequest<ZoneResult>(request);
        }

        private async Task<WeatherAPIResult<T>> ExecuteAPIRequest<T>(RestRequest request)
        {
            var result = await _restClient.ExecuteGetAsync<T>(request);
            var retval = new WeatherAPIResult<T>
            {
                Value = result.Data
            };

            var expireHeader = result?.ContentHeaders?.Where(i => i.Name == "Expires").FirstOrDefault();
            if (expireHeader != null && expireHeader.Value != null)
            {
                retval.ExpirationDate = DateTime.Parse(expireHeader.Value.ToString()!);
            }
            return retval;
        }

        public void Dispose()
        {
            if(_restClient != null)
            {
                _restClient.Dispose();
            }
        }
    }
}