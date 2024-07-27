using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.Input.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class CleanupInputSystem : ICleanupSystem
    {
        private Stash<PlayerInputComponent> _healthStash;

        public void OnAwake()
        {
            _healthStash = World.GetStash<PlayerInputComponent>();
        }

        public World World { get; set; }

        public void OnUpdate(float deltaTime)
        {
            _healthStash.RemoveAll();
        }

        public void Dispose()
        {
        }
    }
}