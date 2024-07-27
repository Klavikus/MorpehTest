using GameCore.Gameplay.Common.View.Systems;

namespace GameCore.Gameplay.Common.View
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