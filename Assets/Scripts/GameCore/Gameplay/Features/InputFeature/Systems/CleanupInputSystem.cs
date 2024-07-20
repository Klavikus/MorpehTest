using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.InputFeature.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class CleanupInputSystem : ICleanupSystem
    {
        public void OnAwake()
        {
        }

        public World World { get; set; }

        public void OnUpdate(float deltaTime)
        {
            var healthStash = World.GetStash<PlayerInputComponent>();
            healthStash.RemoveAll();
        }

        public void Dispose()
        {
        }
    }
}