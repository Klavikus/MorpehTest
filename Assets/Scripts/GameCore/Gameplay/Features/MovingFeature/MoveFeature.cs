using GameCore.Gameplay.Common;
using GameCore.Gameplay.Features.MovingFeature.Systems;

namespace GameCore.Gameplay.Features.MovingFeature
{
    public class MoveFeature : Feature
    {
        public MoveFeature()
        {
            AddSystem<AlignRotationWithMoveDirectionSystem>();
            AddSystem<MoveSystem>();
            AddSystem<RotationSystem>();
            AddSystem<MoveWithRotationSystem>();
        }
    }
}