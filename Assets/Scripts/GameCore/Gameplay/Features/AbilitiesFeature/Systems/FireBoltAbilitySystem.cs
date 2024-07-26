using GameCore.Domain.Enums;
using GameCore.Gameplay.Common;
using GameCore.Gameplay.Features.AbilitiesFeature.Components;
using GameCore.Gameplay.Features.Armaments.Factory;
using GameCore.Gameplay.Features.Common.Components;
using GameCore.Gameplay.Features.Cooldowns;
using GameCore.Gameplay.Features.Cooldowns.Components;
using GameCore.Gameplay.Features.Effects.Components;
using GameCore.Gameplay.Features.MovingFeature.Components;
using GameCore.Gameplay.Features.PlayerFeature.Components;
using GameCore.Gameplay.Features.UnitFeature.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using VContainer;

namespace GameCore.Gameplay.Features.AbilitiesFeature.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class FireBoltAbilitySystem : ISystem, IInjectable
    {
        private Filter _abilities;
        private Filter _heroes;
        private Filter _enemies;

        private IArmamentsFactory _armamentsFactory;

        public World World { get; set; }

        public void Inject(IObjectResolver objectResolver)
        {
            _armamentsFactory = objectResolver.Resolve<IArmamentsFactory>();
        }

        public void OnAwake()
        {
            _abilities = World.Filter
                .With<AbilityIdComponent>()
                .With<CooldownUp>()
                .Build();

            _heroes = World.Filter
                .With<PlayerTagComponent>()
                .With<TransformComponent>()
                .Build();

            _enemies = World.Filter
                .With<UnitTag>()
                .With<TransformComponent>()
                .Build();
        }

        public void Dispose()
        {
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity ability in _abilities)
            foreach (Entity hero in _heroes)
            {
                if (_enemies.IsEmpty())
                    return;

                var armament = World.CreateEntity();

                _armamentsFactory
                    .CreateFireBolt(1, hero.GetComponent<TransformComponent>().Transform.position, armament);

                armament.SetComponent(new MoveDirectionComponent()
                {
                    Value = (FirstAvailableTarget().GetComponent<TransformComponent>().Transform.position -
                             hero.GetComponent<TransformComponent>().Transform.position).normalized
                });
                armament.SetComponent(new ProducerId {Value = hero.ID});

                ability.PutOnCooldown(2f);
            }
        }

        private Entity FirstAvailableTarget() =>
            _enemies.First();
    }
}