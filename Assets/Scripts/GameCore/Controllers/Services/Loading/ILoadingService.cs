using System;
using Cysharp.Threading.Tasks;
using Qw1nt.Runtime.Shared.AddressablesContentController.SceneManagement;
using VContainer;

namespace GameCore.Controllers.Services.Loading
{
    public interface ILoadingService
    {
        event Action<float, string> ProgressUpdated;
        event Action Started;
        event Action Completed;
        bool InProgress { get; }
        float Progress { get; }
        string Description { get; }
        void AddToQueue(Func<IProgress<float>, UniTask> operation, string description, float weight = 1f);
        UniTask Load();
        void Purge();
        void LoadScene(SceneData sceneData, IObjectResolver objectResolver);
    }
}