namespace TacosLibrary.Clearings
{
    public class WyrmClearing : PassClearing
    {
        public WyrmClearing(int passValue) : base(passValue)
        {
        }

        public override void OnFail(Rider rider)
        {
            // Kill the rider.
            GameManager.Instance.RemoveRider(rider);
        }
    }
}
