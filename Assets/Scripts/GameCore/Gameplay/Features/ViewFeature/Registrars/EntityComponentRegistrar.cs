﻿using Scellecs.Morpeh;
using UnityEngine;

namespace GameCore.Gameplay.Features.ViewFeature.Registrars
{
    public abstract class EntityComponentRegistrar : MonoBehaviour, IEntityComponentRegistrar
    {
        public abstract void RegisterComponents(Entity gameEntity);
        public abstract void UnregisterComponents(Entity gameEntity);
    }
}