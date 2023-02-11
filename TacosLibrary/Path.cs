using System.Collections.Generic;
using TacosLibrary.Clearings;

namespace TacosLibrary
{
    public class Path
    {
        private List<IClearing> _clearings = new List<IClearing>();

        public Path Add(IClearing clearing)
        {
            _clearings.Add(clearing);
            return this;
        }
        
        public List<IClearing> GetClearings()
        {
            return _clearings;
        }
    }
}
