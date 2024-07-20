using Cysharp.Threading.Tasks;
using Scellecs.Morpeh;

namespace GameCore.Gameplay.Features.Views.Factory
{
    public interface IEntityViewFactory
    {
        UniTask<EntityView> CreateForEntityAsync(Entity entity, string assetPath);
        EntityView CreateForEntityFromPrefab(Entity entity, EntityView entityViewPrefab);
    }
}