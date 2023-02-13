using System.Collections.Generic;
using System.Linq;
using TacosLibrary.Clearings;

namespace TacosLibrary
{
    public class WitchManager
    {
        private int _witches = 0;

        #region Singleton

        private static WitchManager _instance;

        private WitchManager()
        {
        }

        public static WitchManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new WitchManager();
                }

                return _instance;
            }
        }

        #endregion

        public void AddWitch()
        {
            _witches++;
        }

        public int GetCount()
        {
            return _witches;
        }

        public void Restart()
        {
            _witches = 0;
        }
    }
}
