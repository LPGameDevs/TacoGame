namespace TacosLibrary.Clearings
{
    public class HenClearing : IClearing
    {
        public string Code() => "H";
        
        private int _hurtAmount;
        
        public HenClearing(int hurtValue = 1)
        {
            _hurtAmount = hurtValue;
        }

        public bool CanPass(int diceRoll)
        {
            return true;
        }

        public void OnPass(Rider rider)
        {
            rider.Value -= _hurtAmount;
        }
        
        public void OnFail(Rider rider)
        {
            // Can't fail.
        }
    }
}
