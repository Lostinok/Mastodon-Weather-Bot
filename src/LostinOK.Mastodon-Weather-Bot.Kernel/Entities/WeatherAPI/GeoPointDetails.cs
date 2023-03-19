
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

    public class GeoPointDetail
    {
        [JsonPropertyName("id")]
        public Uri Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("geometry")]
        public Geometry Geometry { get; set; }

        [JsonPropertyName("properties")]
        public GeoPointDetailProperties Properties { get; set; }
    }

    public class Geometry
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("coordinates")]
        public List<double> Coordinates { get; set; }
    }

    public class GeoPointDetailProperties
    {
        [JsonPropertyName("@id")]
        public Uri Id { get; set; }

        [JsonPropertyName("@type")]
        public string Type { get; set; }

        [JsonPropertyName("cwa")]
        public string Cwa { get; set; }

        [JsonPropertyName("forecastOffice")]
        public Uri ForecastOffice { get; set; }

        [JsonPropertyName("gridId")]
        public string GridId { get; set; }

        [JsonPropertyName("gridX")]
        public long GridX { get; set; }

        [JsonPropertyName("gridY")]
        public long GridY { get; set; }

        [JsonPropertyName("forecast")]
        public Uri Forecast { get; set; }

        [JsonPropertyName("forecastHourly")]
        public Uri ForecastHourly { get; set; }

        [JsonPropertyName("forecastGridData")]
        public Uri ForecastGridData { get; set; }

        [JsonPropertyName("observationStations")]
        public Uri ObservationStations { get; set; }

        [JsonPropertyName("relativeLocation")]
        public RelativeLocation RelativeLocation { get; set; }

        [JsonPropertyName("forecastZone")]
        public Uri ForecastZone { get; set; }

        [JsonPropertyName("county")]
        public Uri County { get; set; }

        [JsonPropertyName("fireWeatherZone")]
        public Uri FireWeatherZone { get; set; }

        [JsonPropertyName("timeZone")]
        public string TimeZone { get; set; }

        [JsonPropertyName("radarStation")]
        public string RadarStation { get; set; }
    }

    public class RelativeLocation
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("geometry")]
        public Geometry Geometry { get; set; }

        [JsonPropertyName("properties")]
        public RelativeLocationProperties Properties { get; set; }
    }

    public class RelativeLocationProperties
    {
        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("distance")]
        public DistanceClass Distance { get; set; }

        [JsonPropertyName("bearing")]
        public DistanceClass Bearing { get; set; }
    }

    public class DistanceClass
    {
        [JsonPropertyName("unitCode")]
        public string UnitCode { get; set; }

        [JsonPropertyName("value")]
        public double Value { get; set; }
    }

}
#pragma warning restore CS8618
#pragma warning restore CS8601
#pragma warning restore CS8603
