namespace RockPapperScissors.Domain
{
    public class Player
    {
        public string Name { get; set; }
        public string Move { get; set; }

        public Player(string name, string move)
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
    }
}