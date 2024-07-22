using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.AnimationFeature.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class ChangeAnimationProcessSystem : ISystem
    {
        private Filter _boolRequests;
        private Stash<ChangeBoolAnimationRequest> _boolRequestStash;
        private Stash<AnimatorComponent> _animatorStash;
        public World World { get; set; }

        public void OnAwake()
        {
            _boolRequests = World
                .Filter
                .With<ChangeBoolAnimationRequest>()
                .Build();

            _animatorStash = World.GetStash<AnimatorComponent>();
            _boolRequestStash = World.GetStash<ChangeBoolAnimationRequest>();
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

                target.Value.SetBool(request.AnimationHash, request.Value);
            }

            _boolRequestStash.RemoveAll();
        }
    }
}