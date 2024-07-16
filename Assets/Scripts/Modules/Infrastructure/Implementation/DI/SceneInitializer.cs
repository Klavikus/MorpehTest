using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using VContainer;
using Object = UnityEngine.Object;

namespace Modules.Infrastructure.Implementation.DI
{
    public class SceneInitializer
    {
        public UniTask Initialize(IObjectResolver objectResolver)
        {
            SceneCompositionRoot[] compositionRoots = Object.FindObjectsOfType<SceneCompositionRoot>();

            if (compositionRoots.Length > 1)
            {
                throw new Exception($"Scene has multiple composition roots!" +
                                    " Must use only one composition root" +
                                    $" roots:{string.Join(",", compositionRoots.Select(root => root.name))}");
            }

            return compositionRoots[0].Initialize(objectResolver);
        }
    }
}