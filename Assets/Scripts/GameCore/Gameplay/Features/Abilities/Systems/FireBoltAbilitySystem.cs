using GameCore.Gameplay.Common;
using GameCore.Gameplay.Common.View.Components;
using GameCore.Gameplay.Features.Abilities.Components;
using GameCore.Gameplay.Features.Armaments.Factory;
using GameCore.Gameplay.Features.Cooldowns;
using GameCore.Gameplay.Features.Cooldowns.Components;
using GameCore.Gameplay.Features.Effects.Components;
using GameCore.Gameplay.Features.Movement.Components;
using GameCore.Gameplay.Features.Units.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using VContainer;

namespace GameCore.Gameplay.Features.Abilities.Systems
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
                .With<AbilityIdValue>()
                .With<CooldownUp>()
                .Build();

            _heroes = World.Filter
                .With<Player.Components.Player>()
                .With<TransformValue>()
                .Build();

            _enemies = World.Filter
                .With<Unit>()
                .With<TransformValue>()
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
                    .CreateFireBolt(1, hero.GetComponent<TransformValue>().Value.position, armament);

                armament.SetComponent(new MoveDirectionValue()
                {
                    Value = (FirstAvailableTarget().GetComponent<TransformValue>().Value.position -
                             hero.GetComponent<TransformValue>().Value.position).normalized
                });
                armament.SetComponent(new ProducerIdValue {Value = hero.ID});

                ability.PutOnCooldown(2f);
            }
        }

        private Entity FirstAvailableTarget() =>
            _enemies.First();
    }
}