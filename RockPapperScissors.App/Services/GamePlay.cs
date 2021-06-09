using System;

namespace RockPapperScissors.App
{
    public class GamePlay : IGamePlay
    {
        private readonly GamePlay _gamePlay1;
        private readonly GamePlay _gamePlay2;

        private Player _player1;
        private Player _player2;

        public GamePlay(GamePlay gamePlay1, GamePlay gamePlay2)
        {
            _gamePlay1 = gamePlay1;
            _gamePlay2 = gamePlay2;
        }

        public GamePlay(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        public Player GetWinner()
        {
            if (_player1 is null & _gamePlay1 != null)
                _player1 = _gamePlay1.GetWinner();
            if (_player2 is null & _gamePlay2 != null)
                _player2 = _gamePlay2.GetWinner();

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