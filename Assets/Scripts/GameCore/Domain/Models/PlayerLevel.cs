using System;
using GameCore.Domain.JsonConverters;
using Newtonsoft.Json;
using R3;

namespace GameCore.Domain.Models
{
    [Serializable]
    public class PlayerLevel : BaseEntity
    {
        public static string DefaultId = nameof(PlayerLevel);

        public PlayerLevel() : base(DefaultId)
        {
            CurrentLevel = new ReactiveProperty<int>(1);
            MaxLevel = new ReactiveProperty<int>(100);
            CurrentExp = new ReactiveProperty<int>(33);
            ExpToLevelup = new ReactiveProperty<int>(100);
        }

        [JsonConverter(typeof(ReactivePropertyConverter))]
        public ReactiveProperty<int> CurrentLevel { get; private set; }

        [JsonConverter(typeof(ReactivePropertyConverter))]
        public ReactiveProperty<int> MaxLevel { get; private set; }

        [JsonConverter(typeof(ReactivePropertyConverter))]
        public ReactiveProperty<int> CurrentExp { get; private set; }

        [JsonConverter(typeof(ReactivePropertyConverter))]
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

            for (int i = 0; i < CurrentExp.Value / ExpToLevelup.Value; i++)
            {
                CurrentExp.Value -= ExpToLevelup.Value;
                LevelUp();
            }
        }
    }
}