using System;
using System.Xml.Serialization;

namespace RockPapperScissors.Domain
{
    public enum MoveType
    {
        None,

        [XmlEnum("R")]
        Rock,
        
        [XmlEnum("P")]
        Papper,
        
        [XmlEnum("S")]
        Scissors,
    }

    public static class MoveTypeExtensions
    {
        public static bool IsNone(this MoveType type)
            => type.In(MoveType.None);

        public static bool IsRock(this MoveType type)
            => type.In(MoveType.Rock);
        public static bool IsPapper(this MoveType type)
            => type.In(MoveType.Papper);
        public static bool IsScissors(this MoveType type)
            => type.In(MoveType.Scissors);

        public static string GetXmlEnum(this MoveType type)
        {
            var xmlEnum = type.GetAttributeEnum<MoveType, XmlEnumAttribute>();
            return xmlEnum?.Name;
        }

        public static MoveType GetMoveType(this string valueStr)
        {
            var values = Enum.GetValues(typeof(MoveType));

            foreach (var value in values)
            {
                var moveType = (MoveType)value;
                var xmlEnum = moveType.GetXmlEnum();
                if (xmlEnum?.Equals(valueStr) ?? false)
                    return moveType;
            }

            return default;
        }

        public static bool IsValid(this string value)
        {
            return !value.GetMoveType().IsNone();
        }

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

        public static bool IsWinnerFrom(this string move, string moveFrom)
        {
            var moveType = move.GetMoveType();
            var moveTypeFrom = moveFrom.GetMoveType();
            return moveType.IsWinnerFrom().Equals(moveTypeFrom);
        }
    }
}