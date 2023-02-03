using System;

namespace TacosLibrary
{
    public class OrdersReady : BasePhase, IPhase
    {

        public override string Instructions => "Roll four dice and assign one dice to each rider.";
    }
}
