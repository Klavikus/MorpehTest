using GameCore.Gameplay.Features.MovingFeature.Components;
using GameCore.Gameplay.Features.PlayerFeature.Components;
using Scellecs.Morpeh;

namespace GameCore.Gameplay.Features.PlayerFeature.Factories
{
    public class PlayerFactory
    {
        public Entity Build(World world)
        {
            var entity = world.CreateEntity();
            entity.AddComponent<PlayerTagComponent>();
            entity.AddComponent<MoveDirectionComponent>();
            entity.AddComponent<RotationComponent>();
            entity.AddComponent<MoveWithRotationTag>();
            entity.AddComponent<AlignRotationWithMoveDirectionTag>();
            entity.AddComponent<MoveSpeedComponent>();

            return entity;
        }
    }
}