using System;

namespace TacosLibrary
{
    public class OrdersReady : BasePhase, IPhase
    {

        public override string Instructions => "Roll four dice and assign one dice to each rider.";
        
        public override void Input()
        {
            // Roll four dice.
            // Assign one dice to each rider.
            
            Console.WriteLine("Press enter to roll dice.");
            var input = Console.ReadLine();

            int[] rolls = new int[4];
            
            // Roll dice.
            for (int i = 0; i < 4; i++)
            {
                int roll = new Random().Next(1, 7);
                rolls[i] = roll;
                Console.WriteLine("Dice " + (i + 1) + " rolled a " + roll + ".");
            }
            
            // Assign dice to riders.
            foreach (int roll in rolls)
            {
                Console.WriteLine("Assign roll " + roll + " to a rider. (0 for Tacos and 1 for Veggies)");
                var rollInput = Console.ReadLine();
                bool isNumber = int.TryParse(rollInput, out int rider);
                if (!isNumber || (rider != 0 && rider != 1))
                {
                    Console.WriteLine("That is not a number. We've assigned tacos.");
                }
                
                // Assign the roll to the rider.
                Rider.FoodName food = rider == 1 ? Rider.FoodName.Veggie : Rider.FoodName.Tacos;
                GameManager.Instance.AddRider(food);
                GameManager.Instance.RollDice(roll);
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
