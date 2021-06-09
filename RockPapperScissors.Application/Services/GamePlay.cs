using RockPapperScissors.Domain;
using System;

namespace RockPapperScissors.Application
{
    public class GamePlay
    {
        private readonly Player _player1;
        private readonly Player _player2;

        public GamePlay(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        public Player GetWinner()
        {
            Console.WriteLine(_player1.GetMove());
            Console.WriteLine(_player2.GetMove());

            var winner = _player1.IsTieWith(_player2) | _player1.IsWinnerFrom(_player2) 
                ? _player1 : _player2;

            Console.WriteLine(winner.GetMoveWinner());
            Console.WriteLine("");

            return winner;
        }
    }
}