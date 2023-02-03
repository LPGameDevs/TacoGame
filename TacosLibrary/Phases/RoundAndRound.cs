using System;

namespace TacosLibrary
{
    public class RoundAndRound : BasePhase, IPhase
    {
        public override string Instructions => "Swap two cards from the map.";
        
        private int _card1;
        private int _card2;
        
        public override void Input()
        {
            Console.WriteLine("Choose two cards from 1-6 to swap on the map. Eg. 1-2");
            var input = Console.ReadLine();

            if (!input.Contains("-"))
            {
                Console.WriteLine("No separator '-' found. Try again.");
                Input();
                return;
            }
            
            // explode string input arount - into two integers.
            var cards = input.Split('-');
            bool isNumberOne = int.TryParse(cards[0], out _card1);
            bool isNumberTwo = int.TryParse(cards[1], out _card2);
            
            if (!isNumberOne || !isNumberTwo)
            {
                _card1 = 0;
                _card2 = 0;
                Console.WriteLine("That is not a number. Try again.");
                Input();
                return;
            }

            if (_card1 == _card2)
            {
                _card1 = 0;
                _card2 = 0;
                Console.WriteLine("You cant swap a card with itself. Try again.");
                Input();
                return;  
            }

            if (_card1 < 1 || _card1 > 6 || _card2 < 1 || _card2 > 6)
            {
                _card1 = 0;
                _card2 = 0;
                Console.WriteLine("Make sure both cards are a number between 1 and 6");
                Input();
                return;
            }
        }
        
        public override void Process()
        {
            // Send a game event to swap the cards on the map.
        }
        
        public override void Response()
        {
            // Display the new modifier.
            Console.WriteLine("You successfully swapped cards " + _card1 + " and " + _card2 + " on the map.");
        }
    }
}
