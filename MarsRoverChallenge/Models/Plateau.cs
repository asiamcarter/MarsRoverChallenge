using System;
using System.Collections.Generic;

namespace MarsRoverChallenge
{
    public class Plateau
    {
        public int MaximumX { get; set; }
        public int MaximumY { get; set; }
        public int MinimumX { get; set; } = 0;
        public int MinimumY { get; set; } = 0;
        public List<string> OccupiedPositions { get; set; } = new List<string>();

        public Plateau(string maximumCoordinates)
        {
            maximumCoordinates = Helper.ReplaceWhitespace(maximumCoordinates, "");

            MaximumX = (int)Char.GetNumericValue(maximumCoordinates[0]);
            MaximumY = (int)Char.GetNumericValue(maximumCoordinates[1]);
        }
    }
}
