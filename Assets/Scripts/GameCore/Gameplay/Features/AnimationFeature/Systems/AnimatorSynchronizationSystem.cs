﻿using GameCore.Gameplay.Features.MovingFeature.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace GameCore.Gameplay.Features.AnimationFeature.Systems
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
                .With<AnimatorComponent>()
                .With<MoveComponent>()
                .Build();
        }

        public void Dispose()
        {
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _entities)
            {
                ref var request = ref World.CreateEntity().AddComponent<ChangeBoolAnimationRequest>();
                request.Target = entity;
                request.Value = entity.GetComponent<MoveComponent>().Speed != 0;
                request.AnimationHash = Animator.StringToHash("Run");
            }
        }
    }
}