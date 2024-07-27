using GameCore.Gameplay.Features.Movement.Components;
using GameCore.Gameplay.Features.Units.Components;
using Scellecs.Morpeh;

namespace GameCore.Gameplay.Features.Units.Factories
{
    public class UnitFactory
    {
        public Entity Build(World world)
        {
            var entity = world.CreateEntity();
            entity.AddComponent<Unit>();
            entity.AddComponent<MoveDirectionValue>();
            entity.AddComponent<RotationValue>();
            entity.AddComponent<MoveWithRotation>();
            entity.AddComponent<AlignRotationWithMoveDirection>();
            entity.AddComponent<MoveSpeedValue>();

            return entity;
        }
    }
}