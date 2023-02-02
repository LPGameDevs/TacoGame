using System.Collections.Generic;
using System.Linq;

namespace TacosLibrary
{
    public class Game
    {
        private List<Player> _players = new List<Player>();

        public void AddPlayer(string playerName)
        {
            _players.Add(new Player(playerName));
        }

        public object GetPlayerName()
        {
            return _players.First().Name;
        }
    }
}
