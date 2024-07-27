using GameCore.Gameplay.Common;
using GameCore.Gameplay.Features.Movement.Systems;

namespace GameCore.Gameplay.Features.Movement
{
    public class MoveFeature : Feature
    {
        public MoveFeature()
        {
            AddSystem<AlignRotationWithMoveDirectionSystem>();
            AddSystem<MoveSystem>();
            AddSystem<RotationSystem>();
            AddSystem<MoveWithRotationSystem>();
            AddSystem<SyncTransformWithWorldPositionSystem>();
        }
    }
}