using GameCore.Gameplay.Features.Common;
using GameCore.Gameplay.Features.PlayerFeature.Systems;

namespace GameCore.Gameplay.Features.PlayerFeature
{
    public class PlayerFeature : Feature
    {
        public PlayerFeature()
        {
            AddInitializer<PlayerInitSystem>();
            AddSystem<InputToMoveSystem>();
        }
    }
}