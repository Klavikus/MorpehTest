﻿using GameCore.Gameplay.Features.Animation.Components;
using GameCore.Gameplay.Features.Movement.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace GameCore.Gameplay.Features.Animation.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class AnimatorSynchronizationSystem : ISystem
    {
        
        private Filter _entities;
        public World World { get; set; }

        public void OnAwake()
        {
            _entities = World.Filter
                .With<AnimatorValue>()
                .With<MoveDirectionValue>()
                .Build();
        }

        public void Dispose()
        {
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _entities)
            {
                ref var request = ref World.CreateEntity().AddComponent<BasicMotionSyncRequest>();
                request.Target = entity;
                request.IsRunning = entity.GetComponent<MoveDirectionValue>().Value != Vector3.zero;
            }
        }
    }
}