using GameCore.Gameplay.Features.Common;
using GameCore.Gameplay.Features.ViewFeature.Factory;
using GameCore.Gameplay.Services;
using GameCore.Infrastructure;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using VContainer;

namespace GameCore.Gameplay.Features.PlayerFeature.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class PlayerInitSystem : IInitializer, IInjectable
    {
        private IEntityViewFactory _entityViewFactory;
        private IConfigurationProvider _configurationProvider;
        private GameplayCamera _gameplayCamera;

        public World World { get; set; }

        public void Inject(IObjectResolver objectResolver)
        {
            _entityViewFactory = objectResolver.Resolve<IEntityViewFactory>();
            _configurationProvider = objectResolver.Resolve<IConfigurationProvider>();
            _gameplayCamera = objectResolver.Resolve<GameplayCamera>();
        }

        public async void OnAwake()
        {
            var entity = World.CreateEntity();

            var view = await _entityViewFactory.CreateForEntityAsync(entity,
                _configurationProvider.PlayerRegistrar.AssetGUID);

            _gameplayCamera.FocusTo(view.transform);
        }

        public void Dispose()
        {
        }
    }
}