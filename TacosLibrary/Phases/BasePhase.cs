using System;

namespace TacosLibrary
{
    public class BasePhase : IPhase
    {
        public virtual string Instructions => "";

        public void Play()
        {
            Console.WriteLine(Instructions);
            Console.WriteLine("Enter to continue:");
            Console.ReadLine();
        }
    }
}
