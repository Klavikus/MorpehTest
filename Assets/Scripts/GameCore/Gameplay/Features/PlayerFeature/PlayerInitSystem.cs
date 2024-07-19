using GameCore.Gameplay.Services;
using GameCore.Infrastructure;
using Qw1nt.Runtime.AddressablesContentController.Core;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.MovingFeature.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class PlayerInitSystem : IInitializer
    {
        private readonly ContentController _contentController;
        private readonly IConfigurationProvider _configurationProvider;
        private readonly GameplayCamera _gameplayCamera;

        public PlayerInitSystem(
            ContentController contentController,
            IConfigurationProvider configurationProvider,
            GameplayCamera gameplayCamera)
        {
            _contentController = contentController;
            _configurationProvider = configurationProvider;
            _gameplayCamera = gameplayCamera;
        }

        public World World { get; set; }

        public void Dispose()
        {
        }

        public async void OnAwake()
        {
            PlayerRegistrar registrar =
                await _contentController.InstantiateAsync<PlayerRegistrar>(_configurationProvider.PlayerRegistrar);

            var entity = World.CreateEntity();

            registrar.RegisterComponents(entity);
            
            _gameplayCamera.FocusTo(registrar.transform);
        }
    }
}