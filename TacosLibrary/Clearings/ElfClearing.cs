namespace TacosLibrary.Clearings
{
    public class ElfClearing : IClearing
    {
        public string Code() => "E";
        
        private int _encourageAmount;
        
        public ElfClearing(int encourageValue = 1)
        {
            _encourageAmount = encourageValue;
        }

        public bool CanPass(int diceRoll)
        {
            return true;
        }

        public void OnPass(Rider rider)
        {
            rider.Value += _encourageAmount;
        }
        
        public void OnFail(Rider rider)
        {
            // Can't fail.
        }
    }
}
