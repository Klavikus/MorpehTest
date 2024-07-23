using GameCore.Gameplay.Features.AnimationFeature.Components;
using Scellecs.Morpeh;
using UnityEngine;

namespace GameCore.Gameplay.Features.ViewFeature.Registrars
{
    public class AnimatorRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private Animator _animator;

        public override void RegisterComponents(Entity gameEntity)
        {
            ref var animatorComponent = ref gameEntity.AddComponent<AnimatorComponent>();
            animatorComponent.Value = _animator;
        }

        public override void UnregisterComponents(Entity gameEntity)
        {
            if (gameEntity.Has<AnimatorComponent>())
                gameEntity.RemoveComponent<AnimatorComponent>();
        }
    }
}