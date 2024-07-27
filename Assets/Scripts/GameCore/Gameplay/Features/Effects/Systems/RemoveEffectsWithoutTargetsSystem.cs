using GameCore.Gameplay.Features.Effects.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.Effects.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class RemoveEffectsWithoutTargetsSystem : ISystem
    {
        private Filter _effects;

        public World World { get; set; }

        public void OnAwake()
        {
            _effects = World.Filter
                .With<Effect>()
                .With<TargetIdValue>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity effect in _effects)
            {
                if (World.TryGetEntity(effect.GetComponent<TargetIdValue>().Value, out Entity target) == false)
                    continue;

                if (target.IsNullOrDisposed())
                    effect.Dispose();
            }
        }

        public void Dispose()
        {
        }
    }
}