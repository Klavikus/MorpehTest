using System;
using System.Collections.Generic;
using GameCore.Domain.Dto;
using GameCore.Domain.Enums;
using GameCore.Domain.JsonConverters;
using Newtonsoft.Json;
using R3;

namespace GameCore.Domain.Models
{
    [Serializable]
    [JsonConverter(typeof(ModelJsonConverter<PlayerCurrencyDto>))]
    public class PlayerCurrency : BaseEntity, ISerializable<PlayerCurrencyDto>
    {
        public static string DefaultId = nameof(PlayerCurrency);

        private Dictionary<CurrencyType, ReactiveProperty<int>> _currencyByType;

        public PlayerCurrency() : base(DefaultId)
        {
            Soft = new ReactiveProperty<int>(123);
            Hard = new ReactiveProperty<int>(33);

            _currencyByType = new Dictionary<CurrencyType, ReactiveProperty<int>>()
            {
                [CurrencyType.Hard] = Hard,
                [CurrencyType.Soft] = Soft,
            };
        }

        public ReactiveProperty<int> Soft { get; private set; }
        public ReactiveProperty<int> Hard { get; private set; }

        public void Add(int amount, CurrencyType currencyType)
        {
            if (amount <= 0)
                throw new Exception($"Can't {nameof(Add)} with amount <= 0!");

            _currencyByType[currencyType].Value += amount;
        }

        public void Remove(int amount, CurrencyType currencyType)
        {
            if (amount < 0)
                throw new Exception($"Can't {nameof(Remove)} with amount < 0!");

            _currencyByType[currencyType].Value -= amount;
        }

        public PlayerCurrencyDto Serialize()
        {
            return new PlayerCurrencyDto
            {
                Soft = Soft.Value,
                Hard = Hard.Value,
            };
        }

        public void Deserialize(PlayerCurrencyDto dto)
        {
            Soft.Value = dto.Soft;
            Hard.Value = dto.Hard;
        }
    }
}