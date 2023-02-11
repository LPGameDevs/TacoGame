namespace TacosLibrary.Clearings
{
    public interface IClearing
    {
        bool CanPass(int diceRoll);

        void OnFail(Rider rider);

        string Code();
    }
}
