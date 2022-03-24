using System.Collections.Generic;

namespace MarsRoverChallenge
{
    public class Rover : IRover
    {
        private Position CurrentLocation { get; set; }
        private Position ProjectedPosition { get; set; }
        internal List<string> Route { get; set; } = new List<string>();

        public Rover(string roverPosition)
        {
            ProjectedPosition = new Position(Helper.ReplaceWhitespace(roverPosition, ""));
        }

        public string OutputLocation
        {
            get
            {
                return $"{CurrentLocation.CurrentLocation}";
            }
        }

        public string OccupiedCoordinate
        {
            get
            {
                return $"{CurrentLocation.CurrentCoordinates}";
            }
        }  

        public void Move(Plateau plateauCoordinates, string commands)
        {
            CurrentLocation = ProjectedPosition.Move(this, plateauCoordinates, commands);
        }
    }
}
