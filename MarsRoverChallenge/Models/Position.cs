using System;
using System.Linq;

namespace MarsRoverChallenge
{
    //Ran into a dilemma here. I originally made all of the methods
    //in this class (save for Move) private with the idea that no
    //other class needed to be priivy to the inner workings. But, 
    //I do believe that the logic in these methods is important, so
    //I made them public in order to test them. 
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public CardinalDirection Direction { get; set; }

        public Position(string position)
        {
            X = (int)Char.GetNumericValue(position[0]);
            Y = (int)Char.GetNumericValue(position[1]);
            Direction = (CardinalDirection)Enum.Parse(typeof(CardinalDirection), position[2].ToString());
        }

        public string CurrentLocation
        {
            get
            {
                return $"{X} {Y} {Direction}";
            }
        }

        public string CurrentCoordinates
        {
            get
            {
                return $"{X} {Y}";
            }
        }

        public void Turn90Right()
        {
            switch (Direction)
            {
                case CardinalDirection.N:
                    Direction = CardinalDirection.E;
                    break;
                case CardinalDirection.S:
                    Direction = CardinalDirection.W;
                    break;
                case CardinalDirection.W:
                    Direction = CardinalDirection.N;
                    break;
                case CardinalDirection.E:
                    Direction = CardinalDirection.S;
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public void Turn90Left()
        {
            switch (Direction)
            {
                case CardinalDirection.N:
                    Direction = CardinalDirection.W;
                    break;
                case CardinalDirection.S:
                    Direction = CardinalDirection.E;
                    break;
                case CardinalDirection.W:
                    Direction = CardinalDirection.S;
                    break;
                case CardinalDirection.E:
                    Direction = CardinalDirection.N;
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public void AdvanceForward()
        {
            switch (Direction)
            {
                case CardinalDirection.N:
                    Y += 1;
                    break;
                case CardinalDirection.S:
                    Y -= 1;
                    break;
                case CardinalDirection.E:
                    X += 1;
                    break;
                case CardinalDirection.W:
                    X -= 1;
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public Position ProjectMove(Rover rover, Plateau plateau)
        {
            if (X < 0
                || X > plateau.MaximumX
                || Y < 0
                || Y > plateau.MaximumY)
            {
                throw new Exception($"Rover can not move beyond plateau bounderies (0 , 0) and ({plateau.MaximumX} , {plateau.MaximumY})");
            }

            if (plateau.OccupiedPositions.AsQueryable().Intersect(rover.Route).Any())
            {
                throw new Exception($"Command will result in Rover collision");
            }

            return this;
        }

        public Position Move(Rover rover, Plateau plateauCoordinates, string commands)
        {
            foreach (char command in commands)
            {
                switch (command)
                {
                    case 'M':
                        AdvanceForward();
                        rover.Route.Add($"{X} {Y}");
                        break;
                    case 'L':
                        Turn90Left();
                        rover.Route.Add($"{X} {Y}");
                        break;
                    case 'R':
                        Turn90Right();
                        rover.Route.Add($"{X} {Y}");
                        break;
                    default:
                        Console.WriteLine($"Invalid character {command}");
                        break;
                }
            }

            return ProjectMove(rover, plateauCoordinates);
        }
    }
}
