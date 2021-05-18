using RockPapperScissors.Application;
using RockPapperScissors.Domain;
using System;

namespace RockPapperScissors.App
{
    class Program
    {
        static void Main(string[] args)
        {
            // Part A
            /*
             [["Armando", "P"], ["Dave", "S"]]
             */
            var players = new Player[2]
            {
                new Player("Armando", "P"), new Player("Dave", "S"),
            };

            try
            {
                Console.WriteLine($"Part A\n");
                var gameWiner = GameService.rps_game_winner(players);
                Console.WriteLine($"Player winner is {gameWiner.Name} with move {gameWiner.Move}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
            }

            // Part B
            /*
            [
             [
              [["Armando", "P"], ["Dave", "S"]],
              [["Richard", "R"], ["Michael", "S"]],
             ],
             [
              [["Allen", "S"], ["Omer", "P"]],
              [["David E.", "R"], ["Richard X.", "P"]]
             ]
            ]
            */
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

            try
            {
                Console.WriteLine($"Part B\n");
                var tournamentWiner = GameService.rps_tournament_winner(playersTournament);
                Console.WriteLine($"Player winner is {tournamentWiner.Name} with move {tournamentWiner.Move}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
            }

            Console.WriteLine($"\nPress one key to continue...");
            Console.ReadKey();
        }
    }
}