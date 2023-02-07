using System;
using System.Collections.Generic;

namespace TacosLibrary
{
    public class Go : BasePhase, IPhase
    {
        private List<Rider> _riders = new List<Rider>();
        private List<Meals> _mealsDelivered = new List<Meals>();

        public override string Instructions => "Send your riders on their journey one by one to deliver their meals.";

        public override void Process()
        {
            while (_riders.Count > 0)
            {
                Rider rider = _riders[0];
                
                
                
                _riders.RemoveAt(0);
            }
        }
        
        public override void Response()
        {
            // Display the riders on their journey.
        }
    }
}
