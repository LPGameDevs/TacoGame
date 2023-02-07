namespace TacosLibrary.Clearings
{
    public class FailClearing : IClearing
    {
        public bool CanPass()
        {
            return false;
        }
    }
}
