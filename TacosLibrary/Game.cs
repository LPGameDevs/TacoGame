using System.Collections.Generic;

namespace TacosLibrary
{
    public class Game
    {
        private int _score = 0;
        public bool IsGameOver = false;

        private List<int> _dice = new List<int>();
        private int _path;
        
        public int GetScore()
        {
            return _score;
        }
        
        public void AddScore(int score)
        {
            foreach (int die in _dice)
            {
                if (_path > 0 && die <= _path)
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
            _path = minimumDiceRoll;
        }
    }
}
