using Cysharp.Threading.Tasks;
using Scellecs.Morpeh;
using UnityEngine;

namespace GameCore.Gameplay.Common.View.Factory
{
    public interface IEntityViewFactory
    {
        EntityView CreateForEntityFromPrefab(Entity entity, EntityView entityViewPrefab);

        UniTask<EntityView> CreateForEntityAsync(
            Entity entity,
            string assetPath,
            Vector3 position,
            Vector3 rotation);

        UniTask<EntityView> CreateForEntityAsync(Entity entity, string assetPath);
    }
}