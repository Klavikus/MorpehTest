using Cysharp.Threading.Tasks;
using Scellecs.Morpeh;

namespace GameCore.Gameplay.Features.ViewFeature.Factory
{
    public interface IEntityViewFactory
    {
        UniTask<EntityView> CreateForEntityAsync(Entity entity, string assetPath);
        EntityView CreateForEntityFromPrefab(Entity entity, EntityView entityViewPrefab);
    }
}