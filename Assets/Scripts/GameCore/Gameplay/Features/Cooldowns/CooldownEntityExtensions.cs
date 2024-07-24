using GameCore.Gameplay.Common;
using GameCore.Gameplay.Features.Cooldowns.Components;
using Scellecs.Morpeh;

namespace GameCore.Gameplay.Features.Cooldowns
{
    public static class CooldownEntityExtensions
    {
        public static Entity PutOnCooldown(this Entity entity)
        {
            if (entity.Has<Cooldown>())
                return entity;

            entity.RemoveComponent<CooldownUp>();

            ref var cooldownLeft = ref entity.GetOrAdd<CooldownLeft>();
            cooldownLeft.Value = entity.GetComponent<Cooldown>().Value;

            return entity;
        }

        public static Entity PutOnCooldown(this Entity entity, float cooldown)
        {
            entity.RemoveComponent<CooldownUp>();

            ref var cooldownComponent = ref entity.GetOrAdd<Cooldown>();
            cooldownComponent.Value = cooldown;

            ref var cooldownLeft = ref entity.GetOrAdd<CooldownLeft>();
            cooldownLeft.Value = cooldown;

            return entity;
        }
    }
}