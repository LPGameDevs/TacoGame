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
            GameManager.Instance.AddPath(0);

            int startingScore = GameManager.Instance.GetScore();

            Assert.AreEqual(0, startingScore);

            Rider rider = new Rider();
            rider.Value = 3;
            GameManager.Instance.AddRider(rider);

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

            Rider rider = new Rider();
            rider.Value = dice;
            GameManager.Instance.AddRider(rider);

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

            Rider rider1 = new Rider();
            rider1.Value = dice1;
            GameManager.Instance.AddRider(rider1);

            Rider rider2 = new Rider();
            rider2.Value = dice2;
            GameManager.Instance.AddRider(rider2);

            GameManager.Instance.PlayGame();

            Assert.AreEqual(score, GameManager.Instance.GetScore());
        }

        [TestCase(3, 5, 2, 4, 0)]
        [TestCase(6, 4, 2, 5, 3)]
        [TestCase(4, 5, 2, 6, 3)]
        [TestCase(3, 5, 4, 6, 6)]
        [TestCase(5, 3, 6, 6, 6)]
        [TestCase(2, 3, 1, 3, 0)]
        [TestCase(2, 3, 1, 4, 3)]
        public void TestMultiplePaths(int path1, int path2, int dice1, int dice2, int score)
        {
            GameManager.Instance.StartGame();

            GameManager.Instance.AddPath(path1);
            GameManager.Instance.AddPath(path2);

            Rider rider1 = new Rider();
            rider1.Value = dice1;
            rider1.Path = 0;
            Rider rider2 = new Rider();
            rider2.Value = dice2;
            rider2.Path = 1;

            GameManager.Instance.AddRider(rider1);
            GameManager.Instance.AddRider(rider2);

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
            Assert.AreEqual(0, GameManager.Instance.GetRiderCount());

            GameManager.Instance.StartGame();
            GameManager.Instance.AddPath(0);

            Assert.AreEqual(0, GameManager.Instance.GetRiderCount());

            GameManager.Instance.AddRider();

            Assert.AreEqual(1, GameManager.Instance.GetRiderCount());

            GameManager.Instance.PlayGame();

            Assert.AreEqual(1, GameManager.Instance.GetRiderCount());
        }
    }

    [TestFixture]
    public class FoodTests
    {
        [Test]
        public void TestOneTaco()
        {
            GameManager.Instance.StartGame();
            GameManager.Instance.AddPath(0);

            Rider rider = new Rider();
            rider.Value = 1;
            GameManager.Instance.AddRider(rider);

            GameManager.Instance.PlayGame();

            Assert.AreEqual(3, GameManager.Instance.GetScore());
        }

        [Test]
        public void TestOneVeggie()
        {
            GameManager.Instance.StartGame();
            GameManager.Instance.AddPath(0);

            Rider rider = new Rider(Rider.FoodName.Veggie);
            rider.Value = 1;
            GameManager.Instance.AddRider(rider);

            GameManager.Instance.PlayGame();

            Assert.AreEqual(1, GameManager.Instance.GetScore());
        }

        [Test]
        public void TestTwoVeggie()
        {
            GameManager.Instance.StartGame();
            GameManager.Instance.AddPath(0);

            Rider rider = new Rider(Rider.FoodName.Veggie);
            rider.Value = 1;
            GameManager.Instance.AddRider(rider);

            rider = new Rider(Rider.FoodName.Veggie);
            rider.Value = 1;
            GameManager.Instance.AddRider(rider);

            GameManager.Instance.PlayGame();

            Assert.AreEqual(2, GameManager.Instance.GetScore());
        }

        [Test]
        public void TestTwoTacos()
        {
            GameManager.Instance.StartGame();
            GameManager.Instance.AddPath(0);

            Rider rider1 = new Rider(Rider.FoodName.Tacos);
            rider1.Value = 1;
            GameManager.Instance.AddRider(rider1);

            Rider rider2 = new Rider(Rider.FoodName.Tacos);
            rider2.Value = 1;
            GameManager.Instance.AddRider(rider2);

            GameManager.Instance.PlayGame();

            Assert.AreEqual(6, GameManager.Instance.GetScore());
        }

        [Test]
        public void TestTwoMixed()
        {
            GameManager.Instance.StartGame();
            GameManager.Instance.AddPath(0);

            Rider rider1 = new Rider(Rider.FoodName.Veggie);
            rider1.Value = 1;
            GameManager.Instance.AddRider(rider1);

            Rider rider2 = new Rider(Rider.FoodName.Tacos);
            rider2.Value = 1;
            GameManager.Instance.AddRider(rider2);

            GameManager.Instance.PlayGame();

            Assert.AreEqual(3, GameManager.Instance.GetScore());
        }

        [Test]
        public void TestThreeMixedOneTaco()
        {
            GameManager.Instance.StartGame();
            GameManager.Instance.AddPath(0);


            GameManager.Instance.AddRider(Rider.FoodName.Tacos, 1);
            GameManager.Instance.AddRider(Rider.FoodName.Veggie, 1);
            GameManager.Instance.AddRider(Rider.FoodName.Veggie, 1);

            GameManager.Instance.PlayGame();

            Assert.AreEqual(3, GameManager.Instance.GetScore());
        }

        [Test]
        public void TestThreeMixedTwoTacos()
        {
            GameManager.Instance.StartGame();
            GameManager.Instance.AddPath(0);


            GameManager.Instance.AddRider(Rider.FoodName.Tacos, 1);
            GameManager.Instance.AddRider(Rider.FoodName.Veggie, 1);
            GameManager.Instance.AddRider(Rider.FoodName.Tacos, 1);

            GameManager.Instance.PlayGame();

            Assert.AreEqual(6, GameManager.Instance.GetScore());
        }

        [Test]
        public void TestFourMixed()
        {
            GameManager.Instance.StartGame();

            GameManager.Instance.AddPath(0);

            GameManager.Instance.AddRider(Rider.FoodName.Tacos, 1);
            GameManager.Instance.AddRider(Rider.FoodName.Veggie, 1);
            GameManager.Instance.AddRider(Rider.FoodName.Veggie, 1);
            GameManager.Instance.AddRider(Rider.FoodName.Tacos, 1);

            GameManager.Instance.PlayGame();

            Assert.AreEqual(6, GameManager.Instance.GetScore());
        }
    }

    [TestFixture]
    public class PathTests
    {
        public void TestPathLength()
        {
            GameManager.Instance.StartGame();

            var paths = GameManager.Instance.GetPaths();
            Assert.AreEqual(0, paths.Count);

            GameManager.Instance.AddPath(new Path().Add(new PassClearing(1)).Add(new PassClearing(2)));
            GameManager.Instance.AddPath(new Path().Add(new PassClearing(1)));
            GameManager.Instance.AddPath(new Path().Add(new PassClearing(1)).Add(new PassClearing(2)));

            paths = GameManager.Instance.GetPaths();
            Assert.AreEqual(3, paths.Count);

            Assert.AreEqual(2, paths[0].GetClearings().Count);
            Assert.AreEqual(1, paths[1].GetClearings().Count);
            Assert.AreEqual(2, paths[2].GetClearings().Count);
        }


        [TestCase(3, 4, 1)]
        [TestCase(3, 3, 0)]
        [TestCase(3, 2, 0)]
        public void TestWyrmPath(int wyrmValue, int dice, int riders)
        {
            GameManager.Instance.StartGame();

            Rider rider = new Rider();
            rider.Value = dice;
            GameManager.Instance.AddRider(rider);

            Assert.AreEqual(1, GameManager.Instance.GetRiderCount());

            GameManager.Instance.AddPath(new Path().Add(new WyrmClearing(wyrmValue)));
            GameManager.Instance.PlayGame();

            Assert.AreEqual(riders, GameManager.Instance.GetRiderCount());
        }
        
        [TestCase(1, 4, 3, 3)]
        [TestCase(2, 3, 1, 3)]
        [TestCase(1, 1, 0, 0)]
        public void TestHenPath(int henValue, int riderBefore, int riderAfter, int finalScore)
        {
            GameManager.Instance.StartGame();

            Rider rider = new Rider();
            rider.Value = riderBefore;
            GameManager.Instance.AddRider(rider);
            
            GameManager.Instance.AddPath(new Path().Add(new HenClearing(henValue)));
            GameManager.Instance.PlayGame();

            Assert.AreEqual(riderAfter, GameManager.Instance.GetRiders()[0].Value);
            Assert.AreEqual(finalScore, GameManager.Instance.GetScore());
        }
        
        [TestCase(1, 4, 5)]
        [TestCase(2, 3, 5)]
        [TestCase(1, 1, 2)]
        public void TestElfPath(int elfValue, int riderBefore, int riderAfter)
        {
            GameManager.Instance.StartGame();

            Rider rider = new Rider();
            rider.Value = riderBefore;
            GameManager.Instance.AddRider(rider);
            
            GameManager.Instance.AddPath(new Path().Add(new ElfClearing(elfValue)));
            GameManager.Instance.PlayGame();

            Assert.AreEqual(riderAfter, GameManager.Instance.GetRiders()[0].Value);
        }
    }
}
