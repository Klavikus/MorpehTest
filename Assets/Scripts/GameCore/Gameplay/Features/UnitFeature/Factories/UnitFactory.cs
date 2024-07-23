using GameCore.Gameplay.Features.MovingFeature.Components;
using GameCore.Gameplay.Features.UnitFeature.Components;
using Scellecs.Morpeh;

namespace GameCore.Gameplay.Features.UnitFeature.Factories
{
    public class UnitFactory
    {
        public Entity Build(World world)
        {
            var entity = world.CreateEntity();
            entity.AddComponent<UnitTag>();
            entity.AddComponent<MoveDirectionComponent>();
            entity.AddComponent<RotationComponent>();
            entity.AddComponent<MoveWithRotationTag>();
            entity.AddComponent<AlignRotationWithMoveDirectionTag>();
            entity.AddComponent<MoveSpeedComponent>();

            return entity;
        }
    }
}