namespace RockPapperScissors.App
{
    public class Player
    {
        public string Name { get; set; }
        public MoveType Move { get; set; }

        public Player(string name, MoveType move)
        {
            Name = name;
            Move = move;
        }
    }

    public static class PlayerExtensions
    {
        public static bool IsTieWith(this Player player, Player playerFrom)
        {
            return player.Move.Equals(playerFrom.Move);
        }

        public static bool IsWinnerFrom(this Player player, Player playerFrom)
        {
            return player.Move.IsWinnerFrom(playerFrom.Move);
        }

        public static string GetMove(this Player player)
        {
            return $"Player => {player.Name} move {player.Move}";
        }

        public static string GetMoveWinner(this Player player)
        {
            return $"Player winner => {player.Name} with move {player.Move}";
        }
    }
}