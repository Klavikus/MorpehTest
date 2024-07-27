using GameCore.Gameplay.Features.Movement.Components;
using Scellecs.Morpeh;

namespace GameCore.Gameplay.Features.Player.Factories
{
    public class PlayerBuilder
    {
        public Entity Build(World world)
        {
            var entity = world.CreateEntity();
            entity.AddComponent<Components.Player>();
            entity.AddComponent<MoveDirectionValue>();
            entity.AddComponent<RotationValue>();
            entity.AddComponent<MoveWithRotation>();
            entity.AddComponent<AlignRotationWithMoveDirection>();
            entity.AddComponent<MoveSpeedValue>();

            return entity;
        }
    }
}