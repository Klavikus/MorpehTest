using GameCore.Gameplay.Common.Components;
using GameCore.Gameplay.Common.View.Components;
using GameCore.Gameplay.Common.View.Factory;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using VContainer;

namespace GameCore.Gameplay.Common.View.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class BindEntityViewFromPrefabSystem : ISystem, IInjectable
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
                .With<ViewPrefabValue>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _entities)
            {
                entity.RemoveComponent<CreateRequest>();

                _entityViewFactory.CreateForEntityFromPrefab(entity, entity.GetComponent<ViewPrefabValue>().Value);

                entity.AddComponent<CreateComplete>();
            }
        }

        public void Dispose()
        {
        }
    }
}