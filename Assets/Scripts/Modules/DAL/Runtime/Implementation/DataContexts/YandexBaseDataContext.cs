﻿#if DAL_YANDEX_GAME_PLUGIN
using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using Modules.DAL.Runtime.Abstract.Data;
using Modules.DAL.Runtime.Abstract.Serialization;
using Modules.DAL.Runtime.Implementation.Serialization;
using YG;

namespace Modules.DAL.Runtime.Implementation.DataContexts
{
    [Serializable]
    public class YandexBaseDataContext : BaseDataContext
    {
        private const string StorageKey = "YandexData";

        private IJsonSerializer _jsonSerializer;
        private bool _loadInProgress;
        private bool _saveInProgress;
        private UniTaskCompletionSource<string> _taskCompletionSource;

        public YandexBaseDataContext(IData data) : base(data)
        {
            _jsonSerializer = new JsonSerializer(data.ContainedTypes.Concat(new[] {typeof(GameDataDto)}));
        }

        public override UniTask Load()
        {
            if (_loadInProgress)
                throw new Exception($"Don't call {nameof(Load)} when load in progress!");

            _loadInProgress = true;

            _taskCompletionSource = new UniTaskCompletionSource<string>();

            // YandexGame.GetDataEvent += OnDataLoaded;

            YandexGame.LoadCloud();
            OnDataLoaded();
            return _taskCompletionSource.Task;
        }

        public override UniTask Save()
        {
            string resultJsonString = _jsonSerializer.Serialize(GameDataDto.FromGameData(Data));

            YandexGame.savesData.Data = resultJsonString;
            YandexGame.SaveProgress();

            return default;
        }

        private void OnDataLoaded()
        {
            string data = YandexGame.savesData.Data;

            GameDataDto deserializedData = _jsonSerializer.Deserialize<GameDataDto>(data);

            if (deserializedData.Equals(default(GameDataDto)) == false && deserializedData.Data != null)
            {
                Data.CopyFrom(deserializedData.Data);
            }

            _taskCompletionSource.TrySetResult(data);

            _loadInProgress = false;
        }

        private void OnDataSaved()
        {
        }
    }
}
#endif