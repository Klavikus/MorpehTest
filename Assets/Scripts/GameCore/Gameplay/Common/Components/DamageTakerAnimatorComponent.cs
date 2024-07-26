using System;
using GameCore.Gameplay.Common.Visuals;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Common.Components
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [Serializable]
    public struct DamageTakerAnimatorComponent : IComponent
    {
        public IDamageTakenAnimator Value;
    }
}