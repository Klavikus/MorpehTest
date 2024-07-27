using Cysharp.Threading.Tasks;
using GameCore.Gameplay.Common;
using GameCore.Gameplay.Common.Components;
using GameCore.Gameplay.Features.Common.Components;
using GameCore.Gameplay.Features.ViewFeature.Components;
using GameCore.Gameplay.Features.ViewFeature.Factory;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using VContainer;

namespace GameCore.Gameplay.Features.ViewFeature.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class BindEntityViewFromPathSystem : ISystem, IInjectable
    {
        private IEntityViewFactory _entityViewFactory;
        private Filter _entities;

        public World World { get; set; }

        public void Inject(IObjectResolver objectResolver)
        {
            _entityViewFactory = objectResolver.Resolve<IEntityViewFactory>();
        }

        public void OnAwake()
        {
            _entities = World.Filter
                .With<CreateRequest>()
                .With<ViewPathValue>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _entities)
            {
                entity.RemoveComponent<CreateRequest>();

                if (entity.Has<WorldPositionValue>())
                {
                    _entityViewFactory.CreateForEntityAsync(
                            entity,
                            entity.GetComponent<ViewPathValue>().Value,
                            entity.GetComponent<WorldPositionValue>().Value,
                            Vector3.zero)
                        .Forget();
                }
                else
                {
                    _entityViewFactory.CreateForEntityAsync(entity, entity.GetComponent<ViewPathValue>().Value)
                        .Forget();
                }
            }
        }

        public void Dispose()
        {
        }
    }
}