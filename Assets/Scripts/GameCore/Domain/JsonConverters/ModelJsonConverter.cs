using System;
using GameCore.Domain.Models;
using Newtonsoft.Json;

namespace GameCore.Domain.JsonConverters
{
    public class ModelJsonConverter<T> : JsonConverter<ISerializable<T>>
        where T : struct
    {
        public override void WriteJson(JsonWriter writer, ISerializable<T> value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.Serialize());
        }

        public override ISerializable<T> ReadJson(
            JsonReader reader,
            Type objectType,
            ISerializable<T> existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            return serializer.Deserialize<ISerializable<T>>(reader);
        }
    }
}