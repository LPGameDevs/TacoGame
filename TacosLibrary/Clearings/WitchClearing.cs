namespace TacosLibrary.Clearings
{
    public class WitchClearing : IClearing
    {
        public string Code() => "<-->";

        public WitchClearing()
        {
        }

        public bool CanPass(int diceRoll)
        {
            return true;
        }

        public void OnPass(Rider rider)
        {
            rider.Path = 1;
        }

        public void OnFail(Rider rider)
        {
            // Do nothing.
        }
    }
}
