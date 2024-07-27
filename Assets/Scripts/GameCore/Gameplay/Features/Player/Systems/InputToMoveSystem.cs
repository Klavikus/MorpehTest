using GameCore.Gameplay.Features.Input;
using GameCore.Gameplay.Features.Movement.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace GameCore.Gameplay.Features.Player.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class InputToMoveSystem : ISystem
    {
        private Filter _inputs;
        private Filter _players;
        public World World { get; set; }

        public void OnAwake()
        {
            _inputs = World.Filter.With<PlayerInputComponent>().Build();
            _players = World.Filter.With<Components.Player>().Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity input in _inputs)
            {
                ref var inputComponent = ref input.GetComponent<PlayerInputComponent>();

                foreach (Entity player in _players)
                {
                    ref var direction = ref player.GetComponent<MoveDirectionValue>();
                    direction.Value = new Vector3(inputComponent.Horizontal, 0, inputComponent.Vertical).normalized;
                }
            }
        }

        public void Dispose()
        {
        }
    }
}