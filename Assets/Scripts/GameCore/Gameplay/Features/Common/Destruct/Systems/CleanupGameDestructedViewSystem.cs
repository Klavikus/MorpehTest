using GameCore.Gameplay.Features.Common.Components;
using GameCore.Gameplay.Features.ViewFeature.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace GameCore.Gameplay.Features.Common.Destruct.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class CleanupGameDestructedViewSystem : ICleanupSystem
    {
        private Filter _entities;

        public World World { get; set; }

        public void OnAwake()
        {
            _entities = World.Filter
                .With<DestructedTag>()
                .With<ViewComponent>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _entities)
            {
                entity.GetComponent<ViewComponent>();
                var view = entity.GetComponent<ViewComponent>().View;
                view.Release();
                Object.Destroy(view.GameObject);
            }
        }

        public void Dispose()
        {
        }
    }
}