﻿// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using CsvStationType = ElasticExperiment.Csv.Model.Station;
using CsvLocalWeatherDataType = ElasticExperiment.Csv.Model.LocalWeatherData;

using ElasticStationType = ElasticExperiment.Elastic.Model.Station;
using ElasticLocalWeatherDataType = ElasticExperiment.Elastic.Model.LocalWeatherData;

namespace ElasticExperiment.Converters
{
    public static class LocalWeatherDataConverter
    {
        public static ElasticLocalWeatherDataType Convert(CsvStationType station, CsvLocalWeatherDataType localWeatherData)
        {
            return new ElasticLocalWeatherDataType
            {
                Station = new ElasticStationType
                {
                    Identifier = station.Identifier,
                    Name = station.Name,
                    StartDate = station.StartDate,
                    EndDate = station.EndDate,
                    State = station.State,
                    Latitude = station.Latitude,
                    Longitude = station.Longitude,
                    StationHeight = station.StationHeight,
                },
                AirTemperatureAt2m = localWeatherData.AirTemperatureAt2m,
                AirTemperatureAt5cm = localWeatherData.AirTemperatureAt5cm,
                DewPointTemperatureAt2m = localWeatherData.DewPointTemperatureAt2m,
                QualityCode = localWeatherData.QualityCode,
                RelativeHumidity = localWeatherData.RelativeHumidity,
                StationPressure = localWeatherData.StationPressure,
                TimeStamp = localWeatherData.TimeStamp
            };
        }
    }
}
