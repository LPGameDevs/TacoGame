namespace TacosLibrary.Clearings
{
    public class WitchClearing : PassClearing
    {
        public override string Code() => "S";

        public WitchClearing(int passValue) : base(passValue)
        {
        }

        public override void OnFail(Rider rider)
        {
            // Kill the rider.
            GameManager.Instance.RemoveRider(rider);
        }
    }
}
