using System;
using GameCore.Domain.Dto;
using GameCore.Domain.JsonConverters;
using Newtonsoft.Json;
using R3;

namespace GameCore.Domain.Models
{
    [Serializable]
    [JsonConverter(typeof(ModelJsonConverter<LevelSelectionDto>))]
    public class LevelSelection : BaseEntity, ISerializable<LevelSelectionDto>
    {
        public static string DefaultId = nameof(LevelSelection);

        public LevelSelection() : base(DefaultId)
        {
            SelectedId = new ReactiveProperty<int>(0);
        }

        public ReactiveProperty<int> SelectedId { get; private set; }

        public void Select(int levelId)
        {
            if (levelId < 0)
                throw new Exception($"Can't {nameof(Select)} level with id:'{levelId}'!");

            SelectedId.Value = levelId;
        }

        public LevelSelectionDto Serialize()
        {
            return new LevelSelectionDto
            {
                SelectedId = SelectedId.Value,
            };
        }

        public void Deserialize(LevelSelectionDto dto)
        {
            SelectedId.Value = dto.SelectedId;
        }
    }
}