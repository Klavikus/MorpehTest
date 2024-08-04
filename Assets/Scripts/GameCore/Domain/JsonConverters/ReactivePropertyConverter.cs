using System;
using Newtonsoft.Json;
using R3;
using UnityEngine;

namespace GameCore.Domain.JsonConverters
{
    public class ReactivePropertyConverter : JsonConverter<ReactiveProperty<int>>
    {
        public override void WriteJson(JsonWriter writer, ReactiveProperty<int> value, JsonSerializer serializer)
        {
            writer.WriteValue(value.Value);
        }

        public override ReactiveProperty<int> ReadJson(
            JsonReader reader,
            Type objectType,
            ReactiveProperty<int> existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            int value = reader.Value != null ? Convert.ToInt32(reader.Value) : 0;

            if (hasExistingValue)
            {
                existingValue.Value = value;

                return existingValue;
            }

            return new ReactiveProperty<int>(value);
        }
    }
}