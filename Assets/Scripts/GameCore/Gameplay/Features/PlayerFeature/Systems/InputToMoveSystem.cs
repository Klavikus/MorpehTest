using GameCore.Gameplay.Features.InputFeature;
using GameCore.Gameplay.Features.MovingFeature.Components;
using GameCore.Gameplay.Features.PlayerFeature.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace GameCore.Gameplay.Features.PlayerFeature.Systems
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
            _players = World.Filter.With<PlayerTagComponent>().Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity input in _inputs)
            {
                ref var inputComponent = ref input.GetComponent<PlayerInputComponent>();

                foreach (Entity player in _players)
                {
                    ref var direction = ref player.GetComponent<MoveDirectionComponent>();
                    direction.Value = new Vector3(inputComponent.Horizontal, 0, inputComponent.Vertical).normalized;

                    ref var speed = ref player.GetComponent<MoveSpeedComponent>();
                    speed.Value = 1;
                }
            }
        }

        public void Dispose()
        {
        }
    }
}