using Code.Infrastructure.Systems;
using GameCore.Gameplay.Features.AnimationFeature.Systems;
using GameCore.Gameplay.Features.Common;

namespace GameCore.Gameplay.Features.AnimationFeature
{
    public class AnimationFeature : Feature
    {
        public AnimationFeature(ISystemFactory systemFactory)
        {
            AddSystem(systemFactory.Create<AnimatorSynchronizationSystem>());
            AddSystem(systemFactory.Create<ChangeAnimationProcessSystem>());
        }
    }
}