namespace TacosLibrary.Clearings
{
    public class BancheeClearing : PassClearing
    {
        public override string Code() => "B";

        public BancheeClearing(int passValue) : base(passValue)
        {
        }

        public override void OnFail(Rider rider)
        {
            // Kill the rider.
            GameManager.Instance.RemoveRider(rider);
        }
    }
}
