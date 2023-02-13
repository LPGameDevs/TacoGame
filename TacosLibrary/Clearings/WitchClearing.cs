namespace TacosLibrary.Clearings
{
    public class WitchClearing : IClearing
    {
        public void OnPass(Rider rider)
        {
            throw new System.NotImplementedException();
        }

        public string Code() => "S";

        public WitchClearing(int passValue)
        {
        }

        public bool CanPass(int diceRoll)
        {
            throw new System.NotImplementedException();
        }

        public void OnFail(Rider rider)
        {
            // Kill the rider.
            GameManager.Instance.RemoveRider(rider);
        }
    }
}
