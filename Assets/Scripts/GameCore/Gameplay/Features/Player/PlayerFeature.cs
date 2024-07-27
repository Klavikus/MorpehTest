using GameCore.Gameplay.Common;
using GameCore.Gameplay.Features.Player.Systems;

namespace GameCore.Gameplay.Features.Player
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