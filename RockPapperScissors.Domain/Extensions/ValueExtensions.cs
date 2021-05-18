using System.Linq;

namespace RockPapperScissors.Domain
{
    public static class ValueExtensions
    {
        public static bool In<T>(this T value, params T[] values)
            => values.Contains(value);
    }
}