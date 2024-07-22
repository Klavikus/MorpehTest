using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.MovingFeature.Components
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [System.Serializable]
    public struct MoveSpeedComponent : IComponent
    {
        public float Value;
    }
}