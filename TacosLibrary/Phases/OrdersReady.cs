using System;
using System.Collections.Generic;
using System.Linq;

namespace TacosLibrary
{
    public class OrdersReady : BasePhase, IPhase
    {
        private int[] _rolls = new int[4];
        
        public override string Instructions => "Roll four dice and assign one dice to each rider.";
        
        public override void Input()
        {
            // Roll four dice.
            // Assign one dice to each rider.
            
            Console.WriteLine("Press enter to roll dice.");
            var input = Console.ReadLine();
            
            // Roll dice.
            for (int i = 0; i < 4; i++)
            {
                int roll = new Random().Next(1, 7);

                // // @todo: Remove this.
                // if (i < 2)
                // {
                //     roll = 1;
                // }

                _rolls[i] = roll;

                Console.WriteLine("Dice " + (i + 1) + " rolled a " + roll + ".");
            }

            // Assign dice to riders.
            AssignRolls();
        }

        private void AssignRolls()
        {
            for (int i = GameManager.Instance.GetRiderCount(); i < _rolls.Length; i++)
            {
                int roll = _rolls[i];
                var pathOptions = GetRemainingPaths();
                if (pathOptions.Count == 0)
                {
                    Console.WriteLine("All paths are taken.");
                    return;
                }

                Console.WriteLine("Assign roll " + roll + " to a path. (" + string.Join(", ", pathOptions) + ")");
                var rollInput = Console.ReadLine();
                bool isNumber = int.TryParse(rollInput, out int pathChoice);
                if (!isNumber || (pathChoice < 1 || pathChoice > 4))
                {
                    Console.WriteLine("That is not a valid path.");
                    AssignRolls();
                    return;
                }
                
                if (!pathOptions.Contains(pathChoice))
                {
                    Console.WriteLine("That path is already taken.");
                    AssignRolls();
                    return;
                }
                
                // Assign the roll to the rider.
                Rider.FoodName food = (pathChoice == 1 || pathChoice == 3) ? Rider.FoodName.Tacos : Rider.FoodName.Veggie;

                Rider rider = new Rider(food);
                rider.Path = pathChoice - 1;
                rider.Value = roll;
                
                GameManager.Instance.AddRider(rider);
            }
        }

        private List<int> GetRemainingPaths()
        {
            var options = new List<int>() {1, 2, 3, 4};
            var riders = GameManager.Instance.GetRiders();

            foreach (Rider rider in riders)
            {
                // Get rider path;
                options.Remove(rider.Path + 1);
            }

            return options;
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
