﻿// Copyright (c) Philipp Wagner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Linq;
using TinyCsvParser.Tokenizer;

namespace InfluxExperiment.Csv.Tokenizer
{
    /// <summary>
    /// Implements a Tokenizer, that makes it possible to Tokenize a CSV line using fixed length columns.
    /// </summary>
    public class CustomFixedLengthTokenizer : ITokenizer
    {
        /// <summary>
        /// A column in a CSV file, which is described by the start and end position (zero-based indices).
        /// </summary>
        public class ColumnDefinition
        {
            public readonly int Start;

            public readonly int End;

            public ColumnDefinition(int start, int end)
            {
                Start = start;
                End = end;
            }

            public override string ToString()
            {
                return $"ColumnDefinition (Start = {Start}, End = {End})";
            }
        }

        public readonly ColumnDefinition[] Columns;

        public readonly bool Trim;

        public CustomFixedLengthTokenizer(ColumnDefinition[] columns, bool trim)
        {
            if (columns == null)
            {
                throw new ArgumentNullException("columns");
            }

            Columns = columns;
            Trim = trim;
        }

        public string[] Tokenize(string input)
        {
            string[] tokenizedLine = new string[Columns.Length];

            for (int columnIndex = 0; columnIndex < Columns.Length; columnIndex++)
            {
                var columnDefinition = Columns[columnIndex];

                var columnData = input.Substring(columnDefinition.Start, columnDefinition.End - columnDefinition.Start);

                if (Trim)
                {
                    columnData = columnData?.Trim();
                }

                tokenizedLine[columnIndex] = columnData;
            }

            return tokenizedLine;
        }

        public override string ToString()
        {
            var columnDefinitionsString = string.Join(", ", Columns.Select(x => x.ToString()));

            return $"CustomFixedLengthTokenizer (Columns = [{columnDefinitionsString}])";
        }
    }
}