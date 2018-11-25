﻿// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using TinyCsvParser;
using TinyCsvParser.Tokenizer;
using WeatherDataColumnStore.Csv.Mapper;
using WeatherDataColumnStore.Csv.Model;
using WeatherDataColumnStore.Csv.Tokenizer;

namespace WeatherDataColumnStore.Csv.Parser
{
    public static class Parsers
    {
        public static CsvParser<Station> StationParser
        {
            get
            {
                CsvParserOptions csvParserOptions = new CsvParserOptions(false, string.Empty, Tokenizers.StationsTokenizer, 1, false);

                return new CsvParser<Station>(csvParserOptions, new StationMapper());
            }
        }

        public static CsvParser<LocalWeatherData> LocalWeatherDataParser
        {
            get
            {
                CsvParserOptions csvParserOptions = new CsvParserOptions(false, string.Empty, Tokenizers.LocalWeatherDataTokenizer, 1, false);

                return new CsvParser<LocalWeatherData>(csvParserOptions, new LocalWeatherDataMapper());
            }
        }
    }
}