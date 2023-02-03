using System.Collections.Generic;
using System.Linq;

namespace TacosLibrary
{
    public class Game
    {
        private static Game _instance;

        private Game()
        {
        }

        public static Game Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Game();
                }

                return _instance;
            }
        }

        private List<MapCard> _mapCards = new List<MapCard>();
        private List<Player> _players = new List<Player>();
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
            _phases.Enqueue(new InAndOut());
            _phases.Enqueue(new RoundAndRound());
            _phases.Enqueue(new OrdersReady());
            _phases.Enqueue(new Go());
        }

        public string GetModifier()
        {
            return _modifier;
        }
    }
}
