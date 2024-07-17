using System;
using Newtonsoft.Json;
using R3;

namespace GameCore.Domain.Models
{
    [Serializable]
    [JsonConverter(typeof(ModelJsonConverter<PlayerLevelDto>))]
    public class PlayerLevel : BaseEntity, ISerializable<PlayerLevelDto>
    {
        public static string DefaultId = nameof(PlayerLevel);

        public PlayerLevel() : base(DefaultId)
        {
            CurrentLevel = new ReactiveProperty<int>(1);
            MaxLevel = new ReactiveProperty<int>(100);
            CurrentExp = new ReactiveProperty<int>(0);
            ExpToLevelup = new ReactiveProperty<int>(100);
        }

        public ReactiveProperty<int> CurrentLevel { get; private set; }
        public ReactiveProperty<int> MaxLevel { get; private set; }
        public ReactiveProperty<int> CurrentExp { get; private set; }
        public ReactiveProperty<int> ExpToLevelup { get; private set; }
        public bool MaxLevelReached => CurrentLevel.Value == MaxLevel.Value;

        public void LevelUp()
        {
            if (MaxLevel == CurrentLevel)
                throw new Exception($"Can't {nameof(LevelUp)} when MaxLevel reached!");

            CurrentLevel.Value++;
        }

        public void AddExp(int amount)
        {
            if (MaxLevel == CurrentLevel)
                throw new Exception($"Can't {nameof(AddExp)} when MaxLevel reached!");

            CurrentExp.Value += amount;

            if (CurrentExp.Value < ExpToLevelup.Value)
                return;

            for (int i = 0; i < CurrentExp.Value % ExpToLevelup.Value; i++)
            {
                CurrentExp.Value -= ExpToLevelup.Value;
                LevelUp();
            }
        }

        public PlayerLevelDto Serialize()
        {
            return new PlayerLevelDto
            {
                CurrentLevel = CurrentExp.Value,
                MaxLevel = MaxLevel.Value,
                CurrentExp = CurrentExp.Value,
                ExpToLevelup = ExpToLevelup.Value
            };
        }

        public void Deserialize(PlayerLevelDto dto)
        {
            CurrentLevel.Value = dto.CurrentLevel;
            MaxLevel.Value = dto.MaxLevel;
            CurrentExp.Value = dto.CurrentExp;
            ExpToLevelup.Value = dto.ExpToLevelup;
        }
    }
}