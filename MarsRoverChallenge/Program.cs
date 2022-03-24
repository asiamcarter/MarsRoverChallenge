using System;

namespace MarsRoverChallenge
{
    class Program
    {
        // Notes: In a future iteration I would also add user input validation
        // Might have been overkill, but I added the Rover interface just in case there are rover's with different functionality in the future
        
        static void Main(string[] args)
        {
            Console.Write("What are the upper-right coordinates of the plateau?  ");
            Plateau plateau = new Plateau(Console.ReadLine());

            Console.Write("How many Rovers would you like to deploy?  ");
            int roverCount;
            Int32.TryParse(Console.ReadLine(), out roverCount);

            for (int i = 1; i <= roverCount; i++)
            {
                Console.WriteLine($"Enter Rover {i} (of {roverCount}) coordinates  ");
                Rover rover = new Rover(Console.ReadLine());
                Console.WriteLine($"Enter Rover {i} (of {roverCount}) command  ");
                string command = Console.ReadLine().ToUpper();

                try
                {
                    rover.Move(plateau, command);
                    plateau.OccupiedPositions.Add(rover.OccupiedCoordinate);
                    Console.WriteLine($"Rover location: {rover.OutputLocation}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }

            Console.ReadLine();
        }
    }
}
