using GameCore.Gameplay.Features.MovingFeature.Components;
using GameCore.Gameplay.Features.PlayerFeature.Components;
using Scellecs.Morpeh;

namespace GameCore.Gameplay.Features.PlayerFeature.Factories
{
    public class PlayerBuilder
    {
        public Entity Build(World world)
        {
            var entity = world.CreateEntity();
            entity.AddComponent<Player>();
            entity.AddComponent<MoveDirectionValue>();
            entity.AddComponent<RotationValue>();
            entity.AddComponent<MoveWithRotation>();
            entity.AddComponent<AlignRotationWithMoveDirection>();
            entity.AddComponent<MoveSpeedValue>();

            return entity;
        }
    }
}