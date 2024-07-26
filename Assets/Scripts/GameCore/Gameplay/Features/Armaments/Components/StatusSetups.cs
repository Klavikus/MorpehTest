using System.Collections.Generic;
using GameCore.Gameplay.Features.Statuses;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.Armaments.Components
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct StatusSetups : IComponent
    {
        public List<StatusSetup> Value;
    }
}