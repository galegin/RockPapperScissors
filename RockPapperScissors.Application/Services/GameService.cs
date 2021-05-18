using RockPapperScissors.Domain;
using System;

namespace RockPapperScissors.Application
{
    public class GameService
    {
        public static Player rps_game_winner(params Player[] players)
        {
            if (players.Length != 2)
                throw new WrongNumberOfPlayersError();

            foreach (var player in players)
                if (!player.Move.IsValid())
                    throw new NoSuchStrategyError();

            if (players[0].IsTieWith(players[1]))
                return players[0];
            else if (players[0].IsWinnerFrom(players[1]))
                return players[0];
            else
                return players[1];
        }

        public static Player rps_tournament_winner(Player[,,] players)
        {
            var winners = new Player[players.GetLength(0), players.GetLength(1)];

            for (int x = 0; x < players.GetLength(0); x += 1)
            {
                for (int y = 0; y < players.GetLength(1); y += 1)
                {
                    for (int z = 0; z < players.GetLength(2); z += 1)
                    {
                        Console.WriteLine(players[x, y, z].GetMove());
                    }

                    winners[x, y] = rps_game_winner(players[x, y, 0], players[x, y, 1]);
                    Console.WriteLine($"{winners[x, y].GetMoveWinner()}\n");
                }
            }

            var winner = rps_tournament_winner(winners);

            return winner;
        }
        
        public static Player rps_tournament_winner(Player[,] players)
        {
            var winners = new Player[players.GetLength(0)];

            for (int x = 0; x < players.GetLength(0); x += 1)
            {
                for (int y = 0; y < players.GetLength(1); y += 1)
                {
                    Console.WriteLine(players[x, y].GetMove());
                }

                winners[x] = rps_game_winner(players[x, 0], players[x, 1]);
                Console.WriteLine($"{winners[x].GetMoveWinner()}\n");
            }

            var winner = rps_game_winner(winners[0], winners[1]);

            return winner;
        }
    }
};