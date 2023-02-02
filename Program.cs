using System;
using TacosLibrary;

namespace TacosGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            
            Console.WriteLine("Welcome to the Tacos Game!");
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            
            game.AddPlayer(name);
            
            Console.WriteLine("Hello " + game.GetPlayerName() + ", let's start the game.");
            
            bool playAgain = true;
            while (playAgain)
            {
                Console.WriteLine("Enter a number:");
                string input = Console.ReadLine();
                string result = Numbers.IsNumberEven(input);
                Console.WriteLine(input + " is " + result + ".");
                
                Console.WriteLine("Do you want to play again? (yes/no)");
                string answer = Console.ReadLine();
                playAgain = (answer == "yes");
            }
            
            Console.WriteLine("Thank you for playing the Text-Based Game!");
        }
    }
}
