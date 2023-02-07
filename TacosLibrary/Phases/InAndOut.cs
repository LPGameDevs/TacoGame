using System;

namespace TacosLibrary
{
    public class InAndOut : BasePhase, IPhase
    {
        public override string Instructions => "Swap a card from the map with the current modifier";

        private int _card;
        public override void Input()
        {
            Console.WriteLine("Choose a card from 1-6 to swap with the current modifier");
            var input = Console.ReadLine();
            bool isNumber = int.TryParse(input, out _card);

            if (!isNumber)
            {
                _card = 0;
                Console.WriteLine("That is not a number. Try again.");
                Input();
                return;
            }

            if (_card < 1 || _card > 6)
            {
                _card = 0;
                Console.WriteLine("Please pick a number between 1 and 6");
                Input();
                return;
            }
        }
        
        public override void Process()
        {
            // Send a game event to swap the card with the modifier.
        }
        
        public override void Response()
        {
            // Display the new modifier.
            Console.WriteLine("The new modifier is: " + GameManager.Instance.GetModifier());
        }
    }
}
