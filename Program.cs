using System;
using TacosLibrary;

namespace TacosGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Tacos Game!");

            Game game = new Game();
            
            // Setup
            SetupGame(game);
            
            // Play
            PlayGame(game);

            // End
            EndGame(game);
        }

        private static void SetupGame(Game game)
        {
            
        }

        private static void PlayGame(Game game)
        {
            // Phase 1: In and Out
            // Phase 2: Round and Round
            // Phase 3: Orders Ready
            // Phase 4: Off we go!
            
            bool playAgain = true;
            while (playAgain)
            {
                IPhase phase = game.GetNextPhase();
                phase.Play();

                if (game.TurnIsOver)
                {
                    Console.WriteLine("Do you want to play again? (y/n)");
                    string answer = Console.ReadLine();
                    if (answer == "n")
                    {
                        playAgain = false;
                    }    
                }
            }
        }

        private static void EndGame(Game game)
        {
            Console.WriteLine("Thank you for playing the Taco Game!");
        }
    }
}
