namespace TacosLibrary.Clearings
{
    public class ElfClearing : PassClearing
    {
        public override string Code() => "E";

        public ElfClearing(int passValue) : base(passValue)
        {
        }

        public override void OnFail(Rider rider)
        {
            // Kill the rider.
            GameManager.Instance.RemoveRider(rider);
        }
    }
}
