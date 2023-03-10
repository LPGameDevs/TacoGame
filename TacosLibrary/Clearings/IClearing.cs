namespace TacosLibrary.Clearings
{
    public interface IClearing
    {
        bool CanPass(int diceRoll);

        void OnFail(Rider rider);
        void OnPass(Rider rider);

        string Code();
    }
}
