using GameCore.Gameplay.Common.Collisions;
using GameCore.Gameplay.Features.ViewFeature.Components;
using GameCore.Gameplay.Features.ViewFeature.Registrars;
using Scellecs.Morpeh;
using UnityEngine;
using VContainer;

namespace GameCore.Gameplay.Features.ViewFeature
{
    public class EntityView : MonoBehaviour
    {
        private Entity _entity;
        private ICollisionRegistry _collisionRegistry;

        public Entity Entity => _entity;
        public GameObject GameObject => gameObject;

        [Inject]
        public void Construct(ICollisionRegistry collisionRegistry)
        {
            _collisionRegistry = collisionRegistry;
        }

        public void SetEntity(Entity gameEntity)
        {
            _entity = gameEntity;
            _entity.SetComponent(new ViewValue {Value = this});

            foreach (EntityComponentRegistrar registrar in GetComponentsInChildren<EntityComponentRegistrar>())
                registrar.RegisterComponents(Entity);

            foreach (Collider collider3d in GetComponentsInChildren<Collider>(true))
                _collisionRegistry.Register(collider3d.GetInstanceID(), _entity);
        }

        public void Release()
        {
            foreach (IEntityComponentRegistrar registrar in GetComponentsInChildren<IEntityComponentRegistrar>())
                registrar.UnregisterComponents(Entity);

            foreach (Collider collider3d in GetComponentsInChildren<Collider>(true))
                _collisionRegistry.Unregister(collider3d.GetInstanceID());

            _entity = null;
        }
    }
}