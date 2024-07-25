using Cysharp.Threading.Tasks;
using GameCore.Gameplay.Common.Components;
using GameCore.Gameplay.Features.Common.Components;
using Qw1nt.Runtime.AddressablesContentController.Core;
using Scellecs.Morpeh;
using UnityEngine;
using VContainer;

namespace GameCore.Gameplay.Features.ViewFeature.Factory
{
    public class EntityViewFactory : IEntityViewFactory
    {
        private static readonly Vector3 FarAway = new(-999, 999, 0);

        private readonly ContentController _contentController;
        private readonly IObjectResolver _objectResolver;

        public EntityViewFactory(ContentController contentController, IObjectResolver objectResolver)
        {
            _contentController = contentController;
            _objectResolver = objectResolver;
        }

        public async UniTask<EntityView> CreateForEntityAsync(Entity entity, string assetPath)
        {
            entity.AddComponent<CreateInProgress>();
            entity.SetComponent(new WorldPosition {Value = FarAway});

            var asset = await _contentController.LoadAsync<GameObject>(assetPath);

            var view = Object
                .Instantiate(asset.GetResult(), FarAway, Quaternion.identity)
                .GetComponent<EntityView>();

            _objectResolver.Inject(view);

            view.SetEntity(entity);

            entity.RemoveComponent<CreateInProgress>();
            entity.AddComponent<CreateComplete>();

            return view;
        }

        public async UniTask<EntityView> CreateForEntityAsync(
            Entity entity,
            string assetPath,
            Vector3 position,
            Vector3 rotation)
        {
            entity.AddComponent<CreateInProgress>();
            entity.SetComponent(new WorldPosition {Value = position});

            var asset = await _contentController.LoadAsync<GameObject>(assetPath);

            var view = Object
                .Instantiate(asset.GetResult(), position, Quaternion.Euler(rotation))
                .GetComponent<EntityView>();

            _objectResolver.Inject(view);

            view.SetEntity(entity);

            entity.RemoveComponent<CreateInProgress>();
            entity.AddComponent<CreateComplete>();

            return view;
        }

        public EntityView CreateForEntityFromPrefab(Entity entity, EntityView entityViewPrefab)
        {
            var view = Object.Instantiate(entityViewPrefab, FarAway, Quaternion.identity);

            _objectResolver.Inject(view);

            view.SetEntity(entity);
            
            entity.SetComponent(new WorldPosition {Value = FarAway});

            return view;
        }
    }
}