﻿using System.Collections.Generic;
using GameCore.Gameplay.Features.Effects;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.Armaments.Components
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct EffectSetups : IComponent
    {
        public List<EffectSetup> Value;
    }
}