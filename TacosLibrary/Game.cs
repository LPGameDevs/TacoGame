using System.Collections.Generic;

namespace TacosLibrary
{
    public class Game
    {
        private int _score = 0;
        public bool IsGameOver = false;

        private List<int> _dice = new List<int>();
        private List<int> _paths = new List<int>();
        
        public int GetScore()
        {
            return _score;
        }
        
        public void AddScore(int score)
        {
            foreach (int die in _dice)
            {
                // All paths must pass to score.
                bool failed = false;
                foreach (int path in _paths)
                {
                    if (path > 0 && die <= path)
                    {
                        failed = true;
                    }
                }

                if (failed)
                {
                    continue;
                }
                
                _score += score;
            }
        }

        public void EndGame()
        {
            IsGameOver = true;
        }

        public void AddDiceRoll(int outcome)
        {
            _dice.Add(outcome);
        }

        public void AddPath(int minimumDiceRoll)
        {
            _paths.Add(minimumDiceRoll);
        }
    }
}
