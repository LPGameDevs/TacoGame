namespace TacosLibrary.Clearings
{
    public class WitchClearing : IClearing
    {
        private int _switchIndex = 0;

        public string Code() => "<-->";

        public WitchClearing()
        {
            WitchManager.Instance.AddWitch();
            _switchIndex = WitchManager.Instance.GetCount();
        }

        public bool CanPass(int diceRoll)
        {
            return true;
        }

        public void OnPass(Rider rider)
        {
            int max = WitchManager.Instance.GetCount();
            rider.Witch = _switchIndex < max ? _switchIndex + 1 : 1;
        }

        public void OnFail(Rider rider)
        {
            // Do nothing.
        }

        public int GetIndex()
        {
            return _switchIndex;
        }
    }
}
