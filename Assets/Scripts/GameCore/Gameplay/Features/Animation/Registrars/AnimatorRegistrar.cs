using GameCore.Gameplay.Common.View.Registrars;
using GameCore.Gameplay.Features.Animation.Components;
using Scellecs.Morpeh;
using UnityEngine;

namespace GameCore.Gameplay.Features.Animation.Registrars
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