using System;

namespace TacosLibrary
{
    public class OrdersReady : BasePhase, IPhase
    {

        public override string Instructions => "Roll four dice and assign one dice to each rider.";
        
        public override void Input()
        {
            // Roll four dice.
            // Assign one dice to each rider.
        }
        
        public override void Process()
        {
            // Send a game event to assign the dice to the riders.
        }
        
        public override void Response()
        {
            // Display the dice on the riders.
        }
    }
}
