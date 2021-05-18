using RockPapperScissors.Application;
using RockPapperScissors.Domain;
using System;

namespace RockPapperScissors.App
{
    class Program
    {
        static void Main(string[] args)
        {
            GamePartA();
            TournamentPartB();
        }

        // Part A
        /*
         [["Armando", "P"], ["Dave", "S"]]
         */
        private static void GamePartA()
        {
            var players = new Player[2]
            {
                new Player("Armando", "P"), new Player("Dave", "S"),
            };

            Console.Clear();
            Console.WriteLine("Part A\n");

            try
            {
                var winner = GameService.rps_game_winner(players);
                Console.WriteLine($"{winner.GetMoveWinner()}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
            }

            Console.Write($"Press one key to continue...");
            Console.ReadKey();
            Console.Clear();
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
        private static void TournamentPartB()
        {
            var players = new Player[2, 2, 2]
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

            Console.Clear();
            Console.WriteLine("Part B\n");

            try
            {
                var winner = GameService.rps_tournament_winner(players);
                Console.WriteLine($"{winner.GetMoveWinner()}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
            }

            Console.Write($"Press one key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}