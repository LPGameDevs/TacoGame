using System;
using System.Diagnostics;

namespace TacosLibrary
{
    public abstract class BasePhase
    {
        public virtual string Instructions => "";
        
        public virtual void Input() {}
        public virtual void Process() {}
        public virtual void Response() {}

        public void Play()
        {
            Console.WriteLine(Instructions);
            
            Input();
            Process();
            Response();
            Console.WriteLine("Enter to continue:");
            Console.ReadLine();
        }
    }
}
