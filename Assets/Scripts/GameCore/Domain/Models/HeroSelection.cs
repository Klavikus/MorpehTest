using System;
using GameCore.Domain.Dto;
using GameCore.Domain.JsonConverters;
using Newtonsoft.Json;
using R3;

namespace GameCore.Domain.Models
{
    [Serializable]
    [JsonConverter(typeof(ModelJsonConverter<HeroSelectionDto>))]
    public class HeroSelection : BaseEntity, ISerializable<HeroSelectionDto>
    {
        public static string DefaultId = nameof(HeroSelection);

        public HeroSelection() : base(DefaultId)
        {
            SelectedId = new ReactiveProperty<int>(0);
        }

        public ReactiveProperty<int> SelectedId { get; private set; }

        public void Select(int id)
        {
            if (id < 0)
                throw new Exception($"Can't {nameof(Select)} level with id:'{id}'!");

            SelectedId.Value = id;
        }

        public HeroSelectionDto Serialize()
        {
            return new HeroSelectionDto
            {
                SelectedId = SelectedId.Value,
            };
        }

        public void Deserialize(HeroSelectionDto dto)
        {
            SelectedId.Value = dto.SelectedId;
        }
    }
}