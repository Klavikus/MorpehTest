using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GameCore.Controllers.Dto;

namespace GameCore.Controllers.Services.Loading
{
    public class LoadingService : ILoadingService
    {
        private readonly Queue<LoadingInfo> _loadingQueue = new();
        
        private float _totalWeight;

        public event Action<float, string> ProgressUpdated;
        public event Action Started;
        public event Action Completed;
        
        public bool InProgress { get; private set; }
        public float Progress { get; private set; }
        public string Description { get; private set; }

        public void AddToQueue(Func<IProgress<float>, UniTask> operation, string description, float weight = 1f)
        {
            _loadingQueue.Enqueue(new LoadingInfo
            {
                AsyncOperation = operation,
                Description = description,
                Weight = weight
            });
            _totalWeight += weight;
        }

        public async UniTask Load()
        {
            InProgress = true;

            Started?.Invoke();
            Progress = 0f;
            float weightProcessed = 0f;

            while (_loadingQueue.Count > 0)
            {
                LoadingInfo loadingInfo = _loadingQueue.Dequeue();
                float processed = weightProcessed;
                Description = loadingInfo.Description;

                IProgress<float> progress = new Progress<float>(p =>
                {
                    float weightedProgress = p * loadingInfo.Weight;
                    Progress = (processed + weightedProgress) / _totalWeight;
                    ProgressUpdated?.Invoke(Progress, loadingInfo.Description);
                });

                await loadingInfo.AsyncOperation.Invoke(progress);
                weightProcessed += loadingInfo.Weight;
            }

            InProgress = false;
            Completed?.Invoke();
        }

        public void Purge()
        {
            _totalWeight = 0;
            Progress = 0;
            InProgress = false;
            Description = string.Empty;
        }
    }
}