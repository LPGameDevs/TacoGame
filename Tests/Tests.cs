using NUnit.Framework;
using TacosLibrary;
using TacosLibrary.Clearings;

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
        public void TestGameScore()
        {
            GameManager.Instance.StartGame();
            int startingScore = GameManager.Instance.GetScore();

            Assert.AreEqual(0, startingScore);

            GameManager.Instance.RollDice(3);
            GameManager.Instance.PlayGame();
            int finalScore = GameManager.Instance.GetScore();

            Assert.AreEqual(3, finalScore);
        }
        
        [Test]
        public void TestGameOver()
        {
            bool gameOver = GameManager.Instance.IsGameOver();
            Assert.AreEqual(true, gameOver);

            GameManager.Instance.StartGame();

            gameOver = GameManager.Instance.IsGameOver();
            Assert.AreEqual(false, gameOver);

            GameManager.Instance.PlayGame();

            gameOver = GameManager.Instance.IsGameOver();
            Assert.AreEqual(true, gameOver);
        }

        [TestCase(3, 2, 0)]
        [TestCase(3, 3, 0)]
        [TestCase(3, 4, 3)]
        [TestCase(1, 2, 3)]
        [TestCase(6, 2, 0)]
        public void TestRollDice(int path, int dice, int score)
        {
            GameManager.Instance.StartGame();
            GameManager.Instance.AddPath(path);
            GameManager.Instance.RollDice(dice);
            GameManager.Instance.PlayGame();
            
            Assert.AreEqual(score, GameManager.Instance.GetScore());
        }
        
        [TestCase(6, 2, 4, 0)]
        [TestCase(4, 2, 5, 3)]
        [TestCase(2, 3, 4, 6)]
        public void TestRollMultipleDice(int path, int dice1, int dice2, int score)
        {
            GameManager.Instance.StartGame();
            GameManager.Instance.AddPath(path);
            GameManager.Instance.RollDice(dice1);
            GameManager.Instance.RollDice(dice2);
            GameManager.Instance.PlayGame();
            
            Assert.AreEqual(score, GameManager.Instance.GetScore());
        }

        [TestCase(6,4, 2, 3, 0)]
        [TestCase(6,4, 2, 5, 0)]
        [TestCase(4,5, 2, 6, 3)]
        [TestCase(3,5, 4, 6, 3)]
        [TestCase(5,3, 6, 6, 6)]
        [TestCase(2,3, 1, 3, 0)]
        [TestCase(2,3, 1, 4, 3)]
        public void TestMultiplePaths(int path1, int path2, int dice1, int dice2, int score)
        {
            GameManager.Instance.StartGame();
            GameManager.Instance.AddPath(path1);
            GameManager.Instance.AddPath(path2);
            GameManager.Instance.RollDice(dice1);
            GameManager.Instance.RollDice(dice2);
            GameManager.Instance.PlayGame();
            
            Assert.AreEqual(score, GameManager.Instance.GetScore());
        }
        
        [Test]
        public void TestPlaceMap()
        {
            GameManager.Instance.PlaceMap();
            Assert.AreEqual(4, GameManager.Instance.GetMap().Length);
        }

        [Test]
        public void GetPlayerName_PlayerAdded_ReturnsPlayerName()
        {
            string playerName = "John";
            GameManager.Instance.AddPlayer(playerName);
            
            string result = GameManager.Instance.GetPlayerName();
            
            Assert.AreEqual(playerName, result);
        }
    }

    [TestFixture]
    public class RiderTests
    {
        [Test]
        public void TestRiders()
        {
            Assert.AreEqual(0, GameManager.Instance.GetRiders());

            GameManager.Instance.StartGame();
            
            Assert.AreEqual(0, GameManager.Instance.GetRiders());
            
            GameManager.Instance.AddRider();
            
            Assert.AreEqual(1, GameManager.Instance.GetRiders());

            GameManager.Instance.PlayGame();

            Assert.AreEqual(1, GameManager.Instance.GetRiders());
        }
    }

    [TestFixture]
    public class PathTests
    {
        
        [TestCase(3, 4, 1)]
        [TestCase(3, 3, 0)]
        [TestCase(3, 2, 0)]
        public void TestWyrmPath(int wyrmValue, int dice, int riders)
        {
            GameManager.Instance.StartGame();
            GameManager.Instance.AddRider();
            GameManager.Instance.AddPath(new WyrmClearing(wyrmValue));
            GameManager.Instance.RollDice(dice);
            GameManager.Instance.PlayGame();
            
            Assert.AreEqual(riders, GameManager.Instance.GetRiders());
        }

    }
}
