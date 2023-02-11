using System;
using TacosLibrary;
using TacosLibrary.Clearings;

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
            GameManager.Instance.StartGame();
            
            // Add the first clearing
            Random random = new Random();

            Path path = new Path().Add(new HenClearing(1)).Add(new BancheeClearing(1)).Add(new BancheeClearing(1));
            GameManager.Instance.AddPath(path);

            path = new Path().Add(new HenClearing(1)).Add(new WitchClearing(1)).Add(new HenClearing(1));
            GameManager.Instance.AddPath(path);
            
            path = new Path().Add(new DuckClearing(1)).Add(new HenClearing(1)).Add(new WyrmClearing(1)).Add(new WitchClearing(1)).Add(new BancheeClearing(1)).Add(new ElfClearing(1));
            GameManager.Instance.AddPath(path);
            
            path = new Path().Add(new ElfClearing(1)).Add(new WyrmClearing(1)).Add(new WitchClearing(1)).Add(new BancheeClearing(1)).Add(new WitchClearing(1));
            GameManager.Instance.AddPath(path);
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
                IPhase phase = GameManager.Instance.GetNextPhase();
                phase.Play();

                if (GameManager.Instance.TurnIsOver)
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
