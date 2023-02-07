namespace TacosLibrary.Clearings
{
    public class PassClearing : IClearing
    {
        private int _passValue;
        
        public PassClearing(int passValue)
        {
            _passValue = passValue;
        }

        public bool CanPass(int diceRoll)
        {
            return diceRoll > _passValue;
        }
    }
}
