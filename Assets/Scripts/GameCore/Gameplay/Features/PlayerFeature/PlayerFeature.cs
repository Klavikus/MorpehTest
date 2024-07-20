using Code.Infrastructure.Systems;
using GameCore.Gameplay.Features.Common;
using GameCore.Gameplay.Features.PlayerFeature.Systems;

namespace GameCore.Gameplay.Features.PlayerFeature
{
    public class PlayerFeature : Feature
    {
        public PlayerFeature(ISystemFactory systemFactory)
        {
            AddInitializer(systemFactory.Create<PlayerInitSystem>());
            AddSystem(systemFactory.Create<InputToMoveSystem>());
        }
    }
}