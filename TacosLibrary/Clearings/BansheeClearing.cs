namespace TacosLibrary.Clearings
{
    public class BansheeClearing : PassClearing
    {
        public override string Code() => "B";

        public BansheeClearing(int passValue) : base(passValue)
        {
        }
    }
}
