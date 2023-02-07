using System;
using System.Collections.Generic;
using TacosLibrary.Clearings;

namespace TacosLibrary
{
    public class Game
    {
        private int _score = 0;
        public bool IsGameOver = false;

        private List<int> _dice = new List<int>();
        private List<IClearing> _paths = new List<IClearing>();
        private int _riders = 0;

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
                foreach (var path in _paths)
                {
                    if (path.CanPass(die) == false)
                    {
                        path.OnFail();
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

        public void AddPath(IClearing clearing)
        {
            _paths.Add(clearing);
        }

        public int GetRiders()
        {
            return _riders;
        }

        public void AddRider()
        {
            _riders++;
        }

        public void RemoveRider()
        {
            _riders = Math.Max(0, _riders - 1);
        }
    }
}
