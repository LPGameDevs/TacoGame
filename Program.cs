using System;
using TacosLibrary;

namespace TacosGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            // Setup
            SetupGame();
            
            // Play
            PlayGame();

            // End
            EndGame();
        }

        private static void SetupGame()
        {
            Console.WriteLine("Welcome to the Tacos Game!");
            Game.Instance.PlaceMap();

        }

        private static void PlayGame()
        {
            // Phase 1: In and Out
            // Phase 2: Round and Round
            // Phase 3: Orders Ready
            // Phase 4: Off we go!
            
            bool playAgain = true;
            while (playAgain)
            {
                IPhase phase = Game.Instance.GetNextPhase();
                phase.Play();

                if (Game.Instance.TurnIsOver)
                {
                    Console.WriteLine("Do you want to play again? (y/n)");
                    string answer = Console.ReadLine();
                    if (answer.Length == 0 || answer.Substring(0,1).ToLower() != "y")
                    {
                        playAgain = false;
                    }    
                }
            }
        }

        private static void EndGame()
        {
            Console.WriteLine("Thank you for playing the Taco Game!");
        }
    }
}
