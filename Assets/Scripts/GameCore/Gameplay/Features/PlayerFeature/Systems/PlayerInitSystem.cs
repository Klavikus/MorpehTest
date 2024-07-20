using GameCore.Gameplay.Features.ViewFeature.Factory;
using GameCore.Gameplay.Services;
using GameCore.Infrastructure;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.PlayerFeature.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class PlayerInitSystem : IInitializer
    {
        private readonly IEntityViewFactory _entityViewFactory;
        private readonly IConfigurationProvider _configurationProvider;
        private readonly GameplayCamera _gameplayCamera;

        public PlayerInitSystem(
            IEntityViewFactory entityViewFactory,
            IConfigurationProvider configurationProvider,
            GameplayCamera gameplayCamera)
        {
            _entityViewFactory = entityViewFactory;
            _configurationProvider = configurationProvider;
            _gameplayCamera = gameplayCamera;
        }

        public World World { get; set; }

        public void Dispose()
        {
        }

        public async void OnAwake()
        {
            var entity = World.CreateEntity();

            var view = await _entityViewFactory.CreateForEntityAsync(entity,
                _configurationProvider.PlayerRegistrar.AssetGUID);

            _gameplayCamera.FocusTo(view.transform);
        }
    }
}