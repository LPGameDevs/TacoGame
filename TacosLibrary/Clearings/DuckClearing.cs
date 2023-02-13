namespace TacosLibrary.Clearings
{
    public class DuckClearing : IClearing
    {
        private int _duckValue;

        public string Code() => "D";

        public DuckClearing(int duckValue)
        {
            _duckValue = duckValue;
        }

        public bool CanPass(int diceRoll)
        {
            return true;
        }

        public void OnFail(Rider rider)
        {
            // Do nothing.
        }

        public void OnPass(Rider rider)
        {
            if (rider.Value > _duckValue)
            {
                rider.Delivered = true;
            }
        }
    }
}
