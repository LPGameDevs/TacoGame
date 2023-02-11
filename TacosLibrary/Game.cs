using System;
using System.Collections.Generic;
using TacosLibrary.Clearings;

namespace TacosLibrary
{
    public class Game
    {
        private int _score = 0;
        public bool IsGameOver = false;

        private List<IClearing> _paths = new List<IClearing>();
        private List<Path> _tempPaths = new List<Path>();
        private List<Rider> _riders = new List<Rider>();

        public int GetScore()
        {
            return _score;
        }

        public void EndGame()
        {
            IsGameOver = true;
        }

        public void AddDiceRoll(int outcome)
        {
            foreach (Rider rider in _riders)
            {
                if (rider.HasValue)
                {
                    continue;
                }

                rider.SetValue(outcome);
                return;
            }
        }

        public void AddPath(IClearing clearing)
        {
            _paths.Add(clearing);
        }

        public void AddPath(Path path)
        {
            _tempPaths.Add(path);
        }

        public List<Path> GetPaths()
        {
            return _tempPaths;
        }

        public int GetRiders()
        {
            return _riders.Count;
        }

        public void AddRider(Rider.FoodName food)
        {
            _riders.Add(new Rider(food));
        }

        public void RemoveRider(Rider rider)
        {
            if (_riders.Contains(rider))
            {
                _riders.Remove(rider);
            }
        }

        public void SendRiders()
        {
            foreach (var rider in _riders.ToArray())
            {
                // All paths must pass to score.
                bool failed = false;
                foreach (var path in _paths)
                {
                    if (path.CanPass(rider.Value) == false)
                    {
                        path.OnFail(rider);
                        failed = true;
                    }
                }

                if (failed)
                {
                    continue;
                }

                rider.Delivered = true;
            }
        }

        public void CalculateScore()
        {
            int tacos = 0;
            int veggies = 0;

            foreach (Rider rider in _riders)
            {
                if (!rider.Delivered)
                {
                    continue;
                }

                switch (rider.Food)
                {
                    case Rider.FoodName.Tacos:
                        tacos++;
                        break;
                    case Rider.FoodName.Veggie:
                        veggies++;
                        break;
                }

                if (tacos > 0)
                {
                    _score = tacos * 3;
                }
                else
                {
                    _score = veggies * 1;
                }
            }
        }
    }
}
