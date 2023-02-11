namespace TacosLibrary.Clearings
{
    public class HenClearing : PassClearing
    {
        public override string Code() => "H";
        
        public HenClearing(int passValue) : base(passValue)
        {
        }

        public override void OnFail(Rider rider)
        {
            // Kill the rider.
            GameManager.Instance.RemoveRider(rider);
        }
    }
}
