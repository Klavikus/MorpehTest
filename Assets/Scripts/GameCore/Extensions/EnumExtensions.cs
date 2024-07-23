using System;
using System.Collections.Generic;
using System.Linq;

namespace GameCore.Extensions
{
    public static class EnumExtensions
    {
        public static Dictionary<TEnum, TValue> ToDictionary<TEnum, TValue>(TValue defaultValue, int startIndex = 0) 
            where TEnum : struct, Enum
        {
            var enumValues = Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToList();
            var dictionary = new Dictionary<TEnum, TValue>();

            for (int i = startIndex; i < enumValues.Count; i++)
            {
                dictionary[enumValues[i]] = defaultValue;
            }

            return dictionary;
        }
    }
}