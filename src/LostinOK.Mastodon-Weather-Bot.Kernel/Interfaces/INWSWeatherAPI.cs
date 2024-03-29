﻿using LostinOK.Mastodon_Weather_Bot.Kernel.Entities.WeatherAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LostinOK.Mastodon_Weather_Bot.Kernel.Interfaces
{
    public interface INWSWeatherAPI
    {
        Task<WeatherAPIResult<GeoPointDetail>> GetPointAsync(double latitude, double longitude);
        Task<WeatherAPIResult<ZoneResult>> GetZones(double latitude, double longitude, string zoneType);
        Task<WeatherAPIResult<ObersvationStationResult>> GetObservationStationsByGridPoint(string forecastOfficeId, int x, int y);
    }
}
