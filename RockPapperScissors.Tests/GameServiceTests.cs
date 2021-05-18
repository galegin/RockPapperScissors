using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPapperScissors.Application;
using RockPapperScissors.Domain;

namespace RockPapperScissors.Tests
{
    [TestClass]
    public class GameServiceTests
    {
        [TestMethod]
        public void TestMethod_GameWinner()
        {
            var players = new Player[2]
            {
                new Player("Armando", "P"),
                new Player("Dave", "S"),
            };
            var winner = GameService.rps_game_winner(players);
            Assert.AreEqual("Dave", winner.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(WrongNumberOfPlayersError))]
        public void TestMethod_WithOnePlayer()
        {
            var players = new Player[1]
            {
                new Player("Armando", "P"),
            };
            GameService.rps_game_winner(players);
        }

        [TestMethod]
        [ExpectedException(typeof(NoSuchStrategyError))]
        public void TestMethod_WithMoveInvalid()
        {
            var players = new Player[2]
            {
                new Player("Armando", "P"),
                new Player("Dave", ""),
            };
            GameService.rps_game_winner(players);
        }

        [TestMethod]
        public void TestMethod_TournamentWinner()
        {
            var playersTournament = new Player[2, 2, 2]
            {
                {
                    { new Player("Armando", "P"), new Player("Dave", "S") },
                    { new Player("Richard", "R"), new Player("Michael", "S") },
                },
                {
                    { new Player("Allen", "S"), new Player("Omer", "P") },
                    { new Player("David E.", "R"), new Player("Richard X.", "P") },
                },
            };
            var winner = GameService.rps_tournament_winner(playersTournament);
            Assert.AreEqual("Richard", winner.Name);
        }
    }
}
