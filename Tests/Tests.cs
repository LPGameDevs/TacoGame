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
            Game game = new Game();
            game.PlaceMap();
            Assert.AreEqual(4, game.GetMap().Length);
        }
        
        [Test]
        public void GetPlayerName_PlayerAdded_ReturnsPlayerName()
        {
            Game game = new Game();
            string playerName = "John";
            game.AddPlayer(playerName);
            
            string result = game.GetPlayerName();
            
            Assert.AreEqual(playerName, result);
        }
    }
}
