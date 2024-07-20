using Code.Infrastructure.Systems;
using GameCore.Gameplay.Features.Common;
using GameCore.Gameplay.Features.ViewFeature.Systems;

namespace GameCore.Gameplay.Features.ViewFeature
{
    public class ViewFeature : Feature
    {
        public ViewFeature(ISystemFactory systemFactory)
        {
            AddSystem(systemFactory.Create<BindEntityViewFromPathSystem>());
            AddSystem(systemFactory.Create<BindEntityViewFromPrefabSystem>());
        }
    }
}