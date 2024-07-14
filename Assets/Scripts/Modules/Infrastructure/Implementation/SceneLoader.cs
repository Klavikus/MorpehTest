using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Modules.Infrastructure.Implementation
{
    public class SceneLoader
    {
        public UniTask LoadAsync(string nextScene) =>
            SceneManager.LoadSceneAsync(nextScene).ToUniTask();
    }
}