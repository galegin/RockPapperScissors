namespace RockPapperScissors.App
{
    public enum MoveType
    {
        Rock,
        Papper,
        Scissors,
    }

    public static class MoveTypeExtensions
    {
        public static MoveType IsWinnerFrom(this MoveType type)
        {
            switch (type)
            {
                case MoveType.Rock:
                    return MoveType.Scissors;
                case MoveType.Papper:
                    return MoveType.Rock;
                case MoveType.Scissors:
                    return MoveType.Papper;
            }

            return default;
        }

        public static bool IsWinnerFrom(this MoveType move, MoveType moveFrom)
        {
            return move.IsWinnerFrom().Equals(moveFrom);
        }
    }
}