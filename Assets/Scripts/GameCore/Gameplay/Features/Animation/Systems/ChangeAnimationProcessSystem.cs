using GameCore.Gameplay.Features.AnimationFeature.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace GameCore.Gameplay.Features.AnimationFeature.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class ChangeAnimationProcessSystem : ISystem
    {
        private readonly int _runHash = Animator.StringToHash("Run");

        private Filter _boolRequests;
        private Stash<BasicMotionSyncRequest> _boolRequestStash;
        private Stash<AnimatorValue> _animatorStash;

        public World World { get; set; }

        public void OnAwake()
        {
            _boolRequests = World
                .Filter
                .With<BasicMotionSyncRequest>()
                .Build();

            _animatorStash = World.GetStash<AnimatorValue>();
            _boolRequestStash = World.GetStash<BasicMotionSyncRequest>();
        }

        public void Dispose()
        {
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _boolRequests)
            {
                var request = _boolRequestStash.Get(entity);
                var target = _animatorStash.Get(request.Target);

                target.Value.SetBool(_runHash, request.IsRunning);
            }

            _boolRequestStash.RemoveAll();
        }
    }
}