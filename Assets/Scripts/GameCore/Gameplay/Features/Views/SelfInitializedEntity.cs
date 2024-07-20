using Scellecs.Morpeh;
using UnityEngine;
using VContainer;

namespace GameCore.Gameplay.Features.Views
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

            // Entity entity = CreateEntity.Empty()
            // .AddId(_identifierService.Next());

            _entityView.SetEntity(entity);
        }
    }
}