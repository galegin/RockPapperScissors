namespace RockPapperScissors.App
{
    public class GamePlayDecoretor : IGamePlay
    {
        private readonly IGamePlay _gamePlay;

        public GamePlayDecoretor(IGamePlay gamePlay)
        {
            _gamePlay = gamePlay;
        }

        public Player GetWinner()
        {
            return _gamePlay.GetWinner();
        }
    }
}