#nullable enable
#pragma warning disable CS8618
#pragma warning disable CS8601
#pragma warning disable CS8603

namespace LostinOK.Mastodon_Weather_Bot.Kernel.Entities.WeatherAPI
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Globalization;

    public class ZoneResult
    {
        [JsonPropertyName("@context")]
        public Context Context { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("features")]
        public List<Zone> Zones { get; set; }
    }

    public class Context
    {
        [JsonPropertyName("@version")]
        public string Version { get; set; }
    }

    public class Zone
    {
        [JsonPropertyName("id")]
        public Uri Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("geometry")]
        public object Geometry { get; set; }

        [JsonPropertyName("properties")]
        public ZoneDetail ZoneDetail { get; set; }
    }

    public class ZoneDetail
    {
        [JsonPropertyName("@id")]
        public Uri Id { get; set; }

        [JsonPropertyName("@type")]
        public string Type { get; set; }

        [JsonPropertyName("id")]
        public string PropertiesId { get; set; }

        [JsonPropertyName("type")]
        public string PropertiesType { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("effectiveDate")]
        public DateTimeOffset EffectiveDate { get; set; }

        [JsonPropertyName("expirationDate")]
        public DateTimeOffset ExpirationDate { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("cwa")]
        public List<string> Cwa { get; set; }

        [JsonPropertyName("forecastOffices")]
        public List<Uri> ForecastOffices { get; set; }

        [JsonPropertyName("timeZone")]
        public List<string> TimeZone { get; set; }

        [JsonPropertyName("observationStations")]
        public List<Uri> ObservationStations { get; set; }

        [JsonPropertyName("radarStation")]
        public string RadarStation { get; set; }
    }
}
#pragma warning restore CS8618
#pragma warning restore CS8601
#pragma warning restore CS8603
