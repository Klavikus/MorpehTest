using GameCore.Gameplay.Common;
using GameCore.Gameplay.Features.Cooldowns.Components;
using Scellecs.Morpeh;

namespace GameCore.Gameplay.Features.Cooldowns
{
    public static class CooldownEntityExtensions
    {
        public static Entity PutOnCooldown(this Entity entity)
        {
            if (entity.Has<CooldownValue>())
                return entity;

            entity.RemoveComponent<CooldownUp>();

            ref var cooldownLeft = ref entity.GetOrAdd<CooldownLeftValue>();
            cooldownLeft.Value = entity.GetComponent<CooldownValue>().Value;

            return entity;
        }

        public static Entity PutOnCooldown(this Entity entity, float cooldown)
        {
            entity.RemoveComponent<CooldownUp>();

            ref var cooldownComponent = ref entity.GetOrAdd<CooldownValue>();
            cooldownComponent.Value = cooldown;

            ref var cooldownLeft = ref entity.GetOrAdd<CooldownLeftValue>();
            cooldownLeft.Value = cooldown;

            return entity;
        }
    }
}