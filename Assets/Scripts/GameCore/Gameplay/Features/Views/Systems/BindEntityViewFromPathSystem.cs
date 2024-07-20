using Cysharp.Threading.Tasks;
using GameCore.Gameplay.Features.Common;
using GameCore.Gameplay.Features.Views.Factory;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.Views.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class BindEntityViewFromPathSystem : ISystem
    {
        private readonly IEntityViewFactory _entityViewFactory;

        private Filter _entities;

        public BindEntityViewFromPathSystem(IEntityViewFactory entityViewFactory)
        {
            _entityViewFactory = entityViewFactory;
        }

        public World World { get; set; }

        public void OnAwake()
        {
            _entities = World.Filter
                .With<CreateRequest>()
                .With<ViewPathComponent>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _entities)
            {
                entity.RemoveComponent<CreateRequest>();

                _entityViewFactory.CreateForEntityAsync(entity, entity.GetComponent<ViewPathComponent>().Path).Forget();
            }
        }

        public void Dispose()
        {
        }
    }
}