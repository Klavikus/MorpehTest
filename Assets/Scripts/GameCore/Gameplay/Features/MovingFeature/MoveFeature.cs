using Code.Infrastructure.Systems;
using GameCore.Gameplay.Features.Common;
using GameCore.Gameplay.Features.MovingFeature.Systems;

namespace GameCore.Gameplay.Features.MovingFeature
{
    public class MoveFeature : Feature
    {
        public MoveFeature(ISystemFactory systemFactory)
        {
            AddSystem(systemFactory.Create<MoveSystem>());
        }
    }
}