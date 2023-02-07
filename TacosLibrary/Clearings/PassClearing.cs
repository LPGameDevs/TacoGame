namespace TacosLibrary.Clearings
{
    public class PassClearing : IClearing
    {
        protected int _passValue;
        
        public PassClearing(int passValue)
        {
            _passValue = passValue;
        }

        public bool CanPass(int diceRoll)
        {
            return diceRoll > _passValue;
        }

        public virtual void OnFail()
        {
            // Drop the food.
        }
    }
}
