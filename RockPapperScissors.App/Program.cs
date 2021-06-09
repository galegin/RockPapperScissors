using System;

namespace RockPapperScissors.App
{
    using static MoveType;

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
            Console.Clear();
            Console.WriteLine("Part A\n");

            var gamePlay = new GamePlay(new Player("Armando", Papper), new Player("Dave", Scissors));
            
            try
            {
                gamePlay.GetWinner();
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
            Console.Clear();
            Console.WriteLine("Part B\n");

            var tournament = new GamePlay(
                new GamePlay(
                    new GamePlay(new Player("Armando", Papper), new Player("Dave", Scissors)).GetWinner(),
                    new GamePlay(new Player("Richard", Rock), new Player("Michael", Scissors)).GetWinner()
                ).GetWinner(),
                new GamePlay(
                    new GamePlay(new Player("Allen", Scissors), new Player("Omer", Papper)).GetWinner(),
                    new GamePlay(new Player("David E.", Rock), new Player("Richard X.", Papper)).GetWinner()
                ).GetWinner()
            );

            try
            {
                tournament.GetWinner();
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