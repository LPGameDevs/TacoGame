using System.Collections.Generic;
using System.Linq;

namespace TacosLibrary
{
    public class Game
    {
        private List<MapCard> _mapCards = new List<MapCard>();
        private List<Player> _players = new List<Player>();
        private int _mapSize = 4;

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
        }

        public MapCard[] GetMap()
        {
            return _mapCards.ToArray();
        }
    }
}
