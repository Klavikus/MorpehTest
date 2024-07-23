using GameCore.Gameplay.Features.AnimationFeature.Systems;
using GameCore.Gameplay.Features.Common;

namespace GameCore.Gameplay.Features.AnimationFeature
{
    public class AnimationFeature : Feature
    {
        public AnimationFeature()
        {
            AddSystem<AnimatorSynchronizationSystem>();
            AddSystem<ChangeAnimationProcessSystem>();
        }
    }
}