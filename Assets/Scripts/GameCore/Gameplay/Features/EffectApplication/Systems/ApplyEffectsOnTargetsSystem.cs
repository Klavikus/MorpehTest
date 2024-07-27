using GameCore.Gameplay.Common;
using GameCore.Gameplay.Features.Armaments.Components;
using GameCore.Gameplay.Features.Effects;
using GameCore.Gameplay.Features.Effects.Components;
using GameCore.Gameplay.Features.Effects.Factory;
using GameCore.Gameplay.Features.TargetCollection.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using VContainer;

namespace GameCore.Gameplay.Features.EffectApplication.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class ApplyEffectsOnTargetsSystem : ISystem, IInjectable
    {
        private IEffectFactory _effectFactory;
        private Filter _entities;

        public World World { get; set; }

        public void Inject(IObjectResolver objectResolver)
        {
            _effectFactory = objectResolver.Resolve<IEffectFactory>();
        }

        public void OnAwake()
        {
            _entities = World.Filter
                .With<TargetsBufferValue>()
                .With<EffectSetupsValue>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _entities)
            foreach (EntityId targetId in entity.GetComponent<TargetsBufferValue>().Value)
            foreach (EffectSetup setup in entity.GetComponent<EffectSetupsValue>().Value)
            {
                _effectFactory.Create(World, setup, ProducerId(entity), targetId);
            }
        }

        public void Dispose()
        {
        }

        private static EntityId ProducerId(Entity entity) =>
            entity.Has<ProducerIdValue>() ? entity.GetComponent<ProducerIdValue>().Value : entity.ID;
    }
}