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

    public class ObersvationStationResult
    {

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("features")]
        public List<ObservationStation> ObservationStations { get; set; }

        [JsonPropertyName("observationStations")]
        public List<Uri> StationUris { get; set; }

        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; }
    }

    public class Bearing
    {
        [JsonPropertyName("@type")]
        public string Type { get; set; }
    }

    public class Distance
    {
        [JsonPropertyName("@id")]
        public string Id { get; set; }

        [JsonPropertyName("@type")]
        public string Type { get; set; }
    }

    public class Value
    {
        [JsonPropertyName("@id")]
        public string Id { get; set; }
    }

    public class ObservationStation
    {
        [JsonPropertyName("id")]
        public Uri Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("geometry")]
        public Geometry Geometry { get; set; }

        [JsonPropertyName("properties")]
        public StationDetails StationDetail { get; set; }
    }

    public class StationDetails
    {
        [JsonPropertyName("@id")]
        public Uri Id { get; set; }

        [JsonPropertyName("@type")]
        public string Type { get; set; }

        [JsonPropertyName("elevation")]
        public Elevation Elevation { get; set; }

        [JsonPropertyName("stationIdentifier")]
        public string StationIdentifier { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("timeZone")]
        public string TimeZone { get; set; }

        [JsonPropertyName("forecast")]
        public Uri Forecast { get; set; }

        [JsonPropertyName("county")]
        public Uri County { get; set; }

        [JsonPropertyName("fireWeatherZone")]
        public Uri FireWeatherZone { get; set; }
    }

    public class Elevation
    {
        [JsonPropertyName("unitCode")]
        public string UnitCode { get; set; }

        [JsonPropertyName("value")]
        public double Value { get; set; }
    }

    public class Pagination
    {
        [JsonPropertyName("next")]
        public Uri Next { get; set; }
    }
}
#pragma warning restore CS8618
#pragma warning restore CS8601
#pragma warning restore CS8603
