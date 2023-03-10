using System.Collections.Generic;
using System.Linq;
using TacosLibrary.Clearings;

namespace TacosLibrary
{
    public class GameManager
    {
        #region Singleton

        private static GameManager _instance;

        private GameManager()
        {
        }

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameManager();
                }

                return _instance;
            }
        }

        #endregion

        #region Game

        private Game _game;

        public Game GetGame()
        {
            return _game;
        }

        public void StartGame()
        {
            WitchManager.Instance.Restart();
            _game = new Game();
        }

        #endregion

        #region GameState

        public bool IsGameOver()
        {
            if (_game == null)
            {
                return true;
            }

            if (_game.IsGameOver)
            {
                return true;
            }

            return false;
        }

        public int GetScore()
        {
            return _game.GetScore();
        }

        public void AddPath(int minimumDiceRoll)
        {
            _game.AddPath(new Path().Add(new PassClearing(minimumDiceRoll)));
        }

        public void AddPath(Path path)
        {
            _game.AddPath(path);
        }

        public List<Path> GetPaths()
        {
            return _game.GetPaths();
        }



        public void AddRider(Rider rider)
        {
            _game.AddRider(rider);
        }

        public void AddRider(Rider.FoodName food = Rider.FoodName.Tacos)
        {
            Rider rider = new Rider(food);
            AddRider(rider);
        }

        public void AddRider(Rider.FoodName food, int value)
        {
            Rider rider = new Rider(food);
            rider.Value = value;
            AddRider(rider);
        }

        public void RemoveRider(Rider rider)
        {
            _game.RemoveRider(rider);
        }

        public int GetRiderCount()
        {
            if (_game == null)
            {
                return 0;
            }

            return _game.GetRiders().Count;
        }

        public Rider[] GetRiders()
        {
            return _game.GetRiders().ToArray();
        }


        #endregion

        #region Management

        public void PlayGame()
        {
            _game.SendRiders();
            _game.CalculateScore();
            _game.EndGame();
        }

        #endregion


        private List<MapCard> _mapCards = new List<MapCard>();

        private List<Player> _players = new List<Player>();

        private List<IClearing[]> _paths = new List<IClearing[]>();

        private int _mapSize = 4;

        private string _modifier;

        private Queue<IPhase> _phases = new Queue<IPhase>();

        public bool TurnIsOver => _phases.Count == 0;


        public void AddPlayer(string playerName)
        {
            _players.Add(new Player(playerName));
        }

        public string GetPlayerName()
        {
            return _players.First().Name;
        }

        public void PlaceMap()
        {
            _mapCards = new List<MapCard>();

            for (int i = 0; i < _mapSize; i++)
            {
                _mapCards.Add(new MapCard());
            }

            _modifier = "Flat Tire";

            // for (int i = 0; i < 4; i++)
            // {
            //     IClearing[] path = {
            //         new PassClearing(),
            //         new PassClearing(),
            //         new PassClearing(),
            //         new PassClearing(),
            //     };
            //     _paths.Add(path);
            // }
        }

        public MapCard[] GetMap()
        {
            return _mapCards.ToArray();
        }

        public IPhase GetNextPhase()
        {
            if (_phases.Count > 0)
            {
                return _phases.Dequeue();
            }

            StartNewTurn();
            return GetNextPhase();
        }

        private void StartNewTurn()
        {
            _phases = new Queue<IPhase>();
            _phases.Enqueue(new ShowMap());
            // _phases.Enqueue(new InAndOut());
            // _phases.Enqueue(new RoundAndRound());
            _phases.Enqueue(new OrdersReady());
            _phases.Enqueue(new ShowMap());
            _phases.Enqueue(new Go());
            _phases.Enqueue(new ShowMap());
        }

        public string GetModifier()
        {
            return _modifier;
        }
    }
}
