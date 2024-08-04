using System;
using GameCore.Domain.JsonConverters;
using Newtonsoft.Json;
using R3;

namespace GameCore.Domain.Models
{
    [Serializable]
    public class HeroSelection : BaseEntity
    {
        public static string DefaultId = nameof(HeroSelection);

        public HeroSelection() : base(DefaultId)
        {
            SelectedId = new ReactiveProperty<int>(0);
        }

        [JsonConverter(typeof(ReactivePropertyConverter))]
        public ReactiveProperty<int> SelectedId { get; private set; }

        public void Select(int id)
        {
            if (id < 0)
                throw new Exception($"Can't {nameof(Select)} level with id:'{id}'!");

            SelectedId.Value = id;
        }
    }
}