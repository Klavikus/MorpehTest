using System;
using GameCore.Gameplay.Features.Effects.Components;
using Scellecs.Morpeh;

namespace GameCore.Gameplay.Features.Effects.Factory
{
    public class EffectFactory : IEffectFactory
    {
        public Entity Create(World world, EffectSetup setup, EntityId producerId, EntityId targetId)
        {
            switch (setup.EffectTypeId)
            {
                case EffectTypeId.Unknown:
                    break;
                case EffectTypeId.Damage:
                    return CreateDamage(world, producerId, targetId, setup.Value);
                case EffectTypeId.Heal:
                    return CreateHeal(world, producerId, targetId, setup.Value);
            }

            throw new Exception($"Effect with typeId {setup.EffectTypeId} does not exist");
        }

        private Entity CreateDamage(World world, EntityId producerId, EntityId targetId, float value)
        {
            var entity = world.CreateEntity();
            entity.AddComponent<EffectTag>();
            entity.AddComponent<DamageEffectTag>();
            entity.SetComponent(new EffectValue {Value = value});
            entity.SetComponent(new ProducerId {Value = producerId});
            entity.SetComponent(new TargetId {Value = targetId});

            return entity;
        }

        private Entity CreateHeal(World world, EntityId producerId, EntityId targetId, float value)
        {
            var entity = world.CreateEntity();
            entity.AddComponent<EffectTag>();
            entity.AddComponent<HealEffectTag>();
            entity.SetComponent(new EffectValue {Value = value});
            entity.SetComponent(new ProducerId {Value = producerId});
            entity.SetComponent(new TargetId {Value = targetId});

            return entity;
        }
    }
}