﻿using GameCore.Gameplay.Features.Common;
using GameCore.Gameplay.Features.Cooldowns.Systems;

namespace GameCore.Gameplay.Features.Cooldowns
{
    public class CooldownFeature : Feature
    {
        public CooldownFeature()
        {
            AddSystem<CooldownSystem>();
        }
    }
}