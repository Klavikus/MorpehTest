using System;
using System.Collections.Generic;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.TargetCollection.Components
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [Serializable]
    public struct TargetsBuffer : IComponent
    {
        public List<EntityId> Value;
    }
}