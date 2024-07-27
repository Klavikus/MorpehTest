using GameCore.Gameplay.Common;
using GameCore.Gameplay.Features.Animation.Systems;

namespace GameCore.Gameplay.Features.Animation
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