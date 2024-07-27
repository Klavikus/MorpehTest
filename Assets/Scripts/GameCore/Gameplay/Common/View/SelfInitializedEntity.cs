using Scellecs.Morpeh;
using UnityEngine;
using VContainer;

namespace GameCore.Gameplay.Common.View
{
    public class SelfInitializedEntity : MonoBehaviour
    {
        [SerializeField] private EntityView _entityView;

        private World _world;

        [Inject]
        private void Construct(World world)
        {
            _world = world;
        }

        private void Awake()
        {
            Entity entity = _world.CreateEntity();

            _entityView.SetEntity(entity);
        }
    }
}