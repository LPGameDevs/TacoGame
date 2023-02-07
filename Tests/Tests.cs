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

        [TestCase(6, 2, 0)]
        public void TestMultiplePaths(int path, int dice, int score)
        {
            return;
            // Test rolling 4 or higher to win.
            
            GameManager.Instance.StartGame();
            GameManager.Instance.AddPath(path);
            GameManager.Instance.RollDice(dice);
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
}
