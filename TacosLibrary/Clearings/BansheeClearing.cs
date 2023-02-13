namespace TacosLibrary.Clearings
{
    public class BansheeClearing : PassClearing
    {
        public override string Code() => "B(" + _passValue + ")";

        public BansheeClearing(int passValue) : base(passValue)
        {
        }
    }
}
