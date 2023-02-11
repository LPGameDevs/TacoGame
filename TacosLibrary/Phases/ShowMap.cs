using System;
using System.Collections.Generic;

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
