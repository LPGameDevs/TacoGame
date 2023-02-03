using NUnit.Framework;
using TacosLibrary;

namespace Tests
{
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void IsNumberEven_InputIsEven_ReturnsEven()
        {
            string input = "2";
            string expectedResult = "even";
            
            string result = Numbers.IsNumberEven(input);
            
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test]
        public void IsNumberEven_InputIsOdd_ReturnsOdd()
        {
            string input = "1";
            string expectedResult = "odd";
            
            string result = Numbers.IsNumberEven(input);
            
            Assert.AreEqual(expectedResult, result);
        }
    }
    
    [TestFixture]
    public class GameTests
    {

        [Test]
        public void TestPlaceMap()
        {
            Game.Instance.PlaceMap();
            Assert.AreEqual(4, Game.Instance.GetMap().Length);
        }
        
        [Test]
        public void GetPlayerName_PlayerAdded_ReturnsPlayerName()
        {
            string playerName = "John";
            Game.Instance.AddPlayer(playerName);
            
            string result = Game.Instance.GetPlayerName();
            
            Assert.AreEqual(playerName, result);
        }
    }
}
