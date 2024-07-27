﻿using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.Input.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class InputSystem : ISystem
    {
        private const string s_horizontal = "Horizontal";
        private const string s_vertical = "Vertical";

        public World World { get; set; }

        public void OnAwake()
        {
        }

        public void OnUpdate(float deltaTime)
        {
            var entity = World.CreateEntity();

            ref var input = ref entity.AddComponent<PlayerInputComponent>();

            input.Horizontal = UnityEngine.Input.GetAxisRaw(s_horizontal);
            input.Vertical = UnityEngine.Input.GetAxisRaw(s_vertical);
        }

        public void Dispose()
        {
        }
    }
}