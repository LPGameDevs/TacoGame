using System;
using System.Collections.Generic;
using TacosLibrary.Clearings;

namespace TacosLibrary
{
    public class Game
    {
        private int _score = 0;
        public bool IsGameOver = false;

        private List<Path> _paths = new List<Path>();
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

        public void AddPath(Path path)
        {
            _paths.Add(path);
        }

        public List<Path> GetPaths()
        {
            return _paths;
        }

        public List<Rider> GetRiders()
        {
            return _riders;
        }

        public void AddRider(Rider rider)
        {
            _riders.Add(rider);
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
                var path = _paths[rider.Path];
                SendRider(rider, path);
            }
        }

        private void SendRider(Rider rider, Path path)
        {
            // All paths must pass to score.
            bool failed = false;

            foreach (var clearing in path.GetClearings())
            {
                // Check if we need to skip to a witch.
                if (rider.Witch > 0 && clearing.Code() != "<-->")
                {
                    continue;
                }

                // We are now at a witch.
                if (rider.Witch > 0)
                {
                    WitchClearing witch = clearing as WitchClearing;

                    if (witch.GetIndex() == rider.Witch)
                    {
                        rider.Witch = 0;
                    }
                    continue;
                }

                if (clearing.CanPass(rider.Value) == false)
                {
                    clearing.OnFail(rider);
                    failed = true;
                    break;
                }

                clearing.OnPass(rider);

                // If we deliver early we just exit.
                if (rider.Delivered)
                {
                    break;
                }

                // If passing has exhausted rider value, they fail.
                if (rider.Value < 1)
                {
                    failed = true;
                    break;
                }
            }

            if (rider.Witch > 0)
            {
                int currentPath = _paths.IndexOf(path);
                int newPath = currentPath + 1 < _paths.Count ? currentPath + 1 : 0;
                SendRider(rider, _paths[newPath]);
                return;
            }

            if (failed)
            {
                return;
            }

            rider.Delivered = true;
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
