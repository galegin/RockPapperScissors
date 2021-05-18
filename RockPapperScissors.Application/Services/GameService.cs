using RockPapperScissors.Domain;
using System;

namespace RockPapperScissors.Application
{
    public class GameService
    {
        public static Player rps_game_winner(Player[] players)
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
            else if (players[1].IsWinnerFrom(players[0]))
                return players[1];

            return null;
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
                        var player = players[x, y, z];
                        Console.WriteLine($"Player => {player.Name} / {player.Move}");
                    }

                    winners[x, y] = rps_game_winner(new[] { players[x, y, 0], players[x, y, 1] });
                    Console.WriteLine($"Player winner => {winners[x, y].Name} / {winners[x, y].Move}\n");
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
                    var player = players[x, y];
                    Console.WriteLine($"Player => {player.Name} / {player.Move}");
                }

                winners[x] = rps_game_winner(new[] { players[x, 0], players[x, 1] });
                Console.WriteLine($"Player winner => {winners[x].Name} / {winners[x].Move}\n");
            }

            var winner = rps_game_winner(new[] { winners[0], winners[1] });

            return winner;
        }
    }
};