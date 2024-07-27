using GameCore.Gameplay.Common;
using GameCore.Gameplay.Features.ViewFeature.Systems;

namespace GameCore.Gameplay.Features.ViewFeature
{
    public class ViewFeature : Feature
    {
        public ViewFeature()
        {
            AddSystem<BindEntityViewFromPathSystem>();
            AddSystem<BindEntityViewFromPrefabSystem>();
        }
    }
}