using System;
using System.Linq;

namespace RockPapperScissors.Domain
{
    public static class EnumExtensions
    {
        public static TAbtrib GetAttributeEnum<TEnum, TAbtrib>(this TEnum value) 
            where TEnum : struct
            where TAbtrib : Attribute
        {
            var enumType = value.GetType().GetMember(value.ToString());
            var atrib = (TAbtrib)enumType.FirstOrDefault()?
                .GetCustomAttributes(typeof(TAbtrib), false)?.FirstOrDefault();
            return atrib;
        }
    }
}