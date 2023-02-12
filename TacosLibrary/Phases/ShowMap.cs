using System;
using System.Collections.Generic;
using System.Linq;

namespace TacosLibrary
{
    public class ShowMap : BasePhase, IPhase
    {
        public override string Instructions => "Show the map";

        public override void Input()
        {
            // Roll four dice.
            // Assign one dice to each rider.

            Console.WriteLine("Do you want to see the current map layout? (y/n)");
            var input = Console.ReadLine();

            if (input.Length == 0 || input.ToLower()[0] != 'y')
            {
                return;
            }

            Console.WriteLine("The current map is:");

            int max = 0;
            List<Path> paths = GameManager.Instance.GetPaths();
            foreach (Path path in paths)
            {
                if (path.GetClearings().Count > max)
                {
                    max = path.GetClearings().Count;
                }
            }

            Console.WriteLine("| 1 | 2 | 3 | 4 |");

            if (!GameManager.Instance.TurnIsOver)
            {
                PrintRiders();
            }

            for (int i = 0; i < max; i++)
            {
                Console.WriteLine("|---|---|---|---|");
                foreach (Path path in paths)
                {
                    if (path.GetClearings().Count > i)
                    {
                        Console.Write("|-" + path.GetClearings()[i].Code() + "-");
                    }
                    else
                    {
                        Console.Write("|---");
                    }
                }

                Console.WriteLine("|");
            }
            
            if (GameManager.Instance.TurnIsOver)
            {
                PrintRiders();
            }
        }

        private void PrintRiders()
        {
            if (GameManager.Instance.GetRiderCount() > 0)
            {
                var riders = GameManager.Instance.GetRiders();

                // Sort riders by path.
                riders = riders.OrderBy(r => r.Path).ToArray();

                foreach (var rider in riders)
                {
                    Console.Write("|[" + rider.Value + "]");
                }

                Console.WriteLine("|");
            }
        }

        public override void Process()
        {
            // Send a game event to assign the dice to the riders.
        }

        public override void Response()
        {
            // Display the dice on the riders.
        }
    }
}
