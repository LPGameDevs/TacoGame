namespace TacosLibrary.Clearings
{
    public class WyrmClearing : PassClearing
    {
        public WyrmClearing(int passValue) : base(passValue)
        {
        }

        public override void OnFail()
        {
            // Kill the rider.
            GameManager.Instance.RemoveRider();
        }
    }
}
