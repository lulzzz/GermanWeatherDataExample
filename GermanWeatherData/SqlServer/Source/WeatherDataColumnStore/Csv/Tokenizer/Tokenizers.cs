﻿using System;
using System.Collections.Generic;
using System.Text;
using TinyCsvParser.Tokenizer;

namespace WeatherDataColumnStore.Csv.Tokenizer
{
    public static class Tokenizers
    {
        public static ITokenizer StationsTokenizer
        {
            get
            {
                var columnDefinitions = new FixedLengthTokenizer.ColumnDefinition[]
                {
                    new FixedLengthTokenizer.ColumnDefinition(0, 6),
                    new FixedLengthTokenizer.ColumnDefinition(6, 14),
                    new FixedLengthTokenizer.ColumnDefinition(15, 23),
                    new FixedLengthTokenizer.ColumnDefinition(32, 39),
                    new FixedLengthTokenizer.ColumnDefinition(43, 51),
                    new FixedLengthTokenizer.ColumnDefinition(52, 61),
                    new FixedLengthTokenizer.ColumnDefinition(61, 102),
                    new FixedLengthTokenizer.ColumnDefinition(102, 125),
                };

                return new FixedLengthTokenizer(columnDefinitions, true);
            }
        }

        public static ITokenizer LocalWeatherDataTokenizer
        {
            get
            {
                return new StringSplitTokenizer(new [] {';' }, true);
            }
        }
    }
}