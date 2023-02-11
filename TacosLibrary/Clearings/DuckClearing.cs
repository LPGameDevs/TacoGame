namespace TacosLibrary.Clearings
{
    public class DuckClearing : PassClearing
    {
        public override string Code() => "D";

        public DuckClearing(int passValue) : base(passValue)
        {
        }

        public override void OnFail(Rider rider)
        {
            // Kill the rider.
            GameManager.Instance.RemoveRider(rider);
        }
    }
}
