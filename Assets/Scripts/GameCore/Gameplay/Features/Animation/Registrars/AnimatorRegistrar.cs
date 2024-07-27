using GameCore.Gameplay.Features.AnimationFeature.Components;
using GameCore.Gameplay.Features.ViewFeature.Registrars;
using Scellecs.Morpeh;
using UnityEngine;

namespace GameCore.Gameplay.Features.AnimationFeature.Registrars
{
    public class AnimatorRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private Animator _animator;

        public override void RegisterComponents(Entity gameEntity)
        {
            ref var animatorComponent = ref gameEntity.AddComponent<AnimatorValue>();
            animatorComponent.Value = _animator;
        }

        public override void UnregisterComponents(Entity gameEntity)
        {
            if (gameEntity.Has<AnimatorValue>())
                gameEntity.RemoveComponent<AnimatorValue>();
        }
    }
}